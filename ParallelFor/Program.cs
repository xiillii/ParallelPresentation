Console.WriteLine("Hello, Edenred!");

var path = @"c:\windows";
var totalFiles = 0;
var files = Directory.GetFiles(path);

Parallel.For(0, files.Length, (i) =>
{
    var fileInfo = new FileInfo(files[i]);
    if (fileInfo.Length > 1024)
    {
        Interlocked.Increment(ref totalFiles);
    }
});

Console.WriteLine($"Total number of files in {path} are {files.Count()} and {totalFiles} length are greater than 1MB");

Console.WriteLine("\nPress ENTER to exit");
Console.ReadLine();
