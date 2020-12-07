namespace GHI.PythonSharp.Language
{
    using System;
    
    
    using System.Text;
    using GHI.PythonSharp.Expressions;

    public class Parameter
    {
        private string name;
        private object defaultValue;
        private bool isList;

        public Parameter(string name, object defaultValue, bool isList)
        {
            this.name = name;
            this.defaultValue = defaultValue;
            this.isList = isList;
        }

        public string Name { get { return this.name; } }

        public object DefaultValue { get { return this.defaultValue; } }

        public bool IsList { get { return this.isList; } }
    }
}
