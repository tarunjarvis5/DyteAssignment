using Logwarts.Model;

namespace Logwarts.DataProvider
{
    public interface IAppDataProvider
    {
        public bool InsertLog(LogEntryModel logEntry);

        public List<LogEntryModel> GetAllLogRecord();

        public List<LogEntryModel> GetFilteredRecord(FilterModel filterModel);


    }
}
