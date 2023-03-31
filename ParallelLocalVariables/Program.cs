Console.WriteLine("Hello, Edenred!");

var numbers = Enumerable.Range(1, 60);

long sumOfNumbers = 0;

Action<long> taskFinished = (taskResult) =>
{
    Console.WriteLine($"Sum at the end of all task iterations for task {Task.CurrentId} is {taskResult}");
    Interlocked.Add(ref sumOfNumbers, taskResult);
};

Parallel.For(0, numbers.Count(), () => 0, (j, loop, subtotal) =>
{
    subtotal += j;
    return subtotal;
}, taskFinished);

Console.WriteLine($"The total og 60 numbers is {sumOfNumbers}");


Console.WriteLine("Press ENTER to exit");
Console.ReadLine();
