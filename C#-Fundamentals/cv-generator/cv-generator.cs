using System.Collections.Generic;
using System.Text;
class CVGenerator
{
    static void Main(string[] args)
    {
        // CV information
        string name;
        string dateOfBirth;
        string education;
        string yearsOfExperience;
        string[] skills = {};

        // gather the input from user
        Console.WriteLine("Enter your name: ");
        name = Console.ReadLine();

        Console.WriteLine("Enter your birthday: ");
        dateOfBirth = Console.ReadLine();

        Console.WriteLine("Whats the name of your university ?");
        education = Console.ReadLine();

        Console.WriteLine("How many years of experience do you have ?");
        yearsOfExperience = Console.ReadLine();

        Console.WriteLine("Enter your skills with comma between each skill");
        string buffer = Console.ReadLine();
        if (!string.IsNullOrEmpty(buffer))
        {
            skills = buffer.Split(',');
        }

        // create the file path
        string path = string.Concat(name, ".txt");

        // construct the entire cv as a single string
        string cv = createCV(name, dateOfBirth, education, yearsOfExperience);
        File.WriteAllText(path, cv);
        Console.WriteLine($"{name}'s CV is saved in {path}");

        string createCV(string? name, string? dateOfBirth, string? education, string? yearsOfExperience)
        {
            StringBuilder cv = new StringBuilder();
            cv.Append($"Name: {name}\nBirth Day: {dateOfBirth}\nEducation: {education}\nHas {yearsOfExperience} year(s) of experience\nSkills:\n");
            foreach (string skill in skills) { cv.Append($"- {skill.Trim()}\n"); }
            return cv.ToString();
        }

    }


}
