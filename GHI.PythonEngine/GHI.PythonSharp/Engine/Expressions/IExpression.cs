namespace GHI.PythonSharp.Expressions
{
    
    
    using System.Text;
    using GHI.PythonSharp.Language;

    public interface IExpression
    {
        object Evaluate(IContext context);
    }
}
