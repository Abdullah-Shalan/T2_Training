class EventExample
{
    // Declare delegate
    public delegate void delegateOddNumber();
    // Declare event
    public event delegateOddNumber? DelegateOddEvent;

    public void addition()
    {
        int num1 = 100;
        int num2 = 200;
        int res = num1 + num2;
        Console.WriteLine($"Total: {res}");
        if (res % 2 != 0)
        {
            // Raise the event
            DelegateOddEvent?.Invoke();
        }

    }
    


}