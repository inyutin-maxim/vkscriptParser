using Moq.AutoMock;
using VkScript.Parser.SyntaxTree.Operators.Binary;
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
	}
}