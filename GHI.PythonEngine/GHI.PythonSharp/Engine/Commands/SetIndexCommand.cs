﻿namespace GHI.PythonSharp.Commands
{
    using System;
    
    
    using System.Text;
    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;
    using GHI.PythonSharp.Utilities;

    public class SetIndexCommand : ICommand
    {
        private IExpression targetExpression;
        private IExpression indexExpression;
        private IExpression expression;

        public SetIndexCommand(IExpression targetExpression, IExpression indexExpression, IExpression expression)
        {
            this.targetExpression = targetExpression;
            this.indexExpression = indexExpression;
            this.expression = expression;
        }

        public IExpression TargetExpression { get { return this.targetExpression; } }

        public IExpression IndexExpression { get { return this.indexExpression; } }

        public IExpression Expression { get { return this.expression; } }

        public void Execute(IContext context)
        {
            var target = this.targetExpression.Evaluate(context);
            var index = this.indexExpression.Evaluate(context);
            var value = this.expression.Evaluate(context);

            ObjectUtilities.SetIndexedValue(target, new object[] { index }, value);
        }
    }
}
