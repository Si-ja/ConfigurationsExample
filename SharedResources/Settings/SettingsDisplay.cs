namespace SharedResources.Settings;

public static class SettingsDisplay
{
	/// <summary>
	/// An extension method to the settings of our chose that we make.
	/// A metod allows to display all the information at once for a
	/// number of settings that we created, showing what values are stored
	/// with what variables if any.
	/// </summary>
	/// <param name="settings">BaseSettings used as the base for the type we can use to 
	/// apply an extension to.</param>
    public static void ShowInformation(this BaseSettings settings)
	{
		switch(settings)
		{
			case RandomSettings:

				var randomSettings = (RandomSettings)settings;
				string randomSettingsInfo = "==================================================================\n" +
					"Information gathered in RandomSettings\n" +
					$"Random Name assigned:\t\t{randomSettings.RandomName}\n" +
					$"Random Value assigned:\t\t{randomSettings.RandomValue}\n" +
					$"Information in the Appendix:\t{randomSettings.RandomAppendix}\n" +
					"==================================================";

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(randomSettingsInfo);
				Console.ForegroundColor = ConsoleColor.White;
				break;

			case SilentSettings:

				var silentSettings = (SilentSettings)settings;
				string silentSettingsInfo = "==================================================================\n" +
					"Information gathered in SilentSettings\n" +
					$"A Name assigned:\t\t\t{silentSettings.Name}\n" +
					$"Random Value assigned:\t\t\t{silentSettings.RandomValue}\n" +
					$"Information in the Random Section:\t{silentSettings.RandomInformation}\n" +
					"==================================================================";

				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine(silentSettingsInfo);
				Console.ForegroundColor = ConsoleColor.White;
				break;

			case MissingSettings:

				var missingSettings = (MissingSettings)settings;
				string missingSettingsInfo = "==================================================================\n" +
					"Information gathered in MissingSettings\n" +
					$"A Name assigned:\t\t\t\t{missingSettings.Name}\n" +
					$"Random Value assigned:\t\t\t{missingSettings.RandomValue}\n" +
					"==================================================================";

				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine(missingSettingsInfo);
				Console.ForegroundColor = ConsoleColor.White;
				break;

			default:
				Console.WriteLine("The settings you presented do not have an extension yet implemented.");
				break;
		}
	}
}
