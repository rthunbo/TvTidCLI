using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TvTidCLI.Models;

public class TvTidProgramSummary 
{
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime Stop { get; set; }

    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime Start { get; set; }

    public List<string> Categories { get; set; } = null!;

    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public bool AvailableAsVod { get; set; }

    public bool Live { get; set; }

    public bool Premiere { get; set; }

    public bool Rerun { get; set; }
}