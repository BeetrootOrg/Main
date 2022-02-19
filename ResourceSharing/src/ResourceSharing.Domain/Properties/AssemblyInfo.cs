using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("ResourceSharing.UnitTests")]
[assembly:InternalsVisibleTo("ResourceSharing.IntegrationTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}