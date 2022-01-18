using System.Text;

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

        Console.WriteLine("Start rename files...");
        StartRenameFiles(directorypath, projectOldName, projectNewName);
        Console.WriteLine("End rename files.");

        Console.WriteLine("Start rename file contents...");
        StartRenameFileContents(directorypath, projectOldName, projectNewName);
        Console.WriteLine("End rename file contents.");

        Console.WriteLine("Project renamer end!");
    }

    private static void StartRenameDirectories(string directorypath, string projectOldName, string projectNewName)
    {
        var directories = Directory.GetDirectories(directorypath);
        foreach (var directory in directories)
        {
            var newDirectoryName = directory.Replace(projectOldName, projectNewName);
            if (newDirectoryName != directory)
            {
                Directory.Move(directory, newDirectoryName);
            }            
        }

        directories = Directory.GetDirectories(directorypath);
        foreach (var directory in directories)
        {
            StartRenameDirectories(directory, projectOldName, projectNewName);

        }
    }

    private static void StartRenameFiles(string directorypath, string projectOldName, string projectNewName)
    {
        var files = Directory.GetFiles(directorypath);
        foreach (var file in files)
        {
            var newFileName = file.Replace(projectOldName, projectNewName);
            if (newFileName != file)
            {
                Directory.Move(file, newFileName);
            }
        }

        var directories = Directory.GetDirectories(directorypath);
        foreach (var directory in directories)
        {
            StartRenameFiles(directory, projectOldName, projectNewName);
        }
    }

    private static void StartRenameFileContents(string directoryPath, string projectOldName, string projectNewName)
    {
        var files = Directory.GetFiles(directoryPath);
        foreach (var file in files)
        {
            if (!file.EndsWith(".dll"))
            {
                var contents = File.ReadAllText(file);
                contents = contents.Replace(projectOldName, projectNewName);
                File.WriteAllText(file, contents, Encoding.UTF8);
            }
        }

        var directories = Directory.GetDirectories(directoryPath);
        foreach (var directory in directories)
        {
            StartRenameFileContents(directory, projectOldName, projectNewName);
        }
    }
}