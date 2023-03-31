//Console.WriteLine("Hello, Edenred!");
//const int maxNumber = 100;
//var rand = new Random();

//var fN1 = rand.Next(0, maxNumber);
//var fN2 = rand.Next(0, maxNumber);
//var fN3 = rand.Next(0, maxNumber);
//var fN4 = rand.Next(0, maxNumber);

//var task1 = Task.Factory.StartNew<double>(() => GetNFibonacci(fN1));
//var task2 = Task.Factory.StartNew<double>(() => GetNFibonacci(fN2));
//var task3 = Task.Factory.StartNew<double>(() => GetNFibonacci(fN3));
//var task4 = Task.Factory.StartNew<double>(() => GetNFibonacci(fN4));

//Task.WaitAll(task1, task2, task3, task4);
//Console.WriteLine("All tasks finished");

//Console.WriteLine($"Task ID {task1.Id} - Fibonacci of {fN1}\t: {task1.Result}");
//Console.WriteLine($"Task ID {task2.Id} - Fibonacci of {fN2}\t: {task2.Result}");
//Console.WriteLine($"Task ID {task3.Id} - Fibonacci of {fN3}\t: {task3.Result}");
//Console.WriteLine($"Task ID {task4.Id} - Fibonacci of {fN4}\t: {task4.Result}");

//Console.WriteLine("Press ENTER to exit");
//Console.ReadLine();

Console.WriteLine("Hello, Edenred!");
const int nTask = 10;
const int maxNumber = 1000;
var rand = new Random();

var taskArray = new (int, Task)[nTask];

for (var index = 0; index < taskArray.Length; index++)
{
    var n = rand.Next(20, maxNumber);
    taskArray[index] = (n, Task.Run<(int, double)>(() => GetNFibonacci(n)));
}

var idx = Task.WaitAny(taskArray.Select(t => t.Item2).ToArray());

Console.WriteLine($"Task with index {idx} finished");

var resN = taskArray[idx].Item1;
var task = taskArray[idx].Item2 as Task<(int, double)>;

Console.WriteLine($"Task[{idx}] ID {task.Id} - Fibonacci of {resN + 1}:{task.Result.Item1}\t: {task.Result.Item2}");

Console.WriteLine("\nCurrent Status of Tasks:");
for (var index = 0; index < taskArray.Length; index++)
{
    var t = taskArray[index];
    Console.WriteLine($"   Task[{index}] ID {t.Item2.Id} for {t.Item1 + 1}: {t.Item2.Status}");
}




//Console.WriteLine("Press ENTER to exit");
//Console.ReadLine();

//Task[] tasks = new Task[5];
//for (int ctr = 0; ctr <= 4; ctr++)
//{
//    int factor = ctr;
//    tasks[ctr] = Task.Run(() => Thread.Sleep(factor * 250 + 50));
//}
//int index = Task.WaitAny(tasks);
//Console.WriteLine("Wait ended because task #{0} completed.",
//    tasks[index].Id);
//Console.WriteLine("\nCurrent Status of Tasks:");
//foreach (var t in tasks)
//    Console.WriteLine("   Task {0}: {1}", t.Id, t.Status);



//Console.WriteLine("Hello, Edenred!");
//const int nTask = 10;
//const int maxNumber = 1000;
//var rand = new Random();

//for (int i = 0; i < 100; i++)
//{
//    var taskArray = new Task[nTask];

//    for (var index = 0; index < taskArray.Length; index++)
//    {
//        var n = rand.Next(20, maxNumber);
//        taskArray[index] = Task.Factory.StartNew<(int, double)>(() => GetNFibonacci(n));
//    }

//    var idx = Task.WaitAny(taskArray);

//    Console.WriteLine($"Task with index {idx} finished");

//    var task = taskArray[idx] as Task<(int, double)>;

//    Console.WriteLine($"Task[{idx}] ID {task.Id} - Fibonacci of {task.Result.Item1}\t: {task.Result.Item2}");
//}



//Console.WriteLine("Press ENTER to exit");
//Console.ReadLine();


(int,double) GetNFibonacci(object? numElements)
{
    var nElements = (int)(numElements ?? 0) + 1;
    var arr = new double[nElements];

    arr[0] = 0;
    arr[1] = 1;

    for (var i = 2; i < nElements; i++)
    {
        arr[i] = arr[i - 1] + arr[i - 2];
    }
    Thread.Sleep(nElements);
    return (nElements, arr.Last());
}



void PrintFibonacci(object? numElements)
{
    var nElements = (int)(numElements ?? 0);
    var arr = new double[nElements];
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
