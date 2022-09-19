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
            string categoryName = "";
            for (int i = 1; i < args.Length; i++)
            {
                if (i > 1)
                {
                    categoryName += " ";
                }
                categoryName += args[i];
            }

            var channels = await channelsService.GetChannels();
            var programSummariesList = await programSummariesService.GetProgramSummaries(channels, categoryName);

            foreach (var summaries in programSummariesList)
            {
                Console.Write(String.Format("{0,-15}", channels.Where(x => x.Id == summaries.Id).First().Title));
                foreach (var programSummary in summaries.Programs)
                {
                    Console.Write(" [" + programSummary.Start.ToShortTimeString() + "] ");
                    Console.Write(programSummary.Title);
                }
                Console.WriteLine();
            }

        }
        Console.WriteLine();
    }
}
