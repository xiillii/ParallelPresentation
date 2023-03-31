using System.Diagnostics;
using ParallelPresentation.Shared;

Console.WriteLine("Hello, Edenred!");

var watch = new Stopwatch();
var services = new JournalService();
var journalsToGenerate = new int[5];
var rnd = new Random();

for (var i = 0; i < journalsToGenerate.Length; i++)
{
    journalsToGenerate[i] = rnd.Next(100, 1000);
}

Console.WriteLine("*** Running sequential loop");
watch.Start();
foreach (var i in journalsToGenerate)
{
    services.GetEntries(i);
}
Console.WriteLine($"*** Elapsed seconds: {watch.ElapsedMilliseconds / 1000}");
watch.Restart();

Console.WriteLine("*** Running parallel loop");
Parallel.ForEach(journalsToGenerate, j => services.GetEntries(j));
Console.WriteLine($"*** Elapsed seconds: {watch.ElapsedMilliseconds / 1000}");
watch.Restart();


Console.WriteLine("Press ENTER to exit.");
Console.ReadLine();
