using System.Text.Json.Serialization;

namespace AppMovil.Models.Implements.Auth;

public sealed class LoginResponseDto
{
    [JsonPropertyName("isSuccess")]
    public bool IsSuccess { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
