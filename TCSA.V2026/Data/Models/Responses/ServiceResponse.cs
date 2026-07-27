namespace TCSA.V2026.Data.Models.Responses;

// TODO Consolidate this with Base Response
public class ServiceResponse
{
    public bool IsSuccessful { get; set; }
    public string Message { get; set; } = string.Empty;
}

public sealed class ServiceResponse<T> : ServiceResponse
{
    public T? Data { get; set; }
}