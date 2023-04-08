using ConfigurationsAssistant;
using SharedResources.Settings;

namespace ConfigurationsMoqExtension;

internal class Program
{
    static void Main(string[] args)
    {
        var configurations = new ConfigurationsAssistantObject();
        var randomSettings = configurations.GetSection<RandomSettings>();
		var silentSettings = configurations.GetSection<SilentSettings>();
		var missingSettings = configurations.GetSection<MissingSettings>();

        randomSettings.ShowInformation();
		silentSettings.ShowInformation();
		missingSettings.ShowInformation();
    }
}