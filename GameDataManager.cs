using System;
using Newtonsoft.Json;

namespace FinalProject { 
    public class GameDataManager{
        private string _plantList;
        private String _playerStats;
        private string _playerInventory;

        private string _playerStatsDir;
        private string _playerInventoryDir;
        private readonly string _plantListDir;
        
        public List<Plant> PlantList;
        public int[] PlayerStats;




        public GameDataManager(){
            _playerStatsDir = "PlayerStats.json";
            _playerInventoryDir = "PlayerInventory.csv";
            _plantListDir = "ItemList.json";

            using StreamReader PlantReader = new(_plantListDir);
            var json = PlantReader.ReadToEnd();
            var List = JsonConvert.DeserializeObject<List<Plant>>(json);
            PlantList = List;

            using StreamReader StatReader = new(_playerStats);
            var text = StatReader.ReadToEnd();
            Console.WriteLine(text);
        }


    }
}