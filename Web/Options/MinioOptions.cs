// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Web.Options;

public sealed class MinioOptions
{
    public required string AccessKey { get; init; }
    
    public required string SecretKey { get; init; }
    
    public required string Endpoint { get; init; }

    public required bool Ssl { get; init; }
}