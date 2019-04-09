using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._4._19h.w
{
    interface ISchoolDAO
    {
        Dictionary<Classroom, List<Students>> GetMapClassToStudentsDictionary();
        List<Students> GetStudentsFromClass(int id);

    }
}
