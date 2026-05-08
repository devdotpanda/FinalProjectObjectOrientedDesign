using System.Collections;
using System.Collections.Generic;

namespace FinalProject{

    public class ExamineRoomCommand : Command{

        public ExamineRoomCommand() : base(){
            this.Name = "examine";
        }

        override
        public bool Execute(Player player){
            player.ExamineRoom();

            CommandHistory.Push(this);
            return false;
        }

        override
        public void Undo(Player player){
            this.Execute(player);
        }
    }
}