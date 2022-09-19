namespace TvTidCLI.Models;

public class TvTidProgramSummaries
{
    public string Id { get; set; } = null!;

    public List<TvTidProgramSummary> Programs { get; set; } = null!;
}