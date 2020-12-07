﻿namespace GHI.PythonSharp.Expressions
{
    using System;
    
    
    using System.Text;
    using GHI.PythonSharp.Language;

    public class ParameterExpression : IExpression
    {
        private string name;
        private IExpression defaultExpression;
        private bool isList;

        public ParameterExpression(string name, IExpression defaultExpression, bool isList)
        {
            this.name = name;
            this.defaultExpression = defaultExpression;
            this.isList = isList;
        }

        public string Name { get { return this.name; } }

        public IExpression DefaultExpression { get { return this.defaultExpression; } }

        public bool IsList { get { return this.isList; } }

        public object Evaluate(IContext context)
        {
            object defaultValue = null;

            if (this.defaultExpression != null)
                defaultValue = this.defaultExpression.Evaluate(context);

            return new Parameter(this.name, defaultValue, this.isList);
        }
    }
}
