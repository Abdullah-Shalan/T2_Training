class Circle : Shape
{
    public Circle(double r) : base(r) { }
    public override void printArea()
    {
        Console.WriteLine($"Circle with radius {radius} Area is {3.14 * radius * radius}");        
    }

    public void test()
    {
        Console.WriteLine($"Height: {height}");
    }
}