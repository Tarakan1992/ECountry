namespace IDS.Result
{
    public class ValidationError
    {
        public string Field { get; set; }

        public string Message { get; set; }

        public ValidationError(string filed, string message)
        {
            Field = filed;
            Message = message;
        }
    }
}
