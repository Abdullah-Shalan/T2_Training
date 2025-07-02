class AnonymousTypes
{
    public static void DisplayInfo()
    {
        var obj = new
        {
            firstName = "Abdullah",
            lastName = "AlShalan",
            age = 22,
            salary = 420.69,
            address = new { country = "Saudi Arabia", city = "Riaydh", street = "King khalid Road" },
            projects = new[] {
                new {projectName = "C# fundamentals", projectDuration = "40 hours"},
                new {projectName = "sql server", projectDuration = "20 Hours"},
                new {projectName = "Dotnet Frameworks", projectDuration = "50 Hours"}
            }
        };

        Console.WriteLine($"Name: {obj.firstName} {obj.lastName}");
        Console.WriteLine($"Age: {obj.age}");
        Console.WriteLine($"Salary: {obj.salary}");
        Console.WriteLine($"Address: {obj.address.country}, {obj.address.city}, {obj.address.street}");
        Console.WriteLine($"-=- Projects -=-\n{new String('=', 20)}");
        foreach (var project in obj.projects)
        {
            Console.WriteLine($"Project: {project.projectName}\nDuration: {project.projectDuration}\n{new String('=', 20)}");

        }
    }
    
    // Declare Delegate
    public delegate void PrintMessage(string message);

    public static void AnonymousMethods()
    {   
        PrintMessage printMessage = delegate (string message)
        {
            Console.WriteLine($"Message: {message}");
        };

        Console.WriteLine($"Write message: ");
        printMessage(Console.ReadLine());
    }
}

