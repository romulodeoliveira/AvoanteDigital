namespace AvoanteDigital.Api.Models.Responses;

public class ApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}