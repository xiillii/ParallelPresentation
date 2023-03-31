
//ExecuteSequential();
ExecuteWithThread();


void ExecuteWithThread()
{
    Console.WriteLine("Hello, Edenred!");

    var thread = new Thread(new ParameterizedThreadStart(PrintFibonacci));
    thread.Start(100);

    Console.WriteLine("Finishing main thread");
    Console.WriteLine("Press any key to finish");
    Console.ReadKey();
}

void ExecuteSequential()
{
    Console.WriteLine("Hello, Edenred!");

    PrintFibonacci(39);

    Console.WriteLine("Finishing main thread");
    Console.WriteLine("Press any key to finish");
    Console.ReadKey();
}



void PrintFibonacci(object? numElements)
{
    var nElements = (int)(numElements ?? 0);
    var arr = new decimal[nElements];
    arr[0] = 0;
    arr[1] = 1;

    for (var i = 2; i < nElements; i++)
    {
        arr[i] = arr[i - 1] + arr[i - 2];
    }

    for (var index = 0; index < arr.Length; index++)
    {
        var number = arr[index];
        Console.WriteLine($"{index}: {number}");
    }
}
