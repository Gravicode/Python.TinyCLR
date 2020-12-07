﻿namespace GHI.PythonSharp.Expressions
{
    using System;
    
    
    using System.Text;
    using Microsoft.VisualBasic.CompilerServices;
    using GHI.PythonSharp.Language;

    public class BooleanExpression : BinaryExpression
    {
        private BooleanOperator operation;

        public BooleanExpression(IExpression left, IExpression right, BooleanOperator operation)
            : base(left, right)
        {
            this.operation = operation;
        }

        public BooleanOperator Operation { get { return this.operation; } }

        public override object Evaluate(IContext context)
        {            
            object leftvalue;
            object rightvalue;

            leftvalue = this.Left.Evaluate(context);

            if (this.operation == BooleanOperator.Or)
            {
                if (!Predicates.IsFalse(leftvalue))
                    return true;
            }
            else if (Predicates.IsFalse(leftvalue))
                return false;

            rightvalue = this.Right.Evaluate(context);

            return !Predicates.IsFalse(rightvalue);
        }
    }
}
