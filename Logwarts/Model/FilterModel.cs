using System.ComponentModel.DataAnnotations.Schema;

namespace Logwarts.Model
{
    public class FilterModel
    {
        public int LogEntryId { get; set; }
        public string level { get; set; }
        public string message { get; set; }
        public string resourceId { get; set; }
        public DateTime timestamp { get; set; } 
        public string traceId { get; set; }
        public string spanId { get; set; }
        public string commit { get; set; }

        public MetaDataModel metadata { get; set; }

        public DateTime totimestamp { get; set; }

        public bool checkContains { get; set; }


    }
}
