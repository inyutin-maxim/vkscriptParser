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
		public void ContainsSingleNumberLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("return 1;");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Number);
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

		[Fact]
		public void ContainsSingleSquareOpenLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("[1,2]");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.SquareOpen);
		}

		[Fact]
		public void ContainsSingleSquareCloseLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("[1,2]");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.SquareClose);
		}

		[Fact]
		public void ContainsSingleCommaLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("[1,2]");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Comma);
		}

		[Fact]
		public void ContainsSingleCurlyOpenLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("if (true){ return true; }");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.CurlyOpen);
		}

		[Fact]
		public void ContainsSingleCurlyCloseLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("if (true){ return true; }");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.CurlyClose);
		}

		[Fact]
		public void ContainsSingleDoLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("do {} while(true)");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Do);
		}

		[Fact]
		public void ContainsSingleElseLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("if (true){ return true; } else { return false}");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Else);
		}

		[Fact]
		public void ContainsSingleWhileLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("while(true){}");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.While);
		}

		[Fact]
		public void ContainsSingleStringSingleQuotesLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("return 'строка';");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.String && x.Value == "строка");
		}

		[Fact]
		public void ContainsSingleStringDoubleQuotesLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("return \"строка\";");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.String && x.Value == "строка");
		}

		[Fact]
		public void ContainsSingleIdentifierLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("var a = 1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Identifier && x.Value == "a");
		}

		[Fact]
		public void ContainsSingleLessLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("return 1<3;");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Less);
		}

		[Fact]
		public void ContainsSingleGreaterLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("return 1>3;");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Greater);
		}

		[Fact]
		public void ContainsSingleLessOrEqualLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("if (a<=b)");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.LessOrEqual);
		}

		[Fact]
		public void ContainsSingleGreaterOrEqualLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("if (a>=b)");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.GreaterOrEqual);
		}

		[Fact]
		public void ContainsSingleEqualLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("if (a==b)");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Equal);
		}

		[Fact]
		public void ContainsSingleColonLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("case 1: break;");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Colon);
		}

		[Fact]
		public void ContainsSingleLogicOrLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("a==b || a==c");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Or);
		}

		[Fact]
		public void ContainsSingleLogicAndLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("a==b && a==c");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.And);
		}

		[Fact]
		public void ContainsSingleLogicNotLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("!(true)");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Not);
		}

		[Fact]
		public void ContainsSingleBitAndLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("x= 6 & 1;");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.BitAnd);
		}

		[Fact]
		public void ContainsSingleBitOrLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("x = 4 | 1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.BitOr);
		}

		[Fact]
		public void ContainsSingleBitNotLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("x = 5 ~ 1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.BitNot);
		}

		[Fact]
		public void ContainsSingleExcludingOrLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("x = 5 ^ 1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.ExcludingOr);
		}

		[Fact]
		public void ContainsSingleLeftShiftLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("x = 5 << 1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.LeftShift);
		}

		[Fact]
		public void ContainsSingleRightShiftLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("x = 5 >> 1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.RightShift);
		}

		[Fact]
		public void ContainsSingleRightFillingShiftLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("x = 5 >>> 1");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.RightFillingShift);
		}

		[Fact]
		public void ContainsSingleDeleteLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("var a=3; delete a");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.Delete);
		}

		[Fact]
		public void ContainsSingleArrayFilterLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("return c@.last_name;");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.ArrayFilter);
		}

		[Fact]
		public void ContainsSingleNotAndNotEqualLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("! !=");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);

			Assert.Single(result, x => x.Type == VkScriptLexemeType.Not);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.NotEqual);
		}

		[Fact]
		public void ContainsSingleLessAndLessOrEqualEqualLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("< <=");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);

			Assert.Single(result, x => x.Type == VkScriptLexemeType.Less);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.LessOrEqual);
		}

		[Fact]
		public void ContainsSingleLessAndLeftShiftLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("< <<");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);

			Assert.Single(result, x => x.Type == VkScriptLexemeType.Less);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.LeftShift);
		}

		[Fact]
		public void ContainsSingleLeftShiftAndLessOrEqualLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("<< <=");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);

			Assert.Single(result, x => x.Type == VkScriptLexemeType.LeftShift);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.LessOrEqual);
		}

		[Fact]
		public void ContainsSingleGreaterAndRightShiftLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("> >>");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);

			Assert.Single(result, x => x.Type == VkScriptLexemeType.Greater);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.RightShift);
		}

		[Fact]
		public void ContainsSingleRightAndRightFillingShiftLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse(">> >>>");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);

			Assert.Single(result, x => x.Type == VkScriptLexemeType.RightShift);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.RightFillingShift);
		}

		[Fact]
		public void ContainsSingleGreaterAndGreaterOrEqualLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse("> >=");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);

			Assert.Single(result, x => x.Type == VkScriptLexemeType.Greater);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.GreaterOrEqual);
		}

		[Fact]
		public void ContainsSingleRightShiftAndGreaterOrEqualLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse(">> >=");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);

			Assert.Single(result, x => x.Type == VkScriptLexemeType.RightShift);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.GreaterOrEqual);
		}

		[Fact]
		public void ContainsSingleRightFillingShiftAndGreaterOrEqualLexeme()
		{
			// Arrange
			var service = _mocker.CreateInstance<VkScriptLexer>();

			// Act
			var result = service.Parse(">>> >=");

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);

			Assert.Single(result, x => x.Type == VkScriptLexemeType.RightFillingShift);
			Assert.Single(result, x => x.Type == VkScriptLexemeType.GreaterOrEqual);
		}
	}
}