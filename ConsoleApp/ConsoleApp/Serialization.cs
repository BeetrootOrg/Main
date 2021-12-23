using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MessagePack;

namespace ConsoleApp;

internal interface ISerializer
{
    ValueTask<MemoryStream> Serialize<T>(T value, CancellationToken cancellationToken = default);
}

internal interface IDeserializer
{
    ValueTask<T> Deserialize<T>(Stream stream, CancellationToken cancellationToken = default);
}

internal class MsgPackSerializer : ISerializer, IDeserializer
{
    public async ValueTask<MemoryStream> Serialize<T>(T value, CancellationToken cancellationToken = default)
    {
        var stream = new MemoryStream();
        await MessagePackSerializer.SerializeAsync(stream, value, cancellationToken: cancellationToken);
        return stream;
    }
    
    public ValueTask<T> Deserialize<T>(Stream stream, CancellationToken cancellationToken = default) => 
        MessagePackSerializer.DeserializeAsync<T>(stream, cancellationToken: cancellationToken);
}