namespace ConsoleAppTemplate.Services.Mapper;

using System.Linq.Expressions;

using AutoMapper.QueryableExtensions;

public static class QueryableMapExtensions
{
    public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
    {
        if (source != null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.ProjectTo(AutoMapperConfiguration.MapperInstance.ConfigurationProvider, null, membersToExpand);
    }

    public static IQueryable<TDestination> To<TDestination>(this IQueryable source, object parameters)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return source.ProjectTo<TDestination>(AutoMapperConfiguration.MapperInstance.ConfigurationProvider, parameters);
    }
}