namespace GHI.PythonSharp.Commands
{
    using System;
    using System.Collections;
    using System.Text;
    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;

    public class CompositeCommand : ICommand
    {
        //private IList<ICommand> commands;
        private ArrayList commands;

        public CompositeCommand()
        {
            this.commands = new  ArrayList();
        }

        public CompositeCommand(ArrayList commands)
        {
            this.commands = commands;
        }

        public ArrayList Commands { get { return this.commands; } }

        public void AddCommand(ICommand command)
        {
            this.commands.Add(command);
        }

        public void Execute(IContext context)
        {
            BindingEnvironment environment = context as BindingEnvironment;

            foreach (ICommand command in this.commands)
            {
                command.Execute(context);
                if (environment != null && (environment.HasReturnValue() || environment.WasContinue || environment.WasBreak))
                    break;
            }
        }

        public string GetDocString()
        {
            if (this.commands == null || this.commands.Count == 0)
                return null;

            var first = this.commands[0];

            if (!(first is ExpressionCommand))
                return null;

            var exprcmd = (ExpressionCommand)first;

            if (!(exprcmd.Expression is ConstantExpression))
                return null;

            var consexpr = (ConstantExpression)exprcmd.Expression;

            if (consexpr.Value == null || !(consexpr.Value is string))
                return null;

            var str = (string)consexpr.Value;

            this.commands.RemoveAt(0);

            return str;
        }
    }
}
