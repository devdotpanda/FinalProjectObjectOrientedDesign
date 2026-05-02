using System.Collections;
using System.Collections.Generic;

namespace FinalProject
{
    /*
     * Fall 2025
     */
    public class QuitCommand : Command
    {

        public QuitCommand() : base()
        {
            this.Name = "quit";
        }

        override
        public bool Execute(Player player)
        {
            bool answer = true;
            if (_parameters.Count > 0)
            {
                player.WarningMessage("\nI cannot quit " + _parameters[0]);
                answer = false;
            }
            return answer;
        }
    }
}
