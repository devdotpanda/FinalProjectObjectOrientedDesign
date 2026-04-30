using System.Collections;

namespace FinalProject{
    public class HarvestCommand : Command{
        public HarvestCommand() : base(){
            this.Name = "harvest";
        }

        override
        public bool Execute(Player player) {
            try{
                if(this.HasSecondWord()){
                    player.Harvest(Int32.Parse(this.SecondWord));
                }else{
                    player.WarningMessage("\n Harvest what?");
                }
                return false;
            }catch (FormatException e){
                player.WarningMessage("\n Please type a number");
                return false;
            }
        }
    }
}