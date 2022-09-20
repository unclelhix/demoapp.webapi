namespace DemoApplication.WebAPI.CustomMapperService
{
    public interface ICustomMapper
    {
        /// <summary>
        /// Surigao Mapper
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        TDestination Map<TSource, TDestination>(TSource source) 
            where TDestination : class, new() where TSource : class, new();
    }

}
