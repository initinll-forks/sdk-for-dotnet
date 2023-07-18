using Appwrite.Core.Models;

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

    [Delete("/databases/{databaseId}")]
    Task Delete(string databaseId, CancellationToken cancellationToken = default);

    [Post("/databases/{databaseId}/collections")]
    Task<Collection> CreateCollection(string databaseId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Get("/databases/{databaseId}/collections")]
    Task<CollectionList> ListCollections(string databaseId, [Query] IDictionary<string, object>? queryParameters = null, CancellationToken cancellationToken = default);

    [Get("/databases/{databaseId}/collections/{collectionId}")]
    Task<Collection> GetCollection(string databaseId, string collectionId, CancellationToken cancellationToken = default);

    [Put("/databases/{databaseId}/collections/{collectionId}")]
    Task<Collection> UpdateCollection(string databaseId, string collectionId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Delete("/databases/{databaseId}/collections/{collectionId}")]
    Task DeleteCollection(string databaseId, string collectionId, CancellationToken cancellationToken = default);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/string")]
    Task<AttributeString> CreateStringAttribute(string databaseId, string collectionId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/email")]
    Task<AttributeEmail> CreateEmailAttribute(string databaseId, string collectionId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/enum")]
    Task<AttributeEnum> CreateEnumAttribute(string databaseId, string collectionId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/ip")]
    Task<AttributeIp> CreateIpAttribute(string databaseId, string collectionId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/url")]
    Task<AttributeUrl> CreateUrlAttribute(string databaseId, string collectionId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/integer")]
    Task<AttributeInteger> CreateIntegerAttribute(string databaseId, string collectionId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/float")]
    Task<AttributeFloat> CreateFloatAttribute(string databaseId, string collectionId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/boolean")]
    Task<AttributeBoolean> CreateBooleanAttribute(string databaseId, string collectionId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/datetime")]
    Task<AttributeDatetime> CreateDatetimeAttribute(string databaseId, string collectionId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Get("/databases/{databaseId}/collections/{collectionId}/attributes")]
    Task<AttributeList> ListAttributes(string databaseId, string collectionId, CancellationToken cancellationToken = default);

    [Get("/databases/{databaseId}/collections/{collectionId}/attributes/{key}")]
    Task<object> GetAttribute(string databaseId, string collectionId, string key, CancellationToken cancellationToken = default);

    [Delete("/databases/{databaseId}/collections/{collectionId}/attributes/{key}")]
    Task DeleteAttribute(string databaseId, string collectionId, string key, CancellationToken cancellationToken = default);

    [Post("/databases/{databaseId}/collections/{collectionId}/indexes")]
    Task<Models.Index> CreateIndex(string databaseId, string collectionId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Get("/databases/{databaseId}/collections/{collectionId}/indexes")]
    Task<IndexList> ListIndexes(string databaseId, string collectionId, CancellationToken cancellationToken = default);

    [Get("/databases/{databaseId}/collections/{collectionId}/indexes/{key}")]
    Task<Models.Index> GetIndex(string databaseId, string collectionId, string key, CancellationToken cancellationToken = default);

    [Delete("/databases/{databaseId}/collections/{collectionId}/indexes/{key}")]
    Task DeleteIndex(string databaseId, string collectionId, string key, CancellationToken cancellationToken = default);

    [Post("/databases/{databaseId}/collections/{collectionId}/documents")]
    Task<Document> CreateDocument(string databaseId, string collectionId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Get("/databases/{databaseId}/collections/{collectionId}/documents")]
    Task<DocumentList> ListDocuments(string databaseId, string collectionId, [Query] IDictionary<string, object>? queryParameters = null, CancellationToken cancellationToken = default);

    [Get("/databases/{databaseId}/collections/{collectionId}/documents/{documentId}")]
    Task<Document> GetDocument(string databaseId, string collectionId, string documentId, CancellationToken cancellationToken = default);

    [Patch("/databases/{databaseId}/collections/{collectionId}/documents/{documentId}")]
    Task<Document> UpdateDocument(string databaseId, string collectionId, string documentId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object>? bodyParameters = null, CancellationToken cancellationToken = default);

    [Delete("/databases/{databaseId}/collections/{collectionId}/documents/{documentId}")]
    Task DeleteDocument(string databaseId, string collectionId, string documentId, CancellationToken cancellationToken = default);
}
