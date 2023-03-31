using System.Diagnostics;
using System.Text;

var origRow = Console.CursorTop;
var origCol = Console.CursorLeft;
Console.WriteLine("Hello, Edenred!");

var ctr = new CancellationTokenSource();
var cancellationToken = ctr.Token;

Console.WriteLine("To cancel worker thread press C");

var r = Task.Run(() => DownloadData(cancellationToken));

while (!r.IsCompleted)
{
    if ((Console.ReadKey(true).KeyChar is 'C' or 'c'))
    {
        ctr.Cancel();
        break;
    }

}


Console.WriteLine("Press ENTER to exit");
Console.ReadLine();


void DownloadData(CancellationToken token)
{
    
    
    var data = new StringBuilder();
    const int nCalculations = 100000000;
    var proReported = 0;

    // simulation
    for (var i = 0; i < nCalculations; i++)
    {
        if (!token.IsCancellationRequested)
        {
            var percentProgress = (int)((float)i / nCalculations * 100);
            data.Append(i);
            if (percentProgress != proReported && percentProgress % 5 == 0)
            {
                proReported = percentProgress;
                WriteProgress($"{percentProgress} %", 0, 5);
            }
        }
        else
        {
            Console.WriteLine("\nDownload Canceled");
            break;
        }
    }
    Console.WriteLine($"\nBytes downloaded: {data.Length}");
}

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