namespace TvTidCLI.Models;

public class TvTidChannel
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public string SvgLogo { get; set; } = null!;

    public string Lang { get; set; } = null!;

    public int Sort { get; set; }
}