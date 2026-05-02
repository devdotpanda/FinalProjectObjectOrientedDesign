using System.Collections;
using System.Collections.Generic;

namespace FinalProject
{
    /*
     * Fall 2025
     */
    public class GoCommand : Command
    {

        public GoCommand() : base()
        {
            this.Name = "go";
        }

        override
        public bool Execute(Player player){
            if(_parameters.Count > 0){
                player.WalkTo(_parameters[0]);
            }
            return false;
        }
    }
}
