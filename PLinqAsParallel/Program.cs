Console.WriteLine("Hello, Edenred!");

var range = Enumerable.Range(1,100000);

var resultList = (from i in range.AsParallel()
                  where i % 3 == 0
                      select i).ToList();

Console.WriteLine($"Parallel: Total items are {resultList.Count}");