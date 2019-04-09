using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._4._19h.w
{
    class Students
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public string AdressCity { get; set; }
        public bool Vip { get; set; }
        public int ClassId { get; set; }

        public static bool operator ==(Students c1, Students c2)
        {
            if ((c1 == null) && (c2 == null))
                return true;
            if ((c1 == null) || (c2 == null))
                return false;

            return (c1.Id == c2.Id);
        }
        public static bool operator !=(Students c1, Students c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Students c = obj as Students;
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
            return $"Student {Id},{Name},{Age},{AdressCity},{Vip},{ClassId}";
        }

    }
}
