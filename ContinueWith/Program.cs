using ParallelPresentation.Shared;

Console.WriteLine("Hello, Edenred!");

var rnd = new Random();
var service = new JournalService();

var task = Task.Factory.StartNew<List<JournalEntry>>(() =>
{
    var regs = rnd.Next(100, 1000);
    var entries = service.GetEntriesAsync(regs, CancellationToken.None).Result;
    return entries;
}).ContinueWith((e) =>
{
    var regs = rnd.Next(100, 1000);
    var moreEntries = service.GetEntriesAsync(regs, CancellationToken.None).Result;
    var joined = new List<JournalEntry>();
    joined.AddRange(e.Result);
    joined.AddRange(moreEntries);

    return joined;

}).ContinueWith((j) =>
{
    Console.WriteLine("Data generated (From the last continue):");
    Console.WriteLine($"{j.Result.Count} records");
});
await task;
Console.WriteLine("Press ENTER to exit");
Console.ReadLine();