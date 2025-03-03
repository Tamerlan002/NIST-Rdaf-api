namespace RDaF.Api.Infrastructure
{
    public class DeveloperException
    {
        public string Message { get; set; }
        public DeveloperException InnerException { get; set; }
    }
}
