using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace WorkTitle.Telegramm.Configuration
{
    public static class ConfigurationExtensions
    {
        public static T GetConfiguration<T>(this IServiceProvider serviceProvider)
            where T : class
        {
            var o = serviceProvider.GetService<IOptions<T>>() ??
                throw new ArgumentNullException(nameof(T));

            return o.Value;
        }
    }
}
