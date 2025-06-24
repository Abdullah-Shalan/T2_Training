using System.Numerics;

class Program
{
    static void Main(string[] args)
    {

        // Test Student Manager
        StudentManager manager = new StudentManager();
        Console.WriteLine($"Total Students: {manager.totalStudents}");
        manager.addStudent();
        Console.WriteLine($"Total Students: {manager.totalStudents}");
        Console.WriteLine($"=======================");


        // Test Control Statements
        ControlStatements control = new ControlStatements();
        control.CheckGrade(2);
        control.PrintNumberswhiler(10);
        ControlStatements.PrintNumbersFor(10);
        Console.WriteLine($"=======================");

        // Testing class Cat
        Cat cat = new Cat("kitty");
        cat.Speak();
        Console.WriteLine($"=======================");

        // Testing class circle
        Circle c = new Circle(2);
        c.printArea();

    }
}