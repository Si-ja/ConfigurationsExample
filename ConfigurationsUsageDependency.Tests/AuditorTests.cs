using ConfigurationsUsageDependencies.Services;

namespace ConfigurationsUsageDependency.Tests;

public class AuditorTests
{
	// Assigning null - for path, true - for bypassing the configs creation
	private readonly Mock<ConfigurationsAssistantObject> _mockConfiguration = new (null, true);

	[Fact]
    public void When_ConfigurationsDontMatter_Should_BeMockable()
    {
		// Arrange
		var sut = GetSut();

		// We will use an example class for this case
		_mockConfiguration.Setup(
			s => s.GetSection<RandomSettings>())
			.Returns(new RandomSettings());

		var stringWriter = new StringWriter();
		Console.SetOut(stringWriter);

		// Act
		Action somethingHappens = () =>
		{
			sut.Talk();
		};

		sut.Talk();
		var output = stringWriter.ToString();

		// Assert

		// Making sure there are no exceptions thrown, but also that the
		// Talk method worked and produced an ouput
		somethingHappens.Should().NotThrow<Exception>();
		output.Should().NotBeNullOrWhiteSpace();
	}

	private Auditor GetSut()
	{
		return new Auditor(_mockConfiguration.Object);
	}
}