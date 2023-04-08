using Microsoft.Extensions.Configuration;

namespace ConfigurationsAssistant;
public class ConfigurationsAssistantObject
{
	private readonly IConfiguration _config;

	/// <summary>
	/// Read the Settings.json file.
	/// </summary>
	/// <param name="settingsPath">If required, present your own Settings path to the assistance tool
	/// with the extension name. Do note, that only the .json format is supported. If no file path
	/// is presented, the assistant will assume there is a Settings.json file at the root of the
	/// project from which it is being executed.</param>
	/// <param name="bypass">Chose wheter to bypass assistant setup stage or not. If bypass is set to
	/// true, then the assistant will initialize with _config variable as empty. This is only recommended
	/// to be used when mocking the class itself for testing.</param>
	/// <exception cref="InvalidOperationException">An exception thrown if the [Settings] will not be found 
	/// at either base of the project or indicated location of choice and it will not be stored as a
	/// .json file, where other formats are not currently supported.</exception>
	public ConfigurationsAssistantObject(string? settingsFullPath = null, bool bypass = false)
	{
		var settingsPath = settingsFullPath ?? AppDomain.CurrentDomain.BaseDirectory + "Settings.json";

		try
		{
			if (File.Exists(settingsPath) && settingsPath.Split(".").Last() == "json" && bypass == false)
			{
				this._config = new ConfigurationBuilder()
				   .AddJsonFile(settingsPath)
				   .Build();
			}
			else if (bypass == true)
			{
				// An assistant will be created but with an empty state in the _config variable.
				return;
			}
			else
			{
				throw new InvalidOperationException($"A file {settingsPath} does not exist for the {nameof(ConfigurationsAssistantObject)} to perform operations on.");
			}
		}
		catch (Exception e)
		{
			throw new Exception(e.Message);
		}
	}
	
	/// <summary>
	/// Get a section from the read settings, by providing an objects
	/// to which structure the section of settings sould be mapped.
	/// 
	/// If no settings were assigned to the chosen section, the
	/// method should return an objects filled with empty fields.
	/// </summary>
	/// <typeparam name="T">An object which gives the Settings a section to mapping.</typeparam>
	/// <returns>An Object in which the chosen section of Settings should be stored.</returns>
	public virtual T GetSection<T>()
	{
		#pragma warning disable CS8604 // Possible null reference argument.
		var retrievedSection = _config
				.GetRequiredSection(typeof(T).Name)
				.Get<T>()
				.ValidateSettings();
		#pragma warning restore CS8604 // Possible null reference argument.

		return (T) retrievedSection;
	}
}

/// <summary>
/// A small extension to validate that the settings read
/// are more or less compliant with what the user requires
/// to see.
/// 
/// All associated methods should be meant
/// only for internal use.
/// </summary>
internal static class SettingsExtensions
{
	/// <summary>
	/// Validate that the read settings are not empty. If they are,
	/// update the contents of the prepared returnable object with
	/// empty fields.
	/// </summary>
	internal static object ValidateSettings(this object settings)
	{
		return settings ?? new object();
	}
}
