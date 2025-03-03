namespace RDaF.Api.Infrastructure
{
    public class ValidationError
    {
        public ValidationError(string property, string errorMessage)
        {
            Property = property;
            ErrorMessage = errorMessage;
        }

        public string Property { get; }

        public string ErrorMessage { get; }
    }
}
