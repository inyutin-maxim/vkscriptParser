using System.Linq;
using Moq.AutoMock;
using VkScript.Parser.Lexer;
using Xunit;

namespace VkScript.Parser.Tests
{
	public class VkScriptParserTests
	{
		private readonly AutoMocker _mocker = new AutoMocker();

		[Fact]
		public void ContainsPlusOperator()
		{
			var parser = _mocker.CreateInstance<Parser.VkScriptParser>();
			var script = parser.Parse(Enumerable.Empty<VkScriptLexeme>());
			Assert.NotNull(script);
		}
	}
}