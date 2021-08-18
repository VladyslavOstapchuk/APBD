using System.Collections.Generic;

namespace c2.Classes
{
    public class University
    {
        public string name { get; set; }
        public string author { get; set; }
        public HashSet<Student> students { get; set; }
    }
}
