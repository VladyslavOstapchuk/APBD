using System;

namespace LinqTutorials.Models
{
    public class Emp
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }
        //Nullable<DateTime> g = null or DataTime = null
        public DateTime? HireDate { get; set; }
        public int? Deptno { get; set; }
        public Emp Mgr { get; set; }

        public override string ToString()
        {
            return $"{Ename} ({Empno})";
        }
        
        public override bool Equals(Object obj)
        {
            Emp empObj = obj as Emp;
            if (empObj == null)
                return false;
            else
                return Empno.Equals(empObj.Empno);
        }

        public override int GetHashCode()
        {
            return this.Empno.GetHashCode();
        }

    }
}