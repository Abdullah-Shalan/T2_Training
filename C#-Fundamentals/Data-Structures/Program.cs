class Program
{
    static void Main(string[] args)
    {
        TreeNode root = new TreeNode(10);
        root.left = new TreeNode(2);

        Console.WriteLine($"{root.value}");
        Console.WriteLine($"{root.left.value}");
        
        
    }
}