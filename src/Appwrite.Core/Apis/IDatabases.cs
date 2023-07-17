using Appwrite.Core.Models;

using Refit;

namespace Appwrite.Core.Apis;

internal interface IDatabases
{
    [Post("/databases")]
    Task<Database> Create([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters = null, CancellationToken cancellationToken = default);
}
