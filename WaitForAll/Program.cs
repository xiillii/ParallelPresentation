using WaitForAll;

Console.WriteLine("Hello, Edenred!");


var random  = new Random();
var listEntries = new List<int>();
var service = new JournalService();
var cts = new CancellationTokenSource();
var ct = cts.Token;

for (var i = 0; i < 10; i++)
{
    listEntries.Add(random.Next(100, 1000));
}

Console.WriteLine("Generating entries");

var journalTasks = listEntries.Select(j => service.GetEntriesAsync(j, ct)).ToList();

var res = await Task.WhenAny(journalTasks);
cts.Cancel();

Console.WriteLine($"Task with ID {res.Id} finished\nPress ENTER to exit.");

Console.ReadLine();