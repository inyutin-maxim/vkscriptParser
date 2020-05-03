using Moq;
using Moq.AutoMock;
using VkScript.Parser.SyntaxTree.ControlFlow;
using VkScript.Parser.SyntaxTree.Operators.Binary;
using VkScript.Parser.Abstractions.Enums;
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
	}
}