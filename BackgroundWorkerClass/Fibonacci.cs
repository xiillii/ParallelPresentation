namespace BackgroundWorkerClass;

internal class Fibonacci
{
    private readonly ManualResetEvent _doneEvent;

    public int NElements { get; }

    public Fibonacci(int n, ManualResetEvent doneEvent)
    {
        NElements = n;
        _doneEvent = doneEvent;
    }

    public decimal FibOfN { get; set; }

    public void ThreadPoolCallback(object threadContext)
    {
        var threadIndex = (int)threadContext;
        Console.WriteLine($"Thread {threadIndex} started for {NElements} elements");
        FibOfN = CalculateSequential(NElements);
        Console.WriteLine($"Thread {threadIndex} result Calculated");
        _doneEvent.Set();
    }

    private decimal CalculateSequential(int n)
    {
        n++;
        var arr = new decimal[n];
        arr[0] = 0;
        arr[1] = 1;

        for (var i = 2; i < n; i++)
        {
            arr[i] = arr[i - 1] + arr[i - 2];
        }

        return arr.Last();
    }
}