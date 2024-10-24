using System.ComponentModel.Design;

namespace HandleStudentsApp
{
    public class StudentManager
    {
        public List<Student> Students = new List<Student>();
        public void AddStudent(Student student) 
        { 
            Students.Add(student);
        }
        public void AddNewStudent() 
        {
            string addNewStudentName = "";
            bool validNameInput = false;

            while (!validNameInput)
            {
                Console.WriteLine("Type the name of the student:");
                addNewStudentName = Console.ReadLine()!;

                if (addNewStudentName.Any(char.IsDigit))
                {
                    Console.WriteLine("Error, student name cannot contain numbers. Please try again.");
                }
                else
                {
                    validNameInput = true;
                }
            }

            int addNewStudentId = 0;
            bool validIdInput = false;

            while (!validIdInput)
            {
                Console.WriteLine("Type the ID of the student:");
                string inputId = Console.ReadLine()!;

                if (inputId.All(char.IsDigit))
                {
                    addNewStudentId = Convert.ToInt32(inputId);

                    bool studentIdExists = Students.Any(student => student.StudentId == addNewStudentId);

                    if (studentIdExists)
                    {
                        Console.WriteLine("That student ID already exists, please try again.");
                    }
                    else
                    {
                        validIdInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Error, student ID must only contain numbers. Please try again.");
                }
            }

            int addNewStudentAge = 0;
            bool validAgeInput = false;

            while (!validAgeInput)
            {
                Console.WriteLine("Type the age of the student:");
                string inputAge = Console.ReadLine()!;

                if (inputAge.All(char.IsDigit))
                {
                    addNewStudentAge = Convert.ToInt32(inputAge);
                    validAgeInput = true;
                }
                else
                {
                    Console.WriteLine("Error, student age must only contain numbers. Please try again.");
                }
            }

            Student newStudent = new Student(addNewStudentName, addNewStudentId, addNewStudentAge);
            AddStudent(newStudent);
            Console.WriteLine($"Student {addNewStudentName} with ID {addNewStudentId} has been added.");
        }
        public void AddGradeToStudent()
        {
            Console.WriteLine("Type the name of the student you want to add a grade to:");
            string studentToAddGradeTo = Console.ReadLine()!;

            Student? foundStudent = Students.FirstOrDefault(student => student.StudentName == studentToAddGradeTo);

            if (foundStudent != null)
            {
                Console.WriteLine("Type the grade you want to add:");
                int studentGradeToAdd = Convert.ToInt32(Console.ReadLine()!);

                foundStudent.AddGrade(studentGradeToAdd);
                Console.WriteLine($"{studentToAddGradeTo}'s grade {studentGradeToAdd} has been added.");
            }
            else
            {
                Console.WriteLine($"Student with the name {studentToAddGradeTo} was not found.");
            }
        }
        public void RemoveStudent() 
        {
            Console.WriteLine("Type the ID of the student you want to remove:");
            int studentToRemoveId = Convert.ToInt32(Console.ReadLine()!);
            Student? studentToRemove = Students.FirstOrDefault(student => student.StudentId == studentToRemoveId);

            if (studentToRemove != null) 
            {
                Students.Remove(studentToRemove);
                Console.WriteLine($"Student {studentToRemove.StudentName} with ID {studentToRemoveId} has been removed.");
            }
            else
            {
                Console.WriteLine($"Student with ID {studentToRemoveId} was not found.");
            }
        }
        public void CalculateAverageGrade() 
        {
            Console.WriteLine("Type the ID of the student whose grade you want to calculate:");
            int studentToCalculageAverageGradeId = Convert.ToInt32(Console.ReadLine()!);

            Student? studentToCalculateAverageGrade = Students.FirstOrDefault(student => student.StudentId == studentToCalculageAverageGradeId);

            if (studentToCalculateAverageGrade != null) 
            {
                if (studentToCalculateAverageGrade.StudentGrade.Count > 0)
                {
                    double average = studentToCalculateAverageGrade.StudentGrade.Average();
                    Console.WriteLine($"The average grade for student {studentToCalculateAverageGrade.StudentName} is {average}.");
                }
                else
                {
                    Console.WriteLine($"Student {studentToCalculateAverageGrade.StudentName} has no recorded grades.");
                }
            }
            else
            {
                Console.WriteLine($"No student found with ID {studentToCalculageAverageGradeId}.");
            }
        }
        public void ListStudentsWithGradeAbove(int minimumAverageGrade) 
        {
            bool foundAnyWithAverageGradeAbove = false;
            foreach (var student in Students) 
            {
                if (student.StudentGrade.Count > 0)
                {
                    double averageGrade = student.StudentGrade.Average();

                    if (averageGrade > minimumAverageGrade)
                    {
                        Console.WriteLine($"Student {student.StudentName} has average grade of {averageGrade}");
                        foundAnyWithAverageGradeAbove = true;
                    }
                }
            }
            if(!foundAnyWithAverageGradeAbove)
            {
                Console.WriteLine($"No students found with an average grade above {minimumAverageGrade}");
            }
        }
    }
}
