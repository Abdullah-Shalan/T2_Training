using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {

        // AddStudent();
        // DeleteStudent();
        // UpdateStudentName();
        // UpdateStudentSkills();

        // List<Student> students = GetAllStudentFromUni();
        // List<Student> students = GetAllStudentBySkill();

        // foreach (var student in students)
        // {
        //     Console.WriteLine($"Name: {student.Name} | University: {student.University?.Name}");
        // }
    }

    public static void AddStudent()
    {
        using var _context = new ApplicationDbContext();
        {
            var universities = _context.Universities.ToList();
            Student student = PromtStudentInfo(universities);

            _context.Students.Add(student);
            _context.SaveChanges();
            Console.WriteLine($"Successfully Added Student ({student.Name})");
        }
    }

    public static void UpdateStudentName()
    {
        using var _context = new ApplicationDbContext();
        {
            Student student = GetStudent();
            if (student == null) return;

            Console.WriteLine("Enter the new student name:");
            var studentName = Console.ReadLine().ToString().Trim().ToLower();

            student.Name = studentName;
            _context.Update(student);
            _context.SaveChanges();
            Console.WriteLine($"Successfully Update Student name to ({student.Name})");
        }
    }

    public static void UpdateStudentSkills()
    {
        using var _context = new ApplicationDbContext();
        {
            Student student = GetStudent();
            if (student == null) return;

            Console.WriteLine("Enter the new student skills with comma between each skill:");
            var studentSkills = Console.ReadLine().ToString().Trim().ToLower();

            student.Skills = studentSkills;
            _context.Update(student);
            _context.SaveChanges();
            Console.WriteLine($"Successfully Updated ({student.Name})'s Skills");
        }
    }


    public static void DeleteStudent()
    {
        using var _context = new ApplicationDbContext();
        {
            Student student = GetStudent();
            if (student == null) return;

            _context.Students.Remove(student);
            _context.SaveChanges();
            Console.WriteLine($"Successfully Removed Student ({student.Name})");
        }
    }

    public static List<Student> GetAllStudentFromUni()
    {
        using var _context = new ApplicationDbContext();
        {
            Console.WriteLine("Choose the university");
            var universities = _context.Universities.ToList();
            foreach (var university in universities)
            {
                Console.WriteLine($"{university.Id} - {university.Name}");
            }
            var UniversityId = int.Parse(Console.ReadLine());
            List<Student> students = _context.Students
                                    .Where(s => s.UniversityId == UniversityId)
                                    .Include(s => s.University)
                                    .ToList();
            return students;
        }
    }

    // list all the student that have a similar skill
    public static List<Student> GetAllStudentBySkill()
    {
        using var _context = new ApplicationDbContext();
        {
            Console.WriteLine("Enter a skill:");
            var skill = Console.ReadLine().Trim().ToLower();
            List<Student> students = _context.Students
                                    .Where(s => s.Skills.Contains(skill))
                                    .Include(s => s.University)
                                    .ToList();
            return students;
        }
    }




    private static Student GetStudent()
    {
        using var _context = new ApplicationDbContext();
        {
            Console.WriteLine("Enter Student Name or Id:");
            string studentName = Console.ReadLine().ToString().Trim().ToLower();
            bool IsNumber = int.TryParse(studentName, out int studentId);
            if (IsNumber)
            {
                Student student = _context.Students.Find(studentId);
                if (student == null)
                {
                    System.Console.WriteLine($"Error - Student with ID {studentId} doesn't exist");
                    return null;
                }

                return student;
            }
            else
            {
                Student student = _context.Students.SingleOrDefault(s => s.Name.Equals(studentName));
                if (student == null)
                {
                    System.Console.WriteLine($"Error - Student {studentName} doesn't exist");
                    return null;
                }

                return student;
            }
        }

    }

    private static Student PromtStudentInfo(List<University> universities)
    {
        Student student = new Student();

        Console.WriteLine("Enter your name: ");
        student.Name = Console.ReadLine().ToString().Trim().ToLower();

        Console.WriteLine("Enter your birthday (DD-MM-YYYY): ");
        student.Birthday = DateOnly.Parse(Console.ReadLine().ToString());

        Console.WriteLine("Enter your skills with comma between each skill");
        student.Skills = Console.ReadLine();

        Console.WriteLine("Enter the number for your university");
        foreach (var university in universities)
        {
            Console.WriteLine($"{university.Id} - {university.Name}");
        }
        student.UniversityId = int.Parse(Console.ReadLine());

        return student;
    }
}