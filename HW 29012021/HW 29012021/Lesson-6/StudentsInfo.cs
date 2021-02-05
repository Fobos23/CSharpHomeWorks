using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_6
{
    public class StudentsInfo
    {
        private List<Student> students;

        public StudentsInfo(List<Student> students)
        {
            this.students = students;
        }

        public int GetCountStudents<T>(StudentsParams studentParam, T firstValue, T secondValue = default)
        {
            var count = 0;
            switch (studentParam)
            {
                case StudentsParams.LastName:
                    if (firstValue is string)
                        count = students.Count(stud => stud.LastName.Equals(firstValue));
                    break;
                case StudentsParams.FirstName:
                    if (firstValue is string)
                        count = students.Count(stud => stud.FirstName.Equals(firstValue));
                    break;
                case StudentsParams.University:
                    if (firstValue is string)
                        count = students.Count(stud => stud.University.Equals(firstValue));
                    break;
                case StudentsParams.Faculty:
                    if (firstValue is string)
                        count = students.Count(stud => stud.Faculty.Equals(firstValue));
                    break;
                case StudentsParams.City:
                    if (firstValue is string)
                        count = students.Count(stud => stud.City.Equals(firstValue));
                    break;
                case StudentsParams.Department:
                    if (firstValue is string)
                        count = students.Count(stud => stud.Department.Equals(firstValue));
                    break;
                case StudentsParams.Group:
                    if (firstValue is int)
                        count = students.Count(
                            stud => stud.Group >= Convert.ToInt32(firstValue) && stud.Group <= Convert.ToInt32(secondValue));
                    break;
                case StudentsParams.Course:
                    if (firstValue is int)
                        count = students.Count(
                            stud => stud.Course >= Convert.ToInt32(firstValue) && stud.Course <= Convert.ToInt32(secondValue));
                    break;
                case StudentsParams.Age:
                    if (firstValue is int)
                        count = students.Count(
                            stud => stud.Age >= Convert.ToInt32(firstValue) && stud.Age <= Convert.ToInt32(secondValue));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(studentParam), studentParam, null);
            }

            return count;
        }


        public IEnumerable<Student> GetSortedStudents(StudentsParams studentParam)
        {
            var sortedStudents = students;

            switch (studentParam)
            {
                case StudentsParams.LastName:
                    sortedStudents.Sort((st1, st2) =>
                    {
                        if (st1.LastName == null && st2.LastName == null) return 0;
                        if (st1.LastName == null) return -1;
                        return st2.LastName == null ? 1 : st1.LastName.CompareTo(st2.LastName);
                    });
                    break;
                case StudentsParams.FirstName:
                    sortedStudents.Sort((st1, st2) =>
                    {
                        if (st1.FirstName == null && st2.FirstName == null) return 0;
                        if (st1.FirstName == null) return -1;
                        return st2.FirstName == null ? 1 : st1.FirstName.CompareTo(st2.FirstName);
                    });
                    break;
                case StudentsParams.University:
                    sortedStudents.Sort((st1, st2) =>
                    {
                        if (st1.University == null && st2.University == null) return 0;
                        if (st1.University == null) return -1;
                        return st2.University == null ? 1 : st1.University.CompareTo(st2.University);
                    });
                    break;
                case StudentsParams.Faculty:
                    sortedStudents.Sort((st1, st2) =>
                    {
                        if (st1.Faculty == null && st2.Faculty == null) return 0;
                        if (st1.Faculty == null) return -1;
                        return st2.Faculty == null ? 1 : st1.Faculty.CompareTo(st2.Faculty);
                    });
                    break;
                case StudentsParams.Course:
                    sortedStudents.Sort((st1, st2) => st1.Course.CompareTo(st2.Course));
                    break;
                case StudentsParams.Department:
                    sortedStudents.Sort((st1, st2) =>
                    {
                        if (st1.Department == null && st2.Department == null) return 0;
                        if (st1.Department == null) return -1;
                        return st2.Department == null ? 1 : st1.Department.CompareTo(st2.Department);
                    });
                    break;
                case StudentsParams.Group:
                    sortedStudents.Sort((st1, st2) => st1.Group.CompareTo(st2.Group));
                    break;
                case StudentsParams.City:
                    sortedStudents.Sort((st1, st2) =>
                    {
                        if (st1.City == null && st2.City == null) return 0;
                        if (st1.City == null) return -1;
                        return st2.City == null ? 1 : st1.City.CompareTo(st2.City);
                    });
                    break;
                case StudentsParams.Age:
                    sortedStudents.Sort((st1, st2) => st1.Age.CompareTo(st2.Age));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(studentParam), studentParam, null);
            }

            return sortedStudents;
        }
    }
}