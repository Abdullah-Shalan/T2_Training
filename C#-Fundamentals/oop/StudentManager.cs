class StudentManager
{
    private int studentCount = 0;
    public int totalStudents
    {
        get { return studentCount; }
    }

    public void addStudent()
    {
        studentCount += 1;
        Console.WriteLine("Student added successfully!");
    }
}