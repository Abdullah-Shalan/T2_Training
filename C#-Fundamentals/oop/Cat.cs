class Cat : Animal
{
    public Cat(string name) : base(name) { }
    public void Speak()
    {
        Console.WriteLine($"{name} says Meow!");
    }
}