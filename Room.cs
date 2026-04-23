using System.Collections;
using System.Collections.Generic;
using System;

namespace FinalProject
{
    public enum RoomType{
            POND,
            FOREST,
            CAVE,
            URBAN,
    }

    public class Room
    {
        private Dictionary<string, Room> _exits;
        private string _tag;
        private string _conjunction;
        private RoomType roomType;
        public string Tag { get { return _tag; } set { _tag = value; } }
        public string Conjunction { get { return _conjunction; } set { _conjunction = value; } }

        public Room() : this("empty", "in"){}
        public Room(string tag) : this(tag, "in"){}
        public Room(string type, string tag) : this(type ,tag, "in"){}

        // Designated Constructor
        public Room(string type,string tag, string conjunction)
        {
            _exits = new Dictionary<string, Room>();
            Tag = tag;
            Conjunction = conjunction;
            if(Enum.TryParse(type, out RoomType output)){
                roomType = output;
            }
        }

         public Plant[] GeneratePlants(int CurrentPerceptionLevel, GameDataManager gameData){
            
            int ceiling = (int)Math.Round(Math.Log(CurrentPerceptionLevel) * 10, MidpointRounding.ToEven);
            int floor = (int)Math.Round((2 * Math.Log(CurrentPerceptionLevel)) - 1, MidpointRounding.ToEven); 
            Random rand = new Random();
            int randNum = rand.Next(floor, ceiling + 1 );
            Plant[] output = new Plant[randNum];
            Console.WriteLine("You have Found " + randNum + " plants ");
            //GameDataManager fetch me $randNum amount of plants please from LOCATION 
            //create new list that contains only plants from LOCATION
            List<Plant> PlantsFromLocation = new List<Plant>();
            for(int i = 0; i > gameData.PlantList.Count; i++){
                if(Enum.TryParse(gameData.PlantList[i].Location, out RoomType plantLocation))
                if(plantLocation == _player.CurrentRoom.GetRoomType()){
                    PlantsFromLocation.Add(gameData.PlantList[i]);
                    Console.WriteLine(PlantsFromLocation);
                }
            }
            for(int i =0; i > randNum; i++){
                int randPlant = rand.Next(0,PlantsFromLocation.Count);
                output[i] = PlantsFromLocation[randPlant];
            }
            return output;
        }

        public void SetExit(string exitName, Room room)
        {
            _exits[exitName] = room;
        }

        public Room GetExit(string exitName)
        {
            Room room = null;
            _exits.TryGetValue(exitName, out room);
            return room;
        }

        public RoomType GetRoomType(){
            return roomType;
        }


        public string GetExits()
        {
            string exitNames = "Exits: ";
            Dictionary<string, Room>.KeyCollection keys = _exits.Keys;
            foreach (string exitName in keys)
            {
                exitNames += " " + exitName;
            }

            return exitNames;
        }


        public string Description()
        {
            return "You are " + Conjunction + " " + Tag + ".\n *** " + this.GetExits();
        }
    }
}
