

do
{
    // parse numbers
    int firstNum = parseNum("First");
    int secondNum = parseNum("Second");

    // calculate the output
    int output = parseOperation(firstNum, secondNum);
} while (true);


int parseNum(string num)
{
    while (true)
    {
        try
        {
            Console.WriteLine("Enter " + num + " Number: ");
            return int.Parse(Console.ReadLine());

        }
        catch (System.Exception)
        {
            Console.WriteLine("Error, Please enter a number!");
        }
    }
}

// Parse an operation and return the calculation
int parseOperation(int firstNum, int SecondNum)
{
    char[] operations = { '+', '-', '*', '/' };
    char operation;
    int output;

    while (true)
    {
        Console.WriteLine("Choose operation [ + , - , * , / ]:");
        string buffer = Console.ReadLine();

        if (!string.IsNullOrEmpty(buffer) && operations.Contains(buffer[0]))
        {
            operation = buffer[0];
            break;
        }

        Console.WriteLine("please enter a valid operation");
    }

    switch (operation)
    {
        case '+':
            output = firstNum + SecondNum;
            Console.WriteLine(firstNum + " + " + SecondNum + " = " + output);
            return output;
            break;
        case '-':
            output = firstNum - SecondNum;
            Console.WriteLine(firstNum + " - " + SecondNum + " = " + output);
            return output;
            break;
        case '*':
            output = firstNum * SecondNum;
            Console.WriteLine(firstNum + " * " + SecondNum + " = " + output);
            return output;
            break;
        case '/':
            output = firstNum / SecondNum;
            Console.WriteLine(firstNum + " / " + SecondNum + " = " + output);
            return output;
            break;
    }

    return -1;
}
