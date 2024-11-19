using CommandLine;

namespace SeriesRenamer;

public class AppOptions
{
    [Option('t', "test", Required = false, HelpText = "Запуск без переименовывания файлов.")]
    public bool DryRun { get; set; }
}