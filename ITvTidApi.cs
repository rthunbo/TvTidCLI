using RestEase;
using TvTidCLI.Models;

namespace TvTidCLI;

[Header("User-Agent", "RestEase")]
public interface ITvTidApi
{
    [Get("v1/schedules/channels")]
    Task<TvTidChannels> GetChannelsAsync();

    [Get("v1/schedules/categories")]
    Task<TvTidCategories> GetCategoriesAsync();

    [Get("v1/epg/dayviews/{date}")]
    Task<List<TvTidProgramSummaries>> GetProgramSummariesAsync([Path] string date, [Query] List<string> ch);
}