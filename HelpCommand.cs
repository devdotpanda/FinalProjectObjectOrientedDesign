using System.Collections;
using System.Collections.Generic;

namespace FinalProject
{
    /*
     * Fall 2025
     */
    public class HelpCommand : Command
    {
        private CommandWords _words;

        public HelpCommand() : this(new CommandWords()){}

        // Designated Constructor
        public HelpCommand(CommandWords commands) : base()
        {
            _words = commands;
            this.Name = "help";
        }

        override
        public bool Execute(Player player)
        {
            if (_parameters.Count > 0)
            {
                player.WarningMessage("\nI cannot help you with " + _parameters[0]);
            }
            else
            {
                player.InfoMessage("\n Go and explore the world!!\n Try to harvest as many plants as you can! \n\nYour available commands are " + _words.Description());
            }
            return false;
        }
    }
}
