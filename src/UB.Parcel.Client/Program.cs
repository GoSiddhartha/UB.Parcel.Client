using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UB.Parcel.Client.User;
using System.IO;
using System;
using System.Configuration;

namespace UB.Parcel.Client
{
    public class Program
    {
        public static IConfigurationRoot configuration;
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var user = serviceProvider.GetService<IUserService>();
            var requestbody = new User.UserDomain.LoginRequest { username = "assignment-test@ubsend.com", password = " p0DrmE)E+BQH$]KasMSb" };
            var config = configuration.GetSection("Config").Get<Config>();
            user.GetUserLogin(requestbody, config);
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Build configuration
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"))).FullName)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration)
            .AddSingleton<IUserService, UserService>();
        }

    }
}
