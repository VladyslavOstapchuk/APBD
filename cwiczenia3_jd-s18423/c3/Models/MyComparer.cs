using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace c2
{
    public class MyComparer : IEqualityComparer<Student>
    {
        //Compare two students
        public bool Equals(Student x, Student y)
        {
            return StringComparer.InvariantCulture
                .Equals(
                $"{x.Fname} {x.Lname} {x.IndexNumber} {x.Email}",
                $"{y.Fname} {y.Lname} {y.IndexNumber} {y.Email}"
                );
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return StringComparer
                .CurrentCultureIgnoreCase
                .GetHashCode($"{obj.Fname} {obj.Lname} {obj.IndexNumber} {obj.Email}");
        }
    }
}
