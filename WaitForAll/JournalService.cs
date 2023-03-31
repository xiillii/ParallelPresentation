using RimuTec.Faker;

namespace WaitForAll;

public class JournalService
{
    public async Task<List<JournalEntry>> GetEntriesAsync(int totalToGet, CancellationToken cancellationToken)
    {
        var result = new List<JournalEntry>();
        Console.WriteLine($"Generating {totalToGet} entries");

        for (var i = 0; i < totalToGet; i++)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"Task canceled. Not generated {totalToGet} entries");
                return result;
            }
            result.Add(new JournalEntry()
            {
                Title = $"Title {i + 1}",
                Description = $"Description {i + 1}",
                EntryDate = DateTime.Now,
                EntryText = Lorem.Paragraph(4)
            });
            await Task.Delay(1);
        }

        Console.WriteLine($"Generated {totalToGet} entries");

        return result;
    }
}