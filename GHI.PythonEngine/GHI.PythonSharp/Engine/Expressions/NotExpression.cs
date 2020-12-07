﻿namespace GHI.PythonSharp.Expressions
{
    using System;
    
    
    using System.Text;
    using GHI.PythonSharp.Language;

    public class NotExpression : IExpression
    {
        private IExpression expression;

        public NotExpression(IExpression expression)
        {
            this.expression = expression;
        }

        public IExpression Expression { get { return this.expression; } }

        public object Evaluate(IContext context)
        {
            return Predicates.IsFalse(this.expression.Evaluate(context));
        }
    }
}
