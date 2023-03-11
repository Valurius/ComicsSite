namespace ComicsAPI.Models
{
    public class Response
    {
        public Response(string message, bool result, object value)
        {
            Message = message;
            Result = result;
            Value = value;
        }
        public Response(string message, bool result)
        {
            Message = message;
            Result = result;
        }

        public string Message { get; set; } = null!;
        public bool Result { get; set; }
        public object? Value { get; set; }
    }
}
