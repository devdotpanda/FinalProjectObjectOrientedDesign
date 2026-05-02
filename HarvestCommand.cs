using System.Collections;

namespace FinalProject{
    public class HarvestCommand : Command{
        public HarvestCommand() : base(){
            this.Name = "harvest";
        }

        override
        public bool Execute(Player player) {
            try{
                if(_parameters.Count > 0){
                    player.Harvest(Int32.Parse(_parameters[0]));
                }else{
                    player.WarningMessage("\n Harvest what?");
                }
                return false;
            }catch (FormatException e){
                if(_parameters[0] == "all"){
                    player.Harvest(-1);
                }else{
                    Console.WriteLine("Please type in an number or type all to collect all plants in room");
                }
                return false;
            }
        }
    }
}