using System.ComponentModel.DataAnnotations;

public class University
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    public List<Student> Students { get; set; }
}