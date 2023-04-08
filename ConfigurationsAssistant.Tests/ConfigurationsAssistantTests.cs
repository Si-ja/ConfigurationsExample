namespace ConfigurationsAssistant.Tests;

public class ConfigurationsAssistantTests
{
	[Fact]
	public void When_ConfigurationsRead_And_TheyDontExist_Should_ThrowException()
	{
		// Arrange
		var customPath = "test";

		// Act
		Action configurations = () =>
		{
			_ = new ConfigurationsAssistantObject(customPath);
		};

		// Assert
		configurations.Should().Throw<Exception>();
		configurations.Should().NotBeNull();
	}

	[Fact]
	public void When_ConfigurationsRead_And_TheyDoExist_Should_NotThrowExcepion()
	{
		// Arrange
		// A Settings.json file is put into the root of the testing project.

		// Act
		Action configurations = () =>
		{
			_ = new ConfigurationsAssistantObject();
		};

		// Assert
		configurations.Should().NotThrow<Exception>();
		configurations.Should().NotBeNull();
	}

	[Fact]
	public void When_ReadingRandomSettings_And_AllIsInOrder_Should_ReturnAllNeededSettings()
	{
		// Arrange
		// A Settings.json file is put into the root of the testing project.

		// Act
		var configurations = new ConfigurationsAssistantObject();
		var randomSettings = configurations.GetSection<RandomSettings>();

		// Assert
		randomSettings.Should().NotBeNull();
		randomSettings.Should().BeOfType<RandomSettings>();

		randomSettings.RandomName.Should().NotBeNull();
		randomSettings.RandomValue.Should().BeGreaterThan(0);
		randomSettings.RandomAppendix.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public void When_ReadingMissingSettings_And_AllIsInOrder_Should_ReturnEmptySettingsButNotCauseIssues()
	{
		// Arrange
		// A Settings.json file is put into the root of the testing project.

		// Act
		var configurations = new ConfigurationsAssistantObject();
		var missingSettings = configurations.GetSection<MissingSettings>();

		// Assert
		missingSettings.Should().NotBeNull();
		missingSettings.Should().BeOfType<MissingSettings>();

		missingSettings.Name.Should().BeNullOrEmpty();
		missingSettings.RandomValue.Should().Be(0);
	}
}
