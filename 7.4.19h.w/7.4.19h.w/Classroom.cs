using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._4._19h.w
{
    class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }
        public int NumberOfVip { get; set; }
        public double AgeAverage { get; set; }
        public string MostPopularCity { get; set; }
        public int OldestVip { get; set; }
        public int YoungestVip { get; set; }

        public static bool operator ==(Classroom c1, Classroom c2)
        {
            if ((c1 == null) && (c2 == null))
                return true;
            if ((c1 == null) || (c2 == null))
                return false;

            return (c1.Id == c2.Id);
        }
        public static bool operator !=(Classroom c1, Classroom c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Classroom c = obj as Classroom;
            if (c == null)
                return false;

            return this.Id == c.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public override string ToString()
        {
            return $"Classroom {Id},{Name},{NumberOfStudents},{NumberOfVip},{AgeAverage},{MostPopularCity},{OldestVip},{YoungestVip}";
        }


    }
}
