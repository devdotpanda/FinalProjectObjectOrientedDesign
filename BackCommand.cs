
namespace FinalProject{
    public class BackCommand : Command {
        public BackCommand() : base(){
            this.Name = ("back");
        }
        
        
        override
        public bool Execute(Player player){
            Command lastCommand = CommandHistory.Pop();
            lastCommand.Undo();
            return false;
        }

        override
        public bool Undo(){

            return false;
        }
    }
}