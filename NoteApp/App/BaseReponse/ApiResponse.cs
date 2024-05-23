namespace NoteApp.App.BaseReponse
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public ApiResponse(T data, string message, int status)
        {
            Data = data;
            Message = message;
            StatusCode = status;
        }
    }

}
