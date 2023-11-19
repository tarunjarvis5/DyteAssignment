using Logwarts.Model;
using Microsoft.EntityFrameworkCore;

namespace Logwarts
{
    public interface IDataContext
    {
        public DbSet<LogEntryModel> LogEntryModel { get; set; }
        public DbSet<MetaDataModel> MetaDataModel { get; set; }
        public IDataContext CreateInstance();

        public int SaveChanges();

    }
}
