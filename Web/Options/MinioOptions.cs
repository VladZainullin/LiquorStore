// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Web.Options;

internal sealed class MinioOptions
{
    public required bool Ssl { get; init; }

    public required string Endpoint { get; init; }
    
    public required string AccessKey { get; init; }
    
    public required string SecretKey { get; init; }
}