﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkScript.Parser.SyntaxTree;

namespace VkScript.Parser.Compiler
{
	/// <summary>
    /// A cache-friendly version of type signature.
    /// </summary>
	public class TypeSignature : LocationEntity
    {
        #region Constructors

        public TypeSignature(string name, params TypeSignature[] args)
            : this(name, null, args)
        {
        }

        public TypeSignature(string name, string postfix, params TypeSignature[] args)
        {
            Name = name;
            Arguments = args.Length > 0 ? args : null;
            Postfix = postfix;
            FullSignature = GetSignature(name, args);
        }

        #endregion

        #region Static fields

        /// <summary>
        /// List of available postfixes.
        /// </summary>
        private static readonly string[] Postfixes = {"[]", "?", "~"};

        #endregion

        #region Fields

        /// <summary>
        /// The name of the type. Like 'int', or 'Dictionary'.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// List of generic argument type signatures (if any).
        /// </summary>
        public readonly TypeSignature[] Arguments;

        /// <summary>
        /// Special postfix character:
        /// [] = array,
        /// ? = Nullable
        /// ~ = IEnumerable
        /// </summary>
        public readonly string Postfix;

        /// <summary>
        /// Complete signature with all arguments, postfixes, etc.
        /// </summary>
        public readonly string FullSignature;

        #endregion

        #region Static constructors

        /// <summary>
        /// Initializes a type signature with it's string representation.
        /// </summary>
        public static implicit operator TypeSignature(string type)
        {
            return type == null ? null : Parse(type);
        }

        /// <summary>
        /// Parses the type signature.
        /// </summary>
        public static TypeSignature Parse(string signature)
        {
            if (signature[0] == ' ' || signature[signature.Length - 1] == ' ')
                signature = signature.Trim();

            foreach (var postfix in Postfixes)
                if (signature.EndsWith(postfix))
                    return new TypeSignature(null, postfix, Parse(signature.Substring(0, signature.Length - postfix.Length)));

            var open = signature.IndexOf('<');
            if (open == -1)
                return new TypeSignature(signature);

            var close = signature.LastIndexOf('>');
            var args = ParseTypeArgs(signature.Substring(open + 1, close - open - 1)).ToArray();
            var typeName = signature.Substring(0, open);

            return new TypeSignature(typeName, args);
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Builds the full string representation of the signature tree.
        /// </summary>
        private string GetSignature(string name, TypeSignature[] args)
        {
            if (args.Length == 0)
                return name;

            if (!string.IsNullOrEmpty(Postfix))
                return Arguments[0].FullSignature + Postfix;

            var sb = new StringBuilder(name);
            sb.Append("<");

            var idx = 0;
            foreach (var curr in args)
            {
                if (idx > 0)
                    sb.Append(", ");

                sb.Append(curr.FullSignature);

                idx++;
            }

            sb.Append(">");

            return sb.ToString();
        }

        /// <summary>
        /// Parses out the list of generic type arguments delimited by commas.
        /// </summary>
        private static IEnumerable<TypeSignature> ParseTypeArgs(string args)
        {
            var depth = 0;
            var start = 0;
            var len = args.Length;
            for (var idx = 0; idx < len; idx++)
            {
                if (args[idx] == '<') depth++;
                if (args[idx] == '>') depth--;
                if (depth == 0 && args[idx] == ',')
                {
                    yield return Parse(args.Substring(start, idx - start));
                    start = idx + 1;
                }
            }

            yield return Parse(args.Substring(start, args.Length - start));
        }

        #endregion

        #region Debug

        public override string ToString()
        {
            return FullSignature;
        }

        #endregion

        #region Equality

        protected bool Equals(TypeSignature other)
        {
            var basic = string.Equals(Name, other.Name)
                        && string.Equals(Postfix, other.Postfix);

            if (!basic || (Arguments == null ^ other.Arguments == null))
                return false;

            return Arguments == null || Arguments.SequenceEqual(other.Arguments);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TypeSignature) obj);
        }

        public override int GetHashCode()
        {
            return FullSignature.GetHashCode();
        }

        #endregion
    }
}