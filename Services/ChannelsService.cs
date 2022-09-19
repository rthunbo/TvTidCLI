using TvTidCLI.Models;

namespace TvTidCLI.Services;

public class ChannelsService
{
    private ITvTidApi api;

    public ChannelsService(ITvTidApi api)
    {
        this.api = api;
    }

    public async Task<List<TvTidChannel>> GetChannels()
    {
         var categories = await api.GetChannelsAsync();

        return categories.Channels;
    }
}