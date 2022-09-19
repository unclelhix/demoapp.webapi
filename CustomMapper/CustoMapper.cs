using DemoApplication.WebAPI.Shared.Attributes;

namespace DemoApplication.WebAPI.CustomMapper
{
    public class CustoMapper : ICustomMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
            where TSource : class, new()
            where TDestination : class, new()
        {
            TDestination targetItem = Activator.CreateInstance<TDestination>();

            var destinationProps = typeof(TDestination).GetProperties();

            var sourceProps = typeof(TSource).GetProperties();

            foreach (var prop in destinationProps)
            {
                var attribute = prop.GetCustomAttributes(false);
                var transportColumn = attribute.FirstOrDefault(p => p.GetType() == typeof(DbColumnAttribute));
                var transportEntityColumn = transportColumn as DbColumnAttribute;

                if (transportEntityColumn != null)
                {
                    foreach (var targetProp in sourceProps)
                    if (transportEntityColumn.Name == targetProp.Name) prop.SetValue(targetItem, targetProp.GetValue(source));
                                          
                }
            }
            return targetItem;
        }
    }
}
