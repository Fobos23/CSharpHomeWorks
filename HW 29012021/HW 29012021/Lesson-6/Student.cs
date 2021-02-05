namespace Lesson_6
{
    public class Student
    {
        public Student(string firstName, string lastName, string university, string faculty, string department, int course,int age, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }

        private string lastName;
        public string LastName => lastName;
        
        private string firstName;
        public string FirstName => firstName;
        
        private string university;
        public string University => university;
        
        private string faculty;
        public string Faculty => faculty;

        private int course;
        public int Course => course;
        
        private string department;
        public string Department => department;
        
        private int age;
        public int Age => age;
        
        private int group;
        public int Group => group;
        
        private string city;
        public string City => city;

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Age}\n{University} {Faculty} {Department} {Course} {Group}\n{City}";
        }
    }
}