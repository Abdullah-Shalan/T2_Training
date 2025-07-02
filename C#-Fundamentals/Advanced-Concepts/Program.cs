using System.Linq.Expressions;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        // Test Anonymous Type
        // AnonymousTypes.DisplayInfo();

        // Test Event Example
        // EventExample events = new EventExample();
        // events.DelegateOddEvent += new EventExample.delegateOddNumber(EventMessage);

        // events.addition();

        // static void EventMessage()
        // {
        //     Console.WriteLine($"Event Executed : Odd Number");
        // }

        // Test Anonymous Methods
        // AnonymousTypes.AnonymousMethods();


        // // Expression Lambda
        // int[] numbers = new int[] { 2, 4, 5, 3, 23, 1, 5 };
        // int count = numbers.Count(x => x == 5);
        // Console.WriteLine($"{count}");

        // // Statement Lambda
        // List<int> numList = new List<int> { 2, 4, 2, 4, 5, 3 };
        // int countList = numList.Count(x => { return x == 5; });
        // Console.WriteLine($"{countList}");

        // Expression Tree
        Func<string, string, string> stringJoin = (str1, str2) => string.Concat(str1, str2);
        Expression<Func<string, string, string>> stringJoinExpr = (str1, str2) => string.Concat(str1, str2);

        var func = stringJoinExpr.Compile();
        var result = func("Hello", " World");
        Console.WriteLine($"{result}");
        

    }   
}