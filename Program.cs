using RestEase;
using TvTidCLI;
using TvTidCLI.Services;

class EntryPoint
{
    static async Task Main(string[] args)
    {
        var tvTidApi = RestClient.For<ITvTidApi>("https://tvtid-api.api.tv2.dk/api/tvtid");

        var categoriesServices = new CategoriesService(tvTidApi);
        var channelsService = new ChannelsService(tvTidApi);
        var programSummariesService = new ProgramSummariesService(tvTidApi);

        if (args.Length > 0 && args[0] == "list-categories")
        {
            var categories = await categoriesServices.GetCategories();

            foreach(var category in categories)
            {
                Console.WriteLine(category.Name);
            }
        }

        if (args.Length > 0 && args[0] == "list")
        {
            var categoryName = string.Join(" ", args, 1, args.Length - 1);

            var channels = await channelsService.GetChannels();
            var programSummariesList = await programSummariesService.GetProgramSummaries(channels, categoryName);

            var programTitlesList = programSummariesList.Select(x => 
                string.Format("{0,-15}", channels.First(c => c.Id == x.Id).Title)
                + string.Join("", x.Programs.Select(y => string.Format(" [{0:t}] {1}{2}", y.Start, y.Title, (y.Live ? " [Live]": "")))));

            foreach (var programTitles in programTitlesList)
            {
                Console.WriteLine(programTitles);
            }
        }
        Console.WriteLine();
    }
}
