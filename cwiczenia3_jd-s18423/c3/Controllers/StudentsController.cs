using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c2;
using c2.Exceptions;
using System.IO;
using System.Net;

//localhost:xxxxx/api/students
//GET - pobieranie
//POST - dodawanie
//PUT - aktualizacja całościowa
//PATCH - aktualizacja częściowa
//DELETE - usuwanie

namespace c3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        static HashSet<Student> students = new HashSet<Student>(new MyComparer());

        public StudentsController()
        {
            try
            {
                //Read from file
                var fi = new FileInfo("D:\\PROJECTS\\GIT\\cwiczenia3_jd-s18423\\c3\\Data\\dane.csv");
      
                using (var stream = new StreamReader(fi.OpenRead()))
                {
                    string line = null;
                    //untill stream has smth to read
                    while ((line = stream.ReadLine()) != null)
                    {
                        var tmp = line.Split(",");
                        students.Add(new Student
                        {
                            Fname = tmp[0],
                            Lname = tmp[1],
                            StudStudies = new Studies()
                            {
                                Name = tmp[2],
                                Mode = tmp[3]
                            },
                            IndexNumber = tmp[4],
                            Birthdate = DateTime.Parse(tmp[5]),
                            Email = tmp[6],
                            MothersName = tmp[7],
                            FathersName = tmp[8]
                        });
                    }
                }
            }

            catch (IOException e) {
                Console.WriteLine(e);
            }
        }

        //Get all students
        [HttpGet]
        public async Task<IActionResult> GetStudents() {
            if (students.Count > 0)
                return Ok(students);
            return StatusCode(500);
        }

        //Get student by index
        [HttpGet("{IndexNumber}")]
        public async Task<IActionResult> GetStudentByIndex(string IndexNumber) {
            foreach (var s in students) {
                if (s.IndexNumber == IndexNumber) return Ok(s);
            }
            return NotFound();
        }

        //Fix it!!!
        //Add student
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Fname) ||
                string.IsNullOrWhiteSpace(student.Lname) ||
                string.IsNullOrWhiteSpace(student.IndexNumber) ||
                string.IsNullOrWhiteSpace(student.Email) ||
                student.Birthdate == null ||
                string.IsNullOrWhiteSpace(student.StudStudies.Mode) ||
                string.IsNullOrWhiteSpace(student.StudStudies.Name) ||
                string.IsNullOrWhiteSpace(student.MothersName) ||
                string.IsNullOrWhiteSpace(student.FathersName)
                ) {
                return StatusCode(418);
                }
            students.Add(student);
            return Ok(student);
        }

        //Fix it!!!
        //Delete student
        [HttpDelete("{IndexNumber}")]
        public IActionResult DeleteStudent(string IndexNumber)
        {
            foreach (var s in students)
            {
                if (s.IndexNumber == IndexNumber)
                    students.Remove(s);
                    return Ok(students);
            }
            return NotFound();
        }
        

        //Fix it!!!
        [HttpPut("IndexNumber")]
        public IActionResult UpdateStudent(string IndexNumber) {
            return Ok();
        }
    }
}
