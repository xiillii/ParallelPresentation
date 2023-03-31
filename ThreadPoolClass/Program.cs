using ThreadPoolClass;

Console.WriteLine("Hello, Edenred!");

const int fibonacciCalculations = 5;

var doneEvents = new ManualResetEvent[fibonacciCalculations];
var fibArr = new Fibonacci[fibonacciCalculations];
var rand = new Random();

Console.WriteLine($"Launching {fibonacciCalculations} tasks...");
for (var i = 0; i < fibonacciCalculations; i++)
{
    doneEvents[i] = new ManualResetEvent(false);
    var f = new Fibonacci(rand.Next(20, 100), doneEvents[i]);
    fibArr[i] = f;
    ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
}

WaitHandle.WaitAll(doneEvents);
Console.WriteLine("All calculations are completed.");

for (var i = 0; i < fibonacciCalculations; i++)
{
    var f = fibArr[i];
    Console.WriteLine($"Fibonacci({f.NElements}) = {f.FibOfN}");
}

Console.WriteLine("Press any key to finish");
Console.ReadKey();