using System.Collections;
using System.Collections.Generic;
using System;

namespace FinalProject
{
    /*
     * Spring 2026
     * The is your *actor* in the Command Design
     * pattern. The instance of this class should
     * execute all the commands.
     */
    public class Player
    {
        private Room _currentRoom = null;
        private int[] playerStats;
        private List<IItem> inventory;
        public Room CurrentRoom { get { return _currentRoom; } set { _currentRoom = value; } }

        public Player(Room room, int[] stats)
        {
            _currentRoom = room;
            playerStats = stats;
            inventory = new List<IItem>();
        }

        public void WalkTo(string direction)
        {
            Room nextRoom = CurrentRoom.GetExit(direction);
            if (nextRoom != null)
            {
                CurrentRoom = nextRoom;
                NormalMessage("\n" + this.CurrentRoom.Description());
            }
            else
            {
                ErrorMessage("\nThere is no door on " + direction);
            }
        }

        public void ExamineRoom(){
            List<Plant> generatedPlants = CurrentRoom.GeneratePlants(2);
            if(generatedPlants != null){
                    Console.WriteLine("~~~YOU HAVE FOUND " + generatedPlants.Count + " PLANTS~~~");
                Console.WriteLine("______________________________");
                for(int i = 0; i < generatedPlants.Count; i++){
                    Console.WriteLine(" | " + i + "." + generatedPlants[i].Name + " \t| ");
                }
                Console.WriteLine("______________________________");
            }else{
                Console.WriteLine("~~~YOU HAVE FOUND~~~\n\n Nothing....");
            }
            
            
        }

        public void Harvest(int index){
            Plant harvestedPlant = CurrentRoom.HarvestPlant(index);
            if(harvestedPlant == null){
                Console.WriteLine("Please enter a valid index");
            }else{
                Console.WriteLine("You collected 1 : " + harvestedPlant.Name );
                inventory.Add(harvestedPlant);
            }
        }

        public void ListInventory(){
             Console.WriteLine("  ~~~~INVENTORY~~~~");
            foreach(IItem item in inventory){
                Console.WriteLine("| "+item.Name + " x" + item.Amount + "\t|");
            }
            Console.WriteLine("______________________________");

        }

        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ColoredMessage(string message, ConsoleColor newColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = newColor;
            OutputMessage(message);
            Console.ForegroundColor = oldColor;
        }

        public void NormalMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.White);
        }

        public void InfoMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.Blue);
        }

        public void WarningMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.DarkYellow);
        }

        public void ErrorMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.Red);
        }

    }


 
}
