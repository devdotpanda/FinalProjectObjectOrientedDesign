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

        private Room lastRoom;

        override
        public bool Execute(Player player){
            lastRoom = player.CurrentRoom;
            if(_parameters.Count > 0){
                player.WalkTo(_parameters[0]);
            }
            CommandHistory.Push(this);
            return false;
        }

        override
        public void Undo(Player player){
            player.CurrentRoom = lastRoom;
        }
    }
}
