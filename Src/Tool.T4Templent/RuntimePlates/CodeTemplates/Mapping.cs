﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本: 14.0.0.0
//  
//     对此文件的更改可能导致不正确的行为，如果
//     重新生成代码，则所做更改将丢失。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Tool.T4Templent.RuntimePlates.CodeTemplates
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class Mapping : MappingBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(" ");
            this.Write(" ");
            this.Write(" ");
            this.Write("using System.Data.Entity.ModelConfiguration;\r\nusing ");
            
            #line 6 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NameSpace));
            
            #line default
            #line hidden
            this.Write(".Models.Model;\r\nnamespace ");
            
            #line 7 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(NameSpace));
            
            #line default
            #line hidden
            this.Write(".Models.Mapping\r\n{\r\n\tpublic class ");
            
            #line 9 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Map : EntityTypeConfiguration<");
            
            #line 9 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(">\r\n\t{\r\n        public ");
            
            #line 11 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("Map()\r\n        {\r\n\t\t\t");
            
            #line 13 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
 foreach(var filed in Fileds)
			{
			if(filed.IsPrimaryKey){
            
            #line default
            #line hidden
            this.Write("this.HasKey(t => t.");
            
            #line 15 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(filed.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\t\t");
            
            #line 16 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
} else if(filed.Type=="string")
			{
            
            #line default
            #line hidden
            this.Write("this.Property(t => t.");
            
            #line 17 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(filed.Name));
            
            #line default
            #line hidden
            this.Write(")");
            
            #line 17 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
 if(filed.IsNullable==1||filed.Length==-1){
            
            #line default
            #line hidden
            this.Write(".IsRequired()");
            
            #line 17 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
}
            
            #line default
            #line hidden
            
            #line 17 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
 if(filed.Length>0){
            
            #line default
            #line hidden
            this.Write(".HasMaxLength(");
            
            #line 17 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(filed.Length/2));
            
            #line default
            #line hidden
            this.Write(")");
            
            #line 17 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
}
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\t");
            
            #line 18 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
} 
			}
            
            #line default
            #line hidden
            this.Write("\t\t\tthis.ToTable(\"");
            
            #line 20 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\");\r\n\t\t\t");
            
            #line 21 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
 foreach(var filed in Fileds)
			{
            
            #line default
            #line hidden
            this.Write("this.Property(t => t.");
            
            #line 22 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(filed.Name));
            
            #line default
            #line hidden
            this.Write(").HasColumnName(\"");
            
            #line 22 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(filed.Name));
            
            #line default
            #line hidden
            this.Write("\"); \r\n\t\t\t");
            
            #line 23 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"
}
            
            #line default
            #line hidden
            this.Write("          \r\n        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "E:\github\PlanWeb\Src\Tool.T4Templent\RuntimePlates\CodeTemplates\Mapping.tt"

private string _ClassNameField;

/// <summary>
/// Access the ClassName parameter of the template.
/// </summary>
private string ClassName
{
    get
    {
        return this._ClassNameField;
    }
}

private global::System.Collections.Generic.List<Tool.T4Templent.ServiceAndDto.Filed>  _FiledsField;

/// <summary>
/// Access the Fileds parameter of the template.
/// </summary>
private global::System.Collections.Generic.List<Tool.T4Templent.ServiceAndDto.Filed>  Fileds
{
    get
    {
        return this._FiledsField;
    }
}

private string _NameSpaceField;

/// <summary>
/// Access the NameSpace parameter of the template.
/// </summary>
private string NameSpace
{
    get
    {
        return this._NameSpaceField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool ClassNameValueAcquired = false;
if (this.Session.ContainsKey("ClassName"))
{
    this._ClassNameField = ((string)(this.Session["ClassName"]));
    ClassNameValueAcquired = true;
}
if ((ClassNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ClassName");
    if ((data != null))
    {
        this._ClassNameField = ((string)(data));
    }
}
bool FiledsValueAcquired = false;
if (this.Session.ContainsKey("Fileds"))
{
    this._FiledsField = ((global::System.Collections.Generic.List<Tool.T4Templent.ServiceAndDto.Filed> )(this.Session["Fileds"]));
    FiledsValueAcquired = true;
}
if ((FiledsValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Fileds");
    if ((data != null))
    {
        this._FiledsField = ((global::System.Collections.Generic.List<Tool.T4Templent.ServiceAndDto.Filed> )(data));
    }
}
bool NameSpaceValueAcquired = false;
if (this.Session.ContainsKey("NameSpace"))
{
    this._NameSpaceField = ((string)(this.Session["NameSpace"]));
    NameSpaceValueAcquired = true;
}
if ((NameSpaceValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("NameSpace");
    if ((data != null))
    {
        this._NameSpaceField = ((string)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class MappingBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
