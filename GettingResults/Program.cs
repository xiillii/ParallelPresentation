Console.WriteLine("Hello, Edenred!");

const int number = 100;

var sumTask = new Task<long>(() => Summation(number));
sumTask.Start();
Console.WriteLine($"Summation of {number}. new Task\t\t: {sumTask.Result}");

var sumFactory = Task.Factory.StartNew<long>(() => Summation(number));
Console.WriteLine($"Summation of {number}. Task Factory\t\t: {sumFactory.Result}");

var sumRun = Task.Run<long>(() => Summation(number));
Console.WriteLine($"Summation of {number}. Task Run\t\t: {sumRun.Result}");

var sumTaskResult = Task.FromResult<long>(Summation(number));
Console.WriteLine($"Summation of {number}. Task FromResult\t: {sumTaskResult.Result}");


long Summation(int n)
{
    var sum = 0;
    for (var i = 0; i < n; i++)
    {
        sum += i;
    }
    return sum;
}
