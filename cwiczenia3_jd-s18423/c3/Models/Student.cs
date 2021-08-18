using System;


namespace c2
{
    public class Student
    {   
        public string IndexNumber { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public Studies StudStudies { get; set; }

        public override string ToString()
        {
            return $"{Fname} {Lname} {Email} {StudStudies} {IndexNumber} {Birthdate} {Email} {MothersName} {FathersName}";
        }
    }
}
