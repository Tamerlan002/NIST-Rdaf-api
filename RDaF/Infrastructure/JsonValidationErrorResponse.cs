namespace RDaF.Api.Infrastructure
{
    public class JsonValidationErrorResponse : JsonErrorResponse
    {

        public JsonValidationErrorResponse(string errorType, string message, string requestId, object developerMessage) : base(errorType,
           message, requestId, developerMessage)
        {
            Errors = new List<ValidationError>();
        }

        public List<ValidationError> Errors { get; }

    }
}
