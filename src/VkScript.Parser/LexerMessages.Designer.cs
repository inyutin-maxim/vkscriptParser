﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VkScript.Parser {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LexerMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LexerMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VkScript.Parser.LexerMessages", typeof(LexerMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LE1001: Неожиданный уровень блока!.
        /// </summary>
        internal static string InconsistentIdentation {
            get {
                return ResourceManager.GetString("InconsistentIdentation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LE1006: Недопустимый символьный литерал!.
        /// </summary>
        internal static string IncorrectCharLiteral {
            get {
                return ResourceManager.GetString("IncorrectCharLiteral", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LE1002: Символы табуляции недопустимы в исходном коде! Используйте пробелы для выделения блоков кода..
        /// </summary>
        internal static string TabChar {
            get {
                return ResourceManager.GetString("TabChar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LE1003: Строка не закрыта!.
        /// </summary>
        internal static string UnclosedString {
            get {
                return ResourceManager.GetString("UnclosedString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LE1004: Неизвестная экранированная последовательность: \{0}!.
        /// </summary>
        internal static string UnknownEscape {
            get {
                return ResourceManager.GetString("UnknownEscape", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LE1005: Неизвестный тип лексемы!.
        /// </summary>
        internal static string UnknownLexeme {
            get {
                return ResourceManager.GetString("UnknownLexeme", resourceCulture);
            }
        }
    }
}
