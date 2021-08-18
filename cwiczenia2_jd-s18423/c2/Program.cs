using System;
using System.Collections.Generic;
using System.IO;
using c2.Exceptions;
using c2.Classes;
using System.Text.Json;

namespace c2
{
    class Program
    {
        static void Main(string[] args)
        {
            //To see if args are initialized 
            //foreach (var arg in args) { Console.WriteLine(arg); }
            var errors = new List<string>();
            //Path to source file
            var path = args[0];


            try
            {
                //Read from file
                var fi = new FileInfo(path);
                //There are stored lines from the source file
                var fileContent = new List<string>();


                //READ FROM FILE
                //using in this case performs role of catch in Java
                using (var stream = new StreamReader(fi.OpenRead()))
                {
                    string line = null;
                    //untill stream has smth to read
                    while ((line = stream.ReadLine()) != null)
                    {
                        fileContent.Add(line);
                    }
                }

                //CREATE OBJECTS
                var students = new HashSet<Student>(new MyComparer());
                foreach (var line in fileContent)
                {
                    try
                    {
                        var tmp = line.Split(",");
                        //CHECK IF RECORD HAS RIGHT FORMAT
                        if (tmp.Length != 9)
                        {
                            throw new WrongRecordFormat($"Nie wszystkie dane są podane !!! {line}");
                        }
                        else if (
                            !string.IsNullOrWhiteSpace(tmp[0]) &&
                            !string.IsNullOrWhiteSpace(tmp[1]) &&
                            !string.IsNullOrWhiteSpace(tmp[2]) &&
                            !string.IsNullOrWhiteSpace(tmp[3]) &&
                            !string.IsNullOrWhiteSpace(tmp[4]) &&
                            !string.IsNullOrWhiteSpace(tmp[5]) &&
                            !string.IsNullOrWhiteSpace(tmp[6]) &&
                            !string.IsNullOrWhiteSpace(tmp[7]) &&
                            !string.IsNullOrWhiteSpace(tmp[8])
                            )
                        {
                            var tmpStudent = new Student
                            {
                                Fname = tmp[0],
                                Lname = tmp[1],
                                StudStudies = new Studies { Name = tmp[2], Mode = tmp[3] },
                                IndexNumber = tmp[4],
                                Birthdate = DateTime.Parse(tmp[5]),
                                Email = tmp[6],
                                MothersName = tmp[7],
                                FathersName = tmp[8]
                            };

                            //CHECK IF ALREADY EXISTS
                            if (!students.Contains(tmpStudent))
                            {
                                students.Add(tmpStudent);
                            }
                            else
                            {
                                throw new DuplicatedRow($"{tmpStudent.IndexNumber} {tmpStudent.Fname} {tmpStudent.Lname}");
                            }
                        }
                        else
                        {
                            throw new WrongRecordFormat($"Nie wszystkie dane są podane !!! {line}");
                        }
                    }
                    catch (WrongRecordFormat w)
                    {
                        errors.Add(w.Message);
                    }
                    catch (DuplicatedRow d)
                    {
                        errors.Add(d.Message);
                    }
                }

                //SAVE TO JSON
                //Result file is in "bin\Debug\net5.0\Data"
                if (students.Count > 0)
                {
                    try
                    {
                        //Create result file if it doesn't exist
                        var PathToResult = "Data\\Students.json";

                        //Write data
                        using (StreamWriter sw = new StreamWriter(PathToResult, false, System.Text.Encoding.Default))
                        {
                            var json = JsonSerializer.Serialize(new University
                            {
                                author = "Vladyslav Ostapchuk",
                                name = "XYZ",
                                students = students
                            });

                            sw.WriteLine(json);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            //CATCH ERRORS
            catch (FileNotFoundException e)
            {
                errors.Add($"Plik {path} nie istnieje");
            }
            catch (ArgumentException e){
                errors.Add("Podana ścieżka jest niepoprawna");
            }

            finally
            {
                //WRITE ERRORS TO THE LOG FILE
                //Log file is in "bin\Debug\net5.0\Data"

                //Check if there are errors
                if (errors.Count > 0)
                {
                    try
                    {
                        //Create log file if it doesn't exist
                        var PathToLog = "Data\\log.txt";

                        //Write data
                        using (StreamWriter sw = new StreamWriter(PathToLog, false, System.Text.Encoding.Default))
                        {
                            foreach (var e in errors)
                                sw.WriteLine(e);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }        
        }
    }
}