namespace BookReader.Infrastructure.Logging.AbstractionModels
{
    public class LogBase
    {
        public string LogType { get; set; }
        
        public string Name { get; set; }
        
        public string Method { get; set; }

        public string Message { get; set; }
    }
}