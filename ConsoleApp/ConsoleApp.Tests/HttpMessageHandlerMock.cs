using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.Tests;

internal class HttpMessageHandlerMock : HttpMessageHandler
{
    private readonly IDictionary<HttpRequestMessage, HttpResponseMessage> _dictionary;

    public HttpMessageHandlerMock()
    {
        _dictionary = new Dictionary<HttpRequestMessage, HttpResponseMessage>();
    }

    public void Setup(HttpRequestMessage request, HttpResponseMessage response) => 
        _dictionary[request] = response;


    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var key = _dictionary.Keys.FirstOrDefault(x =>
            x.Method == request.Method && x.RequestUri == request.RequestUri);

        if (key != null)
        {
            return Task.FromResult(_dictionary[key]);
        }

        throw new ArgumentException(nameof(request));
    }
}