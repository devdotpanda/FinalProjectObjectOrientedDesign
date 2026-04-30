

namespace FinalProject{
    public class ItemGenerator{

        private GameDataManager _gameData;
        private List<Plant> _plantList;

        public ItemGenerator(){
            _gameData = GameDataManager.Instance();
            _plantList = _gameData.PlantList;
        }

        public List<Plant> PlantList{
            get { return _plantList;}
        }

        public List<Plant> Plants(int CurrentPerceptionLevel, RoomType Location){
            int ceiling = (int)Math.Round(Math.Log(CurrentPerceptionLevel) * 10, MidpointRounding.ToEven);
            int floor = (int)Math.Round((2 * Math.Log(CurrentPerceptionLevel)) - 1, MidpointRounding.ToEven); 
            Random rand = new Random();
            int randNum = rand.Next(floor, ceiling + 1 );
            List<Plant> output = new List<Plant>();
            //_gameDataManager fetch me $randNum amount of plants please from LOCATION 
            //create new list that contains only plants from LOCATION
            List<Plant> PlantsFromLocation = new List<Plant>();
            for(int i = 0; i <  _plantList.Count; i++){
                if(Enum.TryParse(_plantList[i].Location, out RoomType plantLocation)){
                     if(plantLocation == Location){
                        PlantsFromLocation.Add(_plantList[i]);
                    }
                }
            }
            if(PlantsFromLocation.Count > 0 ){
                for(int j = 0; j < randNum; j++){
                    int randPlant = rand.Next(0,PlantsFromLocation.Count);
                    output.Add(PlantsFromLocation[randPlant]);
                }      
            }else { 
                return null;
            }
            return output;
        }

    }
}