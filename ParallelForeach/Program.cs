using ParallelPresentation.Shared;

Console.WriteLine("Hello, Edenred!");

var services = new JournalService();
var journalsToGenerate = new int[500];
var rnd = new Random();

for (var i = 0; i < journalsToGenerate.Length; i++)
{
    journalsToGenerate[i] = rnd.Next(100, 1000);
}

Console.WriteLine("*** Running parallel loop");
Parallel.ForEach(journalsToGenerate, new ParallelOptions { MaxDegreeOfParallelism = 400 }, j => services.GetEntries(j));

Console.WriteLine("Press ENTER to exit.");
Console.ReadLine();