using Logwarts.DataProvider;

namespace Logwarts
{
    /// <summary>
    /// Registers services and dependencies in the application's dependency injection container.
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// Registers the necessary data access services and dependencies.
        /// </summary>
        /// <param name="webApplicationBuilder">The WebApplicationBuilder instance.</param>
        public void Service(WebApplicationBuilder webApplicationBuilder)
        {
            // Register the DataContext service for database access.
            webApplicationBuilder.Services.AddTransient<IDataContext, DataContext>();

            // Register the AppDataProvider service for data manipulation logic.
            webApplicationBuilder.Services.AddTransient<IAppDataProvider, AppDataProvider>();
        }
    }
}