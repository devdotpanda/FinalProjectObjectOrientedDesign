using System;
using Newtonsoft.Json;

namespace FinalProject { 
    public class GameDataManager{
        
        private static GameDataManager _instance;
        private static readonly object _lock = new object();

        private string _playerStatsDir;
        private string _playerInventoryDir;
        private string _plantListDir;
        
        private List<Plant> _plantList;
        private int[] _playerStats;

        public static GameDataManager Instance(){
            if(_instance == null){
                lock (_lock){
                    if(_instance == null){
                        _instance = new GameDataManager();
                    }
                }
            }
            return _instance;
        }




        public GameDataManager(){
            _playerStatsDir = "PlayerStats.txt";
            _playerInventoryDir = "PlayerInventory.csv";
            _plantListDir = "PlantList.json";

            using StreamReader PlantReader = new(_plantListDir);
            var json = PlantReader.ReadToEnd();
            var List = JsonConvert.DeserializeObject<List<Plant>>(json);
            _plantList = List;

            using StreamReader StatReader = new(_playerStatsDir);
            var text = StatReader.ReadToEnd();
        }

        public List<Plant> PlantList{
            get{
                return _plantList;
            }
        }

        public int[] PlayerStats{
            get{
                return _playerStats;
            }
        }

    }
}