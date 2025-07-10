using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Student
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    public DateOnly Birthday { get; set; }

    [MaxLength(150)]
    public string Skills { get; set; }

    public int UniversityId { get; set; }
    
    public University University { get; set; }
}