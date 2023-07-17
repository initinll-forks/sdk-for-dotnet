﻿using Appwrite.Core.Models;

using Refit;

namespace Appwrite.Core.Apis;

internal interface IDatabases
{
    [Post("/databases")]
    Task<Database> Create([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Get("/databases")]
    Task<DatabaseList> List([Query] IDictionary<string, object>? queryParameters = null, CancellationToken cancellationToken = default);

    [Get("/databases/{databaseId}")]
    Task<Database> Get(string databaseId, CancellationToken cancellationToken = default);

    [Put("/databases/{databaseId}")]
    Task<Database> Update(string databaseId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);
}
