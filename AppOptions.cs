using CommandLine;

namespace SeriesRenamer;

public class AppOptions
{
    [Option('t', "test", Required = false, HelpText = "Запуск без переименовывания файлов.")]
    public bool DryRun { get; set; }
    
    [Option('d', "destination", Required = false, HelpText = "Папка с переименованными сериями, если требуется скопировать их в другое место.")]
    public string DestinationFolder { get; set; }
}