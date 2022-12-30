using System.Collections.Generic;

namespace BookReader.Infrastructure.Logging.AbstractionModels
{
    public class LogRequest : LogBase
    {
        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                ["LogType"] = LogType,
                ["Name"] = Name,
                ["Method"] = Method,
                ["Message"] = Message
            };
        }
    }
}