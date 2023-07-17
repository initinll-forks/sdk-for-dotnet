using Appwrite.Core.Models;

using Refit;

namespace Appwrite.Core.Apis;

internal interface IDatabases
{
    [Post("/databases")]
    Task<Database> Create([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Get("/databases")]
    Task<DatabaseList> List([Query] IDictionary<string, object>? queryParameters = null, CancellationToken cancellationToken = default);
}
