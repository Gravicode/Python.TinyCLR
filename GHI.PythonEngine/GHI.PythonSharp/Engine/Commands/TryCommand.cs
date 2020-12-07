﻿namespace GHI.PythonSharp.Commands
{
    
    
    using System.Text;

    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;

    public class TryCommand : ICommand
    {
        private ICommand command;
        private ICommand finallyCommand;

        public TryCommand(ICommand command)
        {
            this.command = command;
        }

        public ICommand Command { get { return this.command; } }

        public ICommand Finally { get { return this.finallyCommand; } }

        public void SetFinally(ICommand finallyCommand)
        {
            this.finallyCommand = finallyCommand;
        }

        public void Execute(IContext context)
        {
            try
            {
                this.command.Execute(context);
            }
            finally
            {
                if (this.finallyCommand != null)
                    this.finallyCommand.Execute(context);
            }
        }
    }
}
