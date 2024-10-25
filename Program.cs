namespace HandleStudentsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            InitialiseStudentList(studentManager);

            Console.WriteLine("Welcome to the Student Management System");

            while (true)
            {
                PrintOutMenu();
                string menuOptionChoosed = Console.ReadLine()!;

                switch (menuOptionChoosed)
                {
                    case "1":
                        studentManager.Students.ForEach(student => student.ShowStudentInfo());
                        break;
                    case "2":
                        studentManager.AddNewStudent();
                        break;
                    case "3":
                        studentManager.AddGradeToStudent();
                        break;
                    case "4":
                        studentManager.RemoveStudent();
                        break;
                    case "5":
                        studentManager.CalculateAverageGrade();
                        break;
                    case "6":
                        Console.WriteLine("Above wich average value do you want to list students:");
                        int averageGradeAboveValue = Convert.ToInt32(Console.ReadLine()!);
                        studentManager.ListStudentsWithGradeAbove(averageGradeAboveValue);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;

                }
            }
        }
        private static void InitialiseStudentList(StudentManager studentManager)
        {
            Student student1 = new Student("Sara", 111, 20);
            student1.AddGrade(65);
            student1.AddGrade(85);
            studentManager.AddStudent(student1);

            Student student2 = new Student("Niklas", 222, 21);
            student2.AddGrade(75);
            student2.AddGrade(85);
            studentManager.AddStudent(student2);
        }
        private static void PrintOutMenu()
        {
            Console.WriteLine("\nChoose an option below:");
            Console.WriteLine("1 - Show all students");
            Console.WriteLine("2 - Add a student");
            Console.WriteLine("3 - Add a student grade");
            Console.WriteLine("4 - Remove a student from the list");
            Console.WriteLine("5 - Get average grade for a student");
            Console.WriteLine("6 - List all students with average grade above a specified value");
            Console.WriteLine("7 - Exit");
        }
    }
}
