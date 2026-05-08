
namespace FinalProject{
    public class CraftCommand : Command{
        public CraftCommand() : base(){
            this.Name = "craft";
        }

        override
        public bool Execute(Player player){
            
            CommandHistory.Push(this);
            return false;
        }

        override 
        public void Undo(Player player){
        }
    }
}