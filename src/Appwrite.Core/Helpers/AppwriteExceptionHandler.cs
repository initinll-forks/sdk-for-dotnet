using System.Text.Json;

namespace Appwrite.Core.Helpers;

internal class AppwriteExceptionHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);
        var statusCode = (int)response.StatusCode;

        if (statusCode >= 400)
        {
            var contentType = response.Content.Headers
                .GetValues("Content-Type")
                .FirstOrDefault() ?? string.Empty;

            var isJson = contentType.Contains("application/json");
            var message = await response.Content.ReadAsStringAsync();

            if (isJson)
            {
                message = JsonDocument
                    .Parse(message)
                    .RootElement
                    .GetProperty("message")
                    .GetString();
            }

            throw new AppwriteException(message, statusCode);
        }

        return response;
    }
}
