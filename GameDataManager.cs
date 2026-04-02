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


        public GameDataManager(){
            _playerStatsDir = "PlayerStats.json";
            _playerInventoryDir = "PlayerInventory.csv";
            _plantListDir = "ItemList.json";
        }

        public List<Plant> ReadAndParseGameData(){
            using StreamReader reader = new(_plantListDir);
            var json = reader.ReadToEnd();
            var Plants = JsonConvert.DeserializeObject<List<Plant>>(json);
            
            return Plants;
        }


    }
}