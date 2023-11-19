using Logwarts.Common;
using Logwarts.DataProvider;
using Logwarts.Model;
using Logwarts.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Logwarts.Controllers
{
    /// <summary>
    /// Exposes endpoints for managing and retrieving log entries.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        /// <summary>
        /// The AppDataProvider instance used for interacting with log data.
        /// </summary>
        private readonly IAppDataProvider _appDataProvider;

        /// <summary>
        /// Initializes a new instance of the AppController class.
        /// </summary>
        /// <param name="appDataProvider">The AppDataProvider instance to be used.</param>
        public AppController(IAppDataProvider appDataProvider)
        {
            _appDataProvider = appDataProvider;
        }

        /// <summary>
        /// Endpoint for ingesting a new log entry into the database.
        /// </summary>
        /// <param name="logEntry">The log entry to be ingested.</param>
        /// <returns>An HTTP request result indicating success or failure.</returns>
        [HttpPost("ingest")]
        public HttpRequestResult IngestLog([FromBody] LogEntryModel logEntry)
        {
            try
            {
                // Attempt to insert the log entry into the database
                if (_appDataProvider.InsertLog(logEntry))
                {
                    // Log insertion successful
                    return new HttpRequestResult() { IsSuccess = true, StatusMessage = MessageText.LogInsertSuccessMessage };
                }
                else
                {
                    // Log insertion failed
                    return new HttpRequestResult() { IsSuccess = false, StatusMessage = MessageText.LogInsertErrorMessage };
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the operation
                return new HttpRequestResult() { IsSuccess = false, StatusMessage = MessageText.LogInsertErrorMessage };
            }
        }

        /// <summary>
        /// Endpoint for retrieving filtered log entries based on the provided filter criteria.
        /// </summary>
        /// <param name="filterModel">The filter criteria to be applied.</param>
        /// <returns>A list of filtered log entries.</returns>
        [HttpPost("getfiltered")]
        public List<LogEntryModel> GetFiltered(FilterModel filterModel)
        {
            try
            {
                // Retrieve filtered log entries from the data provider
                return _appDataProvider.GetFilteredRecord(filterModel);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the operation
                return new List<LogEntryModel>();
            }
        }

        /// <summary>
        /// Endpoint for retrieving all log entries from the database.
        /// </summary>
        /// <returns>A list of all log entries.</returns>
        [HttpGet("getall")]
        public List<LogEntryModel> GetAll()
        {
            try
            {
                // Retrieve all log entries from the data provider
                return _appDataProvider.GetAllLogRecord();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the operation
                return new List<LogEntryModel>();
            }
        }
    }
}