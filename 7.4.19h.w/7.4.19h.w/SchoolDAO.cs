using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._4._19h.w
{
    class SchoolDAO : ISchoolDAO
    {
        static SQLiteConnection connection;
        public static string dbName = @"c:\sagit\7.4.19hw.db";

        static SchoolDAO()
        {
            connection = new SQLiteConnection($"Data Source = {dbName}; Version=3;");
            connection.Open();
        }
        public static void Close()
        {
            connection.Close();
        }





        public Dictionary<Classroom, List<Students>> GetMapClassToStudentsDictionary()
        {
            Dictionary<Classroom, List<Students>> dictclastu = new Dictionary<Classroom, List<Students>>();
            List<Students> students = new List<Students>();
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT *,class.NAME as class_NAME, students.NAME as students_NAME,class.id as class_id, students.id as students_id FROM students JOIN class ON students.class_id = class.id ", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Students student = new Students
                        {
                            Id = (int)reader["students_ID"],
                            Name = (string)reader["students_NAME"],
                            Age = (int)reader["AGE"],
                            AdressCity = (String)reader["ADRESS_CITY"],
                            Vip = (bool)reader["VIP"],
                            ClassId = (int)reader["class_id"]
                        };

                        Classroom classroom = new Classroom
                        {
                            Id = (int)reader["class_ID"],
                            Name = (string)reader["class_NAME"],
                            Code = (int)reader["code"],
                            NumberOfStudents = (int)reader["number_of_students"],
                            NumberOfVip = (int)reader["number_of_vip"],
                            AgeAverage = (double)reader["age_average"],
                            MostPopularCity = (string)reader["most_popular_city"],
                            OldestVip = (int)reader["oldest_vip"],
                            YoungestVip = (int)reader["youngest_vip"]
                        };

                        dictclastu.Add(classroom, GetStudentsFromClass(classroom.Id));


                    }
                }
            }
            return dictclastu;
        }


        public List<Students> GetStudentsFromClass(int id)
        {
            List<Students> students = new List<Students>();
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT *,class.NAME as class_NAME, students.NAME as students_NAME,class.id as class_id, students.id as students_id FROM students JOIN class ON students.class_id = class.id WHERE class.ID = {id} ", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Students student = new Students
                        {
                            Id = (int)reader["students_ID"],
                            Name = (string)reader["students_NAME"],
                            Age = (int)reader["AGE"],
                            AdressCity = (String)reader["ADRESS_CITY"],
                            Vip = (bool)reader["VIP"],
                            ClassId = (int)reader["class_id"]
                        };

                        Classroom classroom = new Classroom
                        {
                            Id = (int)reader["class_ID"],
                            Name = (string)reader["class_NAME"],
                            Code = (int)reader["code"],
                            NumberOfStudents = (int)reader["number_of_students"],
                            NumberOfVip = (int)reader["number_of_vip"],
                            AgeAverage = (double)reader["age_average"],
                            MostPopularCity = (string)reader["most_popular_city"],
                            OldestVip = (int)reader["oldest_vip"],
                            YoungestVip = (int)reader["youngest_vip"]
                        };
                        students.Add(student);


                    }
                }
            }

            return students;
        }
    }
}
