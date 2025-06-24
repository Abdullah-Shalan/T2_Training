class ControlStatements
{
    public void CheckGrade(int grade)
    {
        if (grade >= 0 && grade <= 5)
        {
            Console.WriteLine($"Grade is valid");
        }
        else
        {
            Console.WriteLine($"Grade is invalid, Grades from 0 to 5");
        }
    }

    public static void PrintNumbersFor(int input)
    {
        Console.WriteLine($"Printing number from 0 to {input} using for loop");
        for (int i = 0; i <= input; i++)
        {
            Console.WriteLine($"{i}");
        }
    }
    public void PrintNumberswhiler(int input)
    {
        Console.WriteLine($"Printing number from 0 to {input} using for while");
        int i = 0;
        while (i <= input)
        {
            Console.WriteLine($"{i}");
            i++;
        }
    }
}