namespace GHI.PythonSharp.Commands
{
    using System.Collections;
    using System.Text;
    using GHI.PythonSharp.Exceptions;
    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;

    public class ForCommand : ICommand
    {
        private string name;
        private IExpression expression;
        private ICommand command;

        public ForCommand(string name, IExpression expression, ICommand command)
        {
            this.name = name;
            this.expression = expression;
            this.command = command;
        }

        public IExpression Expression { get { return this.expression; } }

        public ICommand Command { get { return this.command; } }

        public void Execute(IContext context)
        {
            var environment = context as BindingEnvironment;
            var value = this.expression.Evaluate(context);
            var items = value as IEnumerable;

            if (items == null)
                throw new TypeError(string.Format("'{0}' object is not iterable", Types.GetTypeName(value)));

            foreach (var item in items)
            {
                context.SetValue(this.name, item);
                this.command.Execute(context);
                if (environment != null)
                {
                    if (environment.HasReturnValue())
                        return;

                    if (environment.WasBreak)
                    {
                        environment.WasBreak = false;
                        break;
                    }

                    if (environment.WasContinue)
                        environment.WasContinue = false;
                }
            }
        }
    }
}

