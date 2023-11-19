using Logwarts.Model;
using Microsoft.EntityFrameworkCore;

namespace Logwarts.DataProvider
{
    /// <summary>
    /// Represents the data provider responsible for interacting with the database.
    /// </summary>
    public class AppDataProvider : IAppDataProvider
    {
        /// <summary>
        /// The data context instance used for interacting with the database.
        /// </summary>
        private readonly IDataContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the AppDataProvider class.
        /// </summary>
        /// <param name="dataContext">The data context instance to be used.</param>
        public AppDataProvider(IDataContext dataContext)
        {
            _dbContext = dataContext;
        }

        /// <summary>
        /// Inserts a new log entry into the database.
        /// </summary>
        /// <param name="logEntry">The log entry to be inserted.</param>
        /// <returns>True if the log entry was inserted successfully, false otherwise.</returns>
        public bool InsertLog(LogEntryModel logEntry)
        {
            try
            {
                // Create a new instance of the data context
                IDataContext dbcontextInstance = _dbContext.CreateInstance();

                // Add the log entry to the database
                dbcontextInstance.LogEntryModel.Add(logEntry);

                // Save the changes to the database
                dbcontextInstance.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Log the error and return false
                return false;
            }
        }

        /// <summary>
        /// Retrieves all log records from the database.
        /// </summary>
        /// <returns>A list of all log records.</returns>
        public List<LogEntryModel> GetAllLogRecord()
        {
            try
            {
                // Create a new instance of the data context
                IDataContext dbcontextInstance = _dbContext.CreateInstance();

                // Query the database for all log records and include their associated metadata
                return dbcontextInstance.LogEntryModel.Include(o => o.metadata).ToList();
            }
            catch (Exception ex)
            {
                // Log the error and return an empty list
                return new List<LogEntryModel>();
            }
        }


        /// <summary>
        /// Retrieves all filtered log records from the database.
        /// </summary>
        /// <returns>A list of all filtered log records.</returns>
        public List<LogEntryModel> GetFilteredRecord(FilterModel filterModel)
        {
            try
            {
                // Create a new instance of the data context
                IDataContext dbcontextInstance = _dbContext.CreateInstance();

                // Query the database for all log records and include their associated metadata
                var filteredRecords = dbcontextInstance.LogEntryModel.Include(o => o.metadata).ToList();

                // Apply case-insensitive contains filtering if the checkContains flag is set
                if (filterModel.checkContains)
                {
                    // Filter log records based on level
                    if (!string.IsNullOrEmpty(filterModel.level))
                    {
                        filteredRecords = filteredRecords.Where(o => o.level.Contains(filterModel.level, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    // Filter log records based on commit
                    if (!string.IsNullOrEmpty(filterModel.commit))
                    {
                        filteredRecords = filteredRecords.Where(o => o.commit.Contains(filterModel.commit, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    // Filter log records based on message
                    if (!string.IsNullOrEmpty(filterModel.message))
                    {
                        filteredRecords = filteredRecords.Where(o => o.message.Contains(filterModel.message, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    // Filter log records based on parent resource ID
                    if (!string.IsNullOrEmpty(filterModel.metadata.parentResourceId))
                    {
                        filteredRecords = filteredRecords.Where(o => o.metadata.parentResourceId.Contains(filterModel.metadata.parentResourceId, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    // Filter log records based on resource ID
                    if (!string.IsNullOrEmpty(filterModel.resourceId))
                    {
                        filteredRecords = filteredRecords.Where(o => o.resourceId.Contains(filterModel.resourceId, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    // Filter log records based on span ID
                    if (!string.IsNullOrEmpty(filterModel.spanId))
                    {
                        filteredRecords = filteredRecords.Where(o => o.spanId.Contains(filterModel.spanId, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    // Filter log records based on trace ID
                    if (!string.IsNullOrEmpty(filterModel.traceId))
                    {
                        filteredRecords = filteredRecords.Where(o => o.traceId.Contains(filterModel.traceId, StringComparison.OrdinalIgnoreCase)).ToList();
                    }
                }

                // Apply timestamp filtering if either timestamp property is not the default DateTime value
                if (filterModel.timestamp != new DateTime() || filterModel.totimestamp != new DateTime())
                {
                    filteredRecords = filteredRecords.Where(o => o.timestamp >= filterModel.timestamp && o.timestamp <= filterModel.totimestamp).ToList();
                }

                // Return the filtered log records or an empty list if no records were found
                return filteredRecords.Count() == 0 ? new List<LogEntryModel>() : filteredRecords;
            }
            catch (Exception ex)
            {
                // Log the error and return an empty list
                return new List<LogEntryModel>();
            }
        }
    }
}
