namespace ConsoleAppTemplate.Services.Mapper;

using System.Reflection;

public static class AutoMapperConfiguration
{
    public static void ConfigureMappings(params Assembly[] assemblies)
    {
        var types = assemblies
            .SelectMany(a => a.GetExportedTypes())
            .ToList();

        ;
    }
}