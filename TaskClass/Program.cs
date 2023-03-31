Console.WriteLine("Hello, Edenred!");

//var task = new Task(() => CalculateFibonacci(100));

//var task = new Task(delegate { CalculateFibonacci(); });

//task.Start();

await Task.Run(async () => await CalculateFibonacci());
//Task.Run(new Action(CalculateFibonacci));
//Task.Run(delegate { CalculateFibonacci(); });
//await Task.Factory.StartNew(async () =>
//{
//    await CalculateFibonacci();
//});
//await Task.Delay(60000);
//await Task.Factory.StartNew(new Action(CalculateFibonacci));






async Task CalculateFibonacci()
{
    Console.WriteLine("Calculating... Wait 20 seconds");
    await Task.Delay(20000);
    Console.WriteLine("After 20 seconds delay");
    Console.WriteLine("0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987");

}