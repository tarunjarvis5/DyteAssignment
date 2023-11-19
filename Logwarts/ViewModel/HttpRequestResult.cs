namespace Logwarts.ViewModel
{
    /// <summary>
    /// Represents the result of an HTTP request.
    /// </summary>
    public class HttpRequestResult
    {
        /// <summary>
        /// Indicates whether the HTTP request was successful.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Provides a status message related to the HTTP request.
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the HttpRequestResult class.
        /// </summary>
        public HttpRequestResult()
        {
            // Default constructor
        }
    }
}