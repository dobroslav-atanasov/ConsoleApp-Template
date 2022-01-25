namespace ConsoleAppTemplate.Services.Mapper;

using System.Collections.Generic;
using System.Reflection;

using AutoMapper;

using Common.Constants;
using Interfaces;
using Models;

public static class AutoMapperConfiguration
{
    public static IMapper MapperInstance { get; set; }

    public static void ConfigureMappings(params Assembly[] assemblies)
    {
        var types = assemblies
            .SelectMany(a => a.GetExportedTypes())
            .ToList();

        var mapperConfiguration = new MapperConfigurationExpression();

        mapperConfiguration.CreateProfile(GlobalConstants.REFLECTION_PROFILE, config =>
        {
            var fromMaps = GetFromMaps(types);
            foreach (var map in fromMaps)
            {
                config.CreateMap(map.Source, map.Destination);
            }

            var toMaps = GetToMaps(types);
            foreach (var map in toMaps)
            {
                config.CreateMap(map.Source, map.Destination);
            }

            var customMaps = GetCustomMaps(types);
            foreach (var map in customMaps)
            {
                map.CreateCustomMap(config);
            }
        });

        MapperInstance = new Mapper(new MapperConfiguration(mapperConfiguration));
    }   

    private static IEnumerable<MappingType> GetFromMaps(IEnumerable<Type> types)
    {
        var fromMaps = from t in types
                       from i in t.GetTypeInfo().GetInterfaces()
                       where i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) && !t.GetTypeInfo().IsAbstract && !t.GetTypeInfo().IsInterface
                       select new MappingType
                       {
                           Source = i.GetTypeInfo().GetGenericArguments()[0],
                           Destination = t,
                       };

        return fromMaps;
    }

    private static IEnumerable<MappingType> GetToMaps(IEnumerable<Type> types)
    {
        var toMaps = from t in types
                     from i in t.GetTypeInfo().GetInterfaces()
                     where i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>) && !t.GetTypeInfo().IsAbstract && !t.GetTypeInfo().IsInterface
                     select new MappingType
                     {
                         Source = t,
                         Destination = i.GetTypeInfo().GetGenericArguments()[0],
                     };

        return toMaps;
    }

    private static IEnumerable<ICustomMap> GetCustomMaps(IEnumerable<Type> types)
    {
        var customMaps = from t in types
                         from i in t.GetTypeInfo().GetInterfaces()
                         where typeof(ICustomMap).GetTypeInfo().IsAssignableFrom(t) && !t.GetTypeInfo().IsAbstract && !t.GetTypeInfo().IsInterface
                         select (ICustomMap)Activator.CreateInstance(t);

        return customMaps;
    }
}