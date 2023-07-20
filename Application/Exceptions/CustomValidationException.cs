namespace Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public List<string> Errors { get; set; }
        public string CustomMessage { get; set; }

        public CustomValidationException(List<string> errors, string customMessage) : base(customMessage)
        {
            Errors = errors;
            CustomMessage = customMessage;
        }
    }
}
