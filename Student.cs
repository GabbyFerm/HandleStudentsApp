using System.Diagnostics;

namespace HandleStudentsApp
{
    public class Student
    {
        public string StudentName { get; set; }
        public int StudentId { get; set; }
        public int StudentAge { get; set; }
        public List<int> StudentGrade { get; }

        public Student(string studentName, int studentId, int studentAge) 
        { 
            StudentName = studentName;
            StudentId = studentId;
            StudentAge = studentAge;
            StudentGrade = new List<int>();
        }
        public void ShowStudentInfo()
        {
            Console.WriteLine($"Name: {StudentName}, StudentID: {StudentId}, Age: {StudentAge}, Grade: {string.Join(", ", StudentGrade)}");
        }
        public void AddGrade(int studentGrade)
        {
            StudentGrade.Add(studentGrade);
        }
    }
}
