//Basic usings
//Remove if are not nessesary
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c1
{
    class Student
    {
        //cw - Console.WriteLine()
        //prop - Property

        //public properties
        public string FirstName { get; set; }
        public string Surname{ get; set; }

        //private properties start with _
        private int _sNumber;

        public int SNumber
        {
            get { return _sNumber; }
            set { _sNumber = value; }
        }
    }
}
