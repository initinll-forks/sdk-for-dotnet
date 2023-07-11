using Appwrite.Core;
using Appwrite.Core.Services;

var endpoint = String.Empty;
var project = String.Empty;
var apikey = String.Empty;

var client = new Client()
    .SetEndpoint(endpoint)
    .SetProject(project)
    .SetKey(apikey);
try
{
    var account = new Account(client);
    var test = await account.UpdatePassword("test");
}
catch (Exception ex)
{
    Console.WriteLine($"Exception - {ex.Message}");
}