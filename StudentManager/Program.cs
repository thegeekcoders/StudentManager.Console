using StudentManager.Entity;
using StudentManager.Services;
using static System.Console;
using static System.Environment;

namespace StudentManager
{
    class Program
    {
        static IStudentData students = new InMemoryStudentData();

        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("1.Add a Student\r\n2.Get by Id\r\n3.Get All Students\r\n4.Remove a student\r\n5.Exit");
                WriteLine("Enter your choice [1-5]");
                int choice = int.Parse(ReadLine());
                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        GetbyId();
                        break;
                    case 3:
                        GetAll();
                        break;
                    case 4:
                        RemoveStudent();
                        break;
                    case 5:
                        WriteLine("Are you sure want to exit? [Y/N]");
                        string input = ReadLine();
                        if (input.ToLower().Equals("y"))
                        {
                            ExitCode = 1;
                            Beep(500,500);
                            Exit(1);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void GetAll()
        {
            foreach (var student in students.GetAll())
            {
                WriteLine($"{student.Id},{student.Name},{student.RollNo}");
                WriteLine();
            }
        }

        private static void GetbyId()
        {
            WriteLine("Enter id to find:");
            int id = int.Parse(ReadLine());

            var student = students.Get(id);

            WriteLine($"Name:{student.Name}");
            WriteLine($"Roll:{student.RollNo}");
        }

        static void AddStudent()
        {
            Student student = new Student();
            WriteLine("Enter id:");
            student.Id = int.Parse(ReadLine());
            WriteLine("Enter Name:");
            student.Name = ReadLine();
            WriteLine("Enter Roll:");
            student.RollNo = ReadLine();

            students.AddStudent(student);
        }

       static void RemoveStudent()
        {
            WriteLine("Enter Id to remove:");
            int id = int.Parse(ReadLine());
            int count = students.Remove(id);
            if (count > 0)
            {
                WriteLine($"Student with Id:{count} is successfully removed.");
            }
        }
    }


}
