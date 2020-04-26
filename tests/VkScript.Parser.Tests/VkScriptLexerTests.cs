using Moq.AutoMock;
using VkScript.Parser.Lexer;
using Xunit;

namespace VkScript.Parser.Tests
{
	public class VkScriptLexerTests
	{
		private readonly AutoMocker _mocker = new AutoMocker();

		[Fact]
		public void ContainsSinglePlusLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("1+1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Plus);
		}

		[Fact]
		public void ContainsNumberLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("1+1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Contains(result, x => x.Type == VkScriptLexemeType.Number);
		}

		[Fact]
		public void ContainsSingleEndOfFileLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("1+1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Eof);
		}

		[Fact]
		public void ContainsSingleVarLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("var a = 1;");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Var);
		}

		[Fact]
		public void ContainsSingleSemicolonLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("var a = 1;");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Semicolon);
		}

		[Fact]
		public void ContainsSingleAssignLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("var a = 1;");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Assign);
		}
	}
}