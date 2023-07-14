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
    var teams = new Teams(client);

    CancellationTokenSource newSource = new CancellationTokenSource();
    newSource.Cancel();

    var newTeam = await teams.Create("TestTeam-123", "test-team", null, newSource.Token);

    Console.WriteLine("Done !");
}
catch (TaskCanceledException ex)
{
    Console.WriteLine($"TaskCanceledException - {ex.Message}");
}
catch (AppwriteException ex)
{
    Console.WriteLine($"AppwriteException - {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Exception - {ex.Message}");
}