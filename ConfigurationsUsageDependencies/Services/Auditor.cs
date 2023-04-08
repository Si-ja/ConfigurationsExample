using ConfigurationsAssistant;
using SharedResources.Settings;

namespace ConfigurationsUsageDependencies.Services;
public class Auditor
{
	private readonly ConfigurationsAssistantObject configurations;

	public Auditor(ConfigurationsAssistantObject configurations)
	{
		this.configurations = configurations;
	}

	public void Talk()
	{
		var workingSettings = this.configurations.GetSection<RandomSettings>();

		Console.WriteLine($"Wow, there are {workingSettings.RandomValue} chickens here.");
	}

	public void DoNothing()
	{
		var workingSettings = this.configurations.GetSection<RandomSettings>();

		// IDLE
	}
}
