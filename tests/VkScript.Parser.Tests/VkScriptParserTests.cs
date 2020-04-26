using Moq.AutoMock;
using Xunit;

namespace VkScript.Parser.Tests
{
	public class VkScriptParserTests
	{
		private readonly AutoMocker _mocker = new AutoMocker();

		[Fact]
		public void ContainsPlusOperator()
		{
			var parser = _mocker.CreateInstance<VkScriptParser>();
			var script = parser.Parse("1+1");
			Assert.NotNull(script);
		}
	}
}