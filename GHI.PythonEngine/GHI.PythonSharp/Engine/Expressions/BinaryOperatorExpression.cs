﻿namespace GHI.PythonSharp.Expressions
{
    
    
    using System.Text;
    using GHI.PythonSharp.Language;

    public class BinaryOperatorExpression : BinaryExpression
    {
        private BinaryOperator @operator;

        public BinaryOperatorExpression(IExpression left, IExpression right, BinaryOperator oper)
            : base(left, right)
        {
            this.@operator = oper;
        }

        public override object Evaluate(IContext context)
        {
            object leftvalue;
            object rightvalue;

            leftvalue = this.Left.Evaluate(context);
            rightvalue = this.Right.Evaluate(context);

            switch (this.@operator)
            {
                case BinaryOperator.Add:
                    return Numbers.Add(leftvalue, rightvalue);
                case BinaryOperator.Subtract:
                    return Numbers.Subtract(leftvalue, rightvalue);
                case BinaryOperator.Multiply:
                    if (Strings.IsString(leftvalue))
                        return Strings.Multiply(leftvalue, rightvalue);
                    return Numbers.Multiply(leftvalue, rightvalue);
                case BinaryOperator.Divide:
                    return Numbers.Divide(leftvalue, rightvalue);
                case BinaryOperator.Power:
                    return (int)(System.Math.Pow((double)leftvalue, (double)rightvalue));
            }

            throw new System.InvalidOperationException();
        }
    }
}
