using System.ComponentModel;
using System.Diagnostics;
using System.Text;

var origRow = Console.CursorTop;
var origCol = Console.CursorLeft;
Console.WriteLine("Hello, Edenred!");


var backgroundWorker = new BackgroundWorker
{
    WorkerReportsProgress = true,
    WorkerSupportsCancellation = true,
};

backgroundWorker.DoWork += BackgroundWorkerDoWork;
backgroundWorker.ProgressChanged += BackgroundWorkerProgressChanged;
backgroundWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerCompleted;

backgroundWorker.RunWorkerAsync();

Console.WriteLine("To cancel worker thread press C");
while (backgroundWorker.IsBusy)
{
    
    if (Console.ReadKey(true).KeyChar is 'C' or 'c')
    {
        
        backgroundWorker.CancelAsync();
        WriteProgress("Work canceled", 0, 2);
    }
}

Console.WriteLine("Press ENTER to exit");
Console.ReadLine();


void BackgroundWorkerDoWork(object? sender, DoWorkEventArgs e)
{
    var worker = sender as BackgroundWorker ?? new BackgroundWorker();
    var data = new StringBuilder();
    const int nCalculations = 100000000;
    var proReported = 0;

    // simulation
    for (var i = 0; i < nCalculations; i++)
    {
        if (!worker.CancellationPending)
        {
            var percentProgress =(int) ((float)i / nCalculations * 100);
            data.Append(i);
            if (percentProgress != proReported && percentProgress % 5 == 0)
            {
                proReported = percentProgress;
                worker.ReportProgress(percentProgress);
            }
        }
        else
        {
            worker.CancelAsync();
        }
    }

    e.Result = data;
}

void BackgroundWorkerRunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e) =>
    Console.WriteLine(e.Error != null
        ? e.Error.Message
        : $"\nData amount downloaded from service was {e.Result?.ToString()?.Length ?? 0:N0} bytes.");

void BackgroundWorkerProgressChanged(object? sender, ProgressChangedEventArgs e) =>
    WriteProgress($"{e.ProgressPercentage} %", 0, 5);


void WriteProgress(string cad, int x, int y)
{
    try
    {
        Console.SetCursorPosition(origCol + x, origRow + y);
        Console.Write(cad);
    }
    catch (Exception e)
    {
        Debug.WriteLine(e);
    }
}
