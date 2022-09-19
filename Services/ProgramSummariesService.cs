using TvTidCLI.Models;

namespace TvTidCLI.Services;

public class ProgramSummariesService
{
    private ITvTidApi api;

    public ProgramSummariesService(ITvTidApi api)
    {
        this.api = api;
    }

    public async Task<List<TvTidProgramSummaries>> GetProgramSummaries(List<TvTidChannel> channels, string categoryName)
    {
        var channelIds = new List<string>();
        foreach (var channel in channels)
        {
            channelIds.Add(channel.Id);
        }
        
        var today = DateTime.Now.ToString("yyyy-MM-dd");
        var programSummaries = await api.GetProgramSummariesAsync(today, channelIds);
        var newProgramSummaries = new List<TvTidProgramSummaries>();

        foreach (var summaries in programSummaries)
        {
            var list = new List<TvTidProgramSummary>();
            int count = 0;
            foreach (var programSummary in summaries.Programs)
            {
                if ((categoryName == "" || programSummary.Categories.Contains(categoryName)) && programSummary.Stop > DateTime.Now)
                {
                    list.Add(programSummary);
                    count++;
                }
                if (count >= 2)
                {
                    break;
                }
            }
            if (count > 0)
            {
                newProgramSummaries.Add(new TvTidProgramSummaries
                {
                    Id = summaries.Id,
                    Programs = list
                });
            }
        }

        return newProgramSummaries;
    }
}