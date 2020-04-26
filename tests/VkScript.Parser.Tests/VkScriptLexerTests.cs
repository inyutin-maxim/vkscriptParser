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

		[Fact]
		public void ContainsSingleMinusLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("1-1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Minus);
		}

		[Fact]
		public void ContainsSingleDivideLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("1/1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Divide);
		}

		[Fact]
		public void ContainsSingleMultiplyLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("1*1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Multiply);
		}

		[Fact]
		public void ContainsSingleNotEqualLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("return 1!=2;");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.NotEqual);
		}

		[Fact]
		public void ContainsSingleIfLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("if (true)");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.If);
		}

		[Fact]
		public void ContainsSingleRoundOpenLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("if (true)");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.RoundOpen);
		}

		[Fact]
		public void ContainsSingleRoundCloseLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("if (true)");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.RoundClose);
		}

		[Fact]
		public void ContainsSingleTrueLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("if (true)");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.True);
		}

		[Fact]
		public void ContainsSingleFalseLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("if (false)");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.False);
		}

		[Fact]
		public void ContainsSingleReturnLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("return true;");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Return);
		}
	}
}