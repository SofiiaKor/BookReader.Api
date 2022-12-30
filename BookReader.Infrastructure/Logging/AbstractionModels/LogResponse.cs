using System.Collections.Generic;

namespace BookReader.Infrastructure.Logging.AbstractionModels
{
    public class LogResponse : LogBase
    {
        public int? ResponseCode { get; set; }
        
        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                ["LogType"] = LogType,
                ["Name"] = Name,
                ["Method"] = Method,
                ["Message"] = Message,
                ["ResponseCode"] = ResponseCode
            };
        }
    }
}