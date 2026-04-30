
namespace FinalProject{
    public class ViewInventoryCommand : Command { 
        public ViewInventoryCommand() : base(){
            this.Name = "inventory";
        }

        override
        public bool Execute(Player player){
            player.ListInventory();
            return false;
        }
    }
}