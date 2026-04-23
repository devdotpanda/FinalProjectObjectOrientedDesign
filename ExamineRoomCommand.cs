using System.Collections;
using System.Collections.Generic;

namespace FinalProject{

    public class ExamineRoom : Command{

        public ExamineRoomCommand() : base(){
            this.Name = "examine";
        }

        override
        public bool Execute(Player player){
            bool answer = true;
            player.Examine();
            return answer;
        }
    }
}