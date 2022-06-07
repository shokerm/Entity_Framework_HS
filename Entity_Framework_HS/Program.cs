using System;

namespace Entity_Framework_HS
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Menu();


        }

        public static void Menu()
        {

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Select The desired option");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine(
                            "1 - Add a student\n" +
                            "2 - Delete a student\n" +
                            "3 - Update student name\n" +
                            "4 - Get student name by id\n" +
                            "5 - Get all studnets names\n" +
                            "6 - Exit");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                int UserChoise = int.Parse(Console.ReadLine());

                switch (UserChoise)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Delete();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        GetDetails();
                        break;
                    case 5:
                        GetAllStudentsDetails();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        GetAllStudentsDetails();
                        break;
                }
            }


        }

        public static void Add()
        {
            using (var context = new CollegeDbContext())
            {
                Console.WriteLine("Enter the name of the student you wish to add");
                string student = Console.ReadLine();
                Student newStudent = new Student() { Name = student };
                context.Students.AddRange(newStudent);
                context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The student: '{newStudent.Name}' has been added successfully!");
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public static void Delete()
        {
            try
            {
                using (var context = new CollegeDbContext())
                {
                    Console.WriteLine("Enter the student id of the student you wish to delete");
                    int studentId = int.Parse(Console.ReadLine());


                    var deletedStudent = context.Students.Remove(context.Students.Single(x =>
                                                                    x.StudentId == studentId));
                    context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The student: '{deletedStudent.Entity.Name}' has been deleted successfully!");
                    Console.ForegroundColor = ConsoleColor.Black;
                }

            }
            catch (InvalidOperationException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unable to delete non - existent user");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (System.FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }


        }

        public static void Update()
        {
            try
            {
                using (var context = new CollegeDbContext())
                {
                    Console.WriteLine("Enter the student id of the student you wish to update");
                    int studentId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the new name you would like to be");
                    string updatedName = Console.ReadLine();


                    var y = context.Students.Single(x => x.StudentId == studentId);
                    context.Students.Update(y).Entity.Name = updatedName;

                    context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The student's old name is: {y.Name} has been changed successfully!\n" +
                        $"The new name is: {updatedName}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (InvalidOperationException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can not find this id...");
                Console.ForegroundColor = ConsoleColor.White;

            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;

            }

        }

        public static Student GetDetails()
        {

            Console.WriteLine("Enter student id number and get his details");

            try
            {
                int studentIdFromUser = int.Parse(Console.ReadLine());
                using (var context = new CollegeDbContext())
                {
                    var z = context.Students.Single(x => x.StudentId == studentIdFromUser);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Student details:\nName: {z.Name}\nStudentId: {z.StudentId}");
                    Console.ForegroundColor = ConsoleColor.White;
                    return z;

                }
            }
            catch (InvalidOperationException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can not find this id...");
                Console.ForegroundColor = ConsoleColor.White;
                return null;

            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }


        }

        public static List<Student> GetAllStudentsDetails()

        {

            Console.WriteLine("students names details");


            using (var context = new CollegeDbContext())
            {
                List<Student> returnStudentsList = context.Students.ToList();

                returnStudentsList.ForEach(x => Console.WriteLine($"Name:{x.Name.ToString()} .Id = {x.StudentId}"));
                Console.WriteLine("****************");
                return returnStudentsList;

            }
        }

        public static void AddCourse()
        {
            using (var context = new CollegeDbContext())
            {
                Console.WriteLine("Enter new course to add");
                string course = Console.ReadLine();
                Course newCourse = new Course() { CourseName = course };
                context.Courses.AddRange(newCourse);
                context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The course: '{course}' has been added successfully!");
                Console.ForegroundColor = ConsoleColor.Black;


            }
        }
    }
}
