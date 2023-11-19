using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logwarts.Model
{
    /// <summary>
    /// Represents a metadata model associated with a log entry.
    /// </summary>
    public class MetaDataModel
    {
        /// <summary>
        /// The unique identifier for the metadata record.
        /// </summary>
        [Key]
        public int MetaDataId { get; set; }

        /// <summary>
        /// The identifier of the parent resource associated with the log entry.
        /// </summary>
        public string parentResourceId { get; set; }
    }
}
