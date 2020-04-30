using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq.AutoMock;
using VkScript.Parser.Abstractions;
using VkScript.Parser.SyntaxTree.Operators.Binary;
using Xunit;

namespace VkScript.Parser.Tests
{
	public class VkScriptNodeTests
	{
		private readonly AutoMocker _mocker = new AutoMocker();

		[Fact]
		public void MultyPlayOperatorNode()
		{
			var node = _mocker.CreateInstance<VkScriptMultiplayOperatorNode>();

			Assert.NotNull(node);
		}
	}
}
