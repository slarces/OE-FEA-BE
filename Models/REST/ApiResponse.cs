namespace Flag_Explorer_App.Models.REST
{
    public class ApiResponse<T>(int statusCode, string statusResponse, T? data = default)
    {
        public int StatusCode { get; set; } = statusCode;

        public string StatusResponse { get; set; } = statusResponse;

        public T? Data { get; set; } = data;

        public static ApiResponse<T> Success(T data, int statusCode = 200)
        {
            return new ApiResponse<T>(statusCode, "Success", data);
        }

        public static ApiResponse<T> Error(string message, int statusCode = 400)
        {
            return new ApiResponse<T>(statusCode, message, default);
        }
    }
}
