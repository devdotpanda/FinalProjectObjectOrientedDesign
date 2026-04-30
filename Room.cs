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
        private ItemGenerator itemGen; 
        private List<Plant> _plantsInRoom;
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
            itemGen = new ItemGenerator();
            if(Enum.TryParse(type, out RoomType output)){
                roomType = output;
            }
        }

        public List<Plant> GeneratePlants(int PlayerStat){
            if(_plantsInRoom == null){
                _plantsInRoom = itemGen.Plants(PlayerStat, this.roomType);
            }
            return _plantsInRoom;
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

        public Plant HarvestPlant(int index){
            Plant output = null;
            if(index <= _plantsInRoom.Count){
                output = _plantsInRoom[index];
                _plantsInRoom.RemoveAt(index);
                return output;
            }else{
                return output;
            }
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
