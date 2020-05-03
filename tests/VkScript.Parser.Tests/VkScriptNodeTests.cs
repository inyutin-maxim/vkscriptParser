using Moq;
using Moq.AutoMock;
using VkScript.Parser.SyntaxTree.ControlFlow;
using VkScript.Parser.SyntaxTree.Operators.Binary;
using VkScript.Parser.Abstractions.Enums;
using VkScript.Parser.Compiler;
using VkScript.Parser.SyntaxTree.Literals;
using Xunit;

namespace VkScript.Parser.Tests
{
	public class VkScriptNodeTests
	{
		private readonly AutoMocker _mocker = new AutoMocker();

		[Fact]
		public void MultiplayOperatorNode()
		{
			var node = _mocker.CreateInstance<VkScriptMultiplayOperatorNode>();

			Assert.NotNull(node);
		}

		[Fact]
		public void DivideOperatorNode()
		{
			var node = _mocker.CreateInstance<VkScriptDivideOperatorNode>();

			Assert.NotNull(node);
		}

		[Fact]
		public void MinusOperatorNode()
		{
			var node = _mocker.CreateInstance<VkScriptMinusOperatorNode>();

			Assert.NotNull(node);
		}

		[Fact]
		public void PlusOperatorNode()
		{
			var node = _mocker.CreateInstance<VkScriptPlusOperatorNode>();

			Assert.NotNull(node);
		}

		[Fact]
		public void IfNode()
		{
			var node = _mocker.CreateInstance<VkScriptIfNode>();

			Assert.NotNull(node);
		}

		[Fact]
		public void ExcludingOrOperatorNode()
		{
			var node = _mocker.CreateInstance<VkScriptExcludingOrOperatorNode>();

			Assert.NotNull(node);
		}

		[Fact]
		public void BitOperatorNode()
		{
			var node = new VkScriptBitOperatorNode();

			Assert.NotNull(node);
		}

		[Fact]
		public void BooleanOperatorNode()
		{
			var node = new VkScriptBooleanOperatorNode();

			Assert.NotNull(node);
		}

		[Fact]
		public void ComparisonOperatorNode()
		{
			var node = new VkScriptComparisonOperatorNode();
			
			Assert.NotNull(node);
		}

		[Fact]
		public void ModulusOperatorNode()
		{
			var node = _mocker.CreateInstance<VkScriptModulusOperatorNode>();

			Assert.NotNull(node);
		}

		[Fact]
		public void ShiftOperatorNode()
		{
			var node = _mocker.CreateInstance<VkScriptShiftOperatorNode>();

			Assert.NotNull(node);
		}

		[Fact]
		public void FloatNode()
		{
			var node = new VkScriptFloatNode((float)2.0);

			Assert.NotNull(node);
			Assert.Equal((float)2.0, node.ConstantValue);
			Assert.Equal(typeof(float), node.LiteralType);
		}

		[Fact]
		public void DecimalNode()
		{
			var node = new VkScriptDecimalNode((decimal) 2.0);

			Assert.NotNull(node);
			Assert.Equal((decimal) 2.0, node.ConstantValue);
			Assert.Equal(typeof(decimal), node.LiteralType);
		}

		[Fact]
		public void CharNode()
		{
			var node = new VkScriptCharNode('3');

			Assert.NotNull(node);
			Assert.Equal('3', node.ConstantValue);
			Assert.Equal(typeof(char), node.LiteralType);
		}

		[Fact]
		public void BooleanNode()
		{
			var node = new VkScriptBooleanNode(true);

			Assert.NotNull(node);
			Assert.Equal(true, node.ConstantValue);
			Assert.Equal(typeof(bool), node.LiteralType);
		}

		[Fact]
		public void IntNode()
		{
			var node = new VkScriptIntNode(356);

			Assert.NotNull(node);
			Assert.Equal(356, node.ConstantValue);
			Assert.Equal(typeof(int), node.LiteralType);
		}

		[Fact]
		public void LongNode()
		{
			var node = new VkScriptLongNode(8786223232323488697);

			Assert.NotNull(node);
			Assert.Equal(8786223232323488697, node.ConstantValue);
			Assert.Equal(typeof(long), node.LiteralType);
		}

		[Fact]
		public void StringNode()
		{
			var node = new VkScriptStringNode("хочу в айти");

			Assert.NotNull(node);
			Assert.Equal("хочу в айти", node.ConstantValue);
			Assert.Equal(typeof(string), node.LiteralType);
		}

		[Fact]
		public void NullNode()
		{
			var node = new VkScriptNullNode();

			Assert.NotNull(node);
			Assert.Equal(typeof(NullType), node.LiteralType);
		}
	}
}