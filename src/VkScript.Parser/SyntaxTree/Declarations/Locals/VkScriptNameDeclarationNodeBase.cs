using VkScript.Parser.Abstractions;
using VkScript.Parser.Compiler;

namespace VkScript.Parser.SyntaxTree.Declarations.Locals
{
	public class VkScriptNameDeclarationNodeBase : VkScriptSyntaxNode
	{
	#region Constructor

		protected VkScriptNameDeclarationNodeBase(string name, bool immutable)
		{
			Name = name;
			IsImmutable = immutable;
		}

	#endregion

	#region Fields

		/// <summary>
		/// Имя переменной.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Явно указанная локальная переменная.
		/// </summary>
		public Local Local { get; set; }

		/// <summary>
		/// Тип подписи для неинициализированных переменных.
		/// </summary>
		public TypeSignature Type { get; set; }

		/// <summary>
		/// Значение, присваиваемое переменной.
		/// </summary>
		public VkScriptSyntaxNode Value { get; set; }

		/// <summary>
		/// Флаг, указывающий, что текущее значение доступно только для чтения.
		/// </summary>
		public readonly bool IsImmutable;

	#endregion

	#region Debug

		protected bool Equals(VkScriptNameDeclarationNodeBase other)
		{
			return IsConstant.Equals(other.IsConstant) && string.Equals(Name, other.Name) && Equals(Value, other.Value);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;

			return Equals((VkScriptNameDeclarationNodeBase) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = IsConstant.GetHashCode();
				hashCode = (hashCode * 397)^(Name != null ? Name.GetHashCode() : 0);
				hashCode = (hashCode * 397)^(Value != null ? Value.GetHashCode() : 0);

				return hashCode;
			}
		}

		public override string ToString()
		{
			return $"{(IsImmutable ? "let" : "var")}({Name} = {Value})";
		}

	#endregion
	}
}