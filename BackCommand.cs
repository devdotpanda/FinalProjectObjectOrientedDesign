
namespace FinalProject{
    public class BackCommand : Command {
        public BackCommand() : base(){
            this.Name = ("back");
        }
        
        
        override
        public bool Execute(Player player){
            if(CommandHistory.Count > 1){
                
                Command lastCommand = CommandHistory.Pop();
                Console.WriteLine("Command History count : " + CommandHistory.Count);
                Console.WriteLine(lastCommand.Name + " : " + lastCommand._parameters[0]);
                lastCommand.Undo(player);
            }else{
               player.WarningMessage("Cant go Back");
            }
            return false;
            
        }


        override 
        public void Undo(Player player){
        }
    }
}