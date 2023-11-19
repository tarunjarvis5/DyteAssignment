using Logwarts.Model;
using Microsoft.EntityFrameworkCore;
namespace Logwarts
{
    public class DataContext : DbContext, IDataContext
    {
        // Default constructor for the DataContext class.
        public DataContext()
        {

        }

        // Overloaded constructor for the DataContext class that accepts DbContextOptions as a parameter.
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Definition of the DbSet properties for the LogEntryModel and MetaDataModel classes.
        public DbSet<LogEntryModel> LogEntryModel { get; set; }
        public DbSet<MetaDataModel> MetaDataModel { get; set; }

        // Method to create a new instance of the DataContext class.
        public IDataContext CreateInstance()
        {
            return new DataContext(DbContextOptionsFactory.Get());
        }

        // Method to configure the DbContextOptions object. If the options object is not already configured, it uses the SQL Server connection string from the Common.Constant class.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(Common.Constant.ConnectionString);
            }
        }
    }

    // The DBContextConfigurer class is used to configure the DbContextOptionsBuilder object with a given connection string.
    public class DBContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DataContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }
    }

    // The DbContextOptionsFactory class is used to get a DbContextOptions object. It creates a new DbContextOptionsBuilder object, configures it using the DBContextConfigurer class, and then returns the options object.
    public class DbContextOptionsFactory
    {
        public static DbContextOptions<DataContext> Get()
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            DBContextConfigurer.Configure(builder, Logwarts.Common.Constant.ConnectionString);

            return builder.Options;
        }
    }
}