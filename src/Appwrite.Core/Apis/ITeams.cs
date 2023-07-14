﻿using Appwrite.Core.Models;

using Refit;

namespace Appwrite.Core.Apis;

internal interface ITeams
{
    [Post("/teams")]
    Task<Team> Create([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters = null, CancellationToken cancellationToken = default);
}
