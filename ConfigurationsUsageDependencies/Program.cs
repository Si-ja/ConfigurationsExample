using ConfigurationsAssistant;
using ConfigurationsUsageDependencies.Services;

namespace ConfigurationsUsageDependencies;

internal class Program
{
    static void Main(string[] args)
    {
		var configurations = new ConfigurationsAssistantObject();
		var auditor = new Auditor(configurations);

		auditor.Talk();
    }
}