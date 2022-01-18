namespace ProjectRenamer;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Project renamer start!");
        
        Console.Write("Please enter project directory: ");
        var directorypath = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(directorypath))
        {
            Console.Write("Please enter project directory: ");
            directorypath = Console.ReadLine();
        }
        
        Console.Write("Please enter project old name: ");
        var projectOldName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(projectOldName))
        {
            Console.Write("Please enter project old name: ");
            projectOldName = Console.ReadLine();
        }

        Console.Write("Please enter project new name: ");
        var projectNewName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(projectNewName))
        {
            Console.Write("Please enter project new name: ");
            projectNewName = Console.ReadLine();
        }

        Console.WriteLine("Start rename directories...");
        StartRenameDirectories(directorypath, projectOldName, projectNewName);
        Console.WriteLine("End rename directories.");

        Console.WriteLine("Project renamer end!");
    }

    private static void StartRenameDirectories(string directorypath, string projectOldName, string projectNewName)
    {
        var directories = Directory.GetDirectories(directorypath);
        foreach (var directory in directories)
        {
        }
    }
}