namespace Shared;

public record Envelope
{
    public object? Result { get; }
    public Errors? ErrorsList { get; }
    public DateTime Timestamp { get; }
    public bool IsSuccess { get; }

    [JsonConstructor]
    public Envelope(object? result, Errors? errors, bool isSuccess = true)
    {

        Result = result;
        Timestamp = DateTime.UtcNow;
        ErrorsList = errors;
        IsSuccess = isSuccess;

    }

    public static Envelope Ok(object? result = null)
        => new(result, null);

    public static Envelope Error(Errors errors)
        => new(null, errors, false);
}

public record Envelope<T>
{
    public T? Data { get; }
    public string? Message { get; }
    public DateTime Timestamp { get; }
    public bool IsSuccess { get; }

    public Envelope(T? data, string? message = null, bool isSuccess = true)
    {
        Data = data;
        Message = message;
        Timestamp = DateTime.UtcNow;
        IsSuccess = isSuccess;
    }

    public static Envelope<T> Ok(T data, string? message = null)
        => new(data, message);

    public static Envelope<T> Error(string? message)
        => new(default, message, false);
}