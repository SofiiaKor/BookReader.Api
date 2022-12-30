using System.Collections.Generic;

namespace BookReader.Infrastructure.Logging.AbstractionModels
{
    public class LogError : LogBase
    {
        public int? ResponseCode { get; set; }
        
        public string Detail { get; set; }
        
        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                ["LogType"] = LogType,
                ["Name"] = Name,
                ["Method"] = Method,
                ["Message"] = Message,
                ["Detail"] = Detail,
                ["ResponseCode"] = ResponseCode
            };
        }
    }
}