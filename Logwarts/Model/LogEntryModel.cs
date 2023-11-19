using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Logwarts.Model
{
    /// <summary>
    /// Represents a log entry model in the database.
    /// </summary>
    public class LogEntryModel
    {
        /// <summary>
        /// The unique identifier for the log entry.
        /// </summary>
        [Key]
        public int LogEntryId { get; set; }

        /// <summary>
        /// The severity level of the log entry.
        /// </summary>
        public string level { get; set; }

        /// <summary>
        /// The message content of the log entry.
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// The resource ID associated with the log entry.
        /// </summary>
        public string resourceId { get; set; }

        /// <summary>
        /// The timestamp of the log entry.
        /// </summary>
        public DateTime timestamp { get; set; }

        /// <summary>
        /// The trace ID of the log entry.
        /// </summary>
        public string traceId { get; set; }

        /// <summary>
        /// The span ID of the log entry.
        /// </summary>
        public string spanId { get; set; }

        /// <summary>
        /// The commit hash associated with the log entry.
        /// </summary>
        public string commit { get; set; }

        /// <summary>
        /// The foreign key referencing the associated metadata record.
        /// </summary>
        public int MetaDataId { get; set; }

        /// <summary>
        /// The associated metadata object containing additional details about the log entry.
        /// </summary>
        [ForeignKey("MetaDataId")]
        public MetaDataModel metadata { get; set; }
    }
}