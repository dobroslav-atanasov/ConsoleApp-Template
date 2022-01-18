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
            Console.WriteLine("Please enter project directory: ");
            directorypath = Console.ReadLine();
        }
        
        Console.WriteLine("Please enter project old name: ");
        var projectOldName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(projectOldName))
        {
            Console.WriteLine("Please enter project old name: ");
            projectOldName = Console.ReadLine();
        }

        Console.WriteLine("Please enter project new name: ");
        var projectNewName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(projectNewName))
        {
            Console.WriteLine("Please enter project new name: ");
            projectNewName = Console.ReadLine();
        }

        StartRenameDirectories(directorypath, projectOldName, projectNewName);

        Console.WriteLine("Project renamer end!");
    }

    private static void StartRenameDirectories(string directorypath, string projectOldName, string projectNewName)
    {
        Console.WriteLine("Start rename directories...");



        Console.WriteLine("End rename directories");
    }
}