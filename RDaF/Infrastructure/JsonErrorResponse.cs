namespace RDaF.Api.Infrastructure
{
    public class JsonErrorResponse
    {
        public JsonErrorResponse(string errorType, string message, string requestId, object developerMessage)
        {
            ErrorType = errorType;
            Message = message;
            RequestId = requestId;
            DeveloperMessage = developerMessage;
        }

        public string ErrorType { get; }

        public string Message { get; }
        public string RequestId { get; }

        public object DeveloperMessage { get; }
    }
}
