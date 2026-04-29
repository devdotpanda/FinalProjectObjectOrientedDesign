
namespace FinalProject{
    public sealed class GameWorld{

        private GameWorld(){}

        private static GameWorld _instance;
        private static readonly object _lock = new object();

        public static GameWorld Instance(){
            if(_instance == null){
                lock (_lock){
                    if(_instance == null){
                        _instance = new GameWorld();
                    }
                }
            }
            return _instance;
        }        
        
        public Room CreateWorld()
        {   
            Room town = new Room("URBAN","in the town square.", "standing");
            Room alchemyStore = new Room("URBAN","your very own alchemy store");

            Room forest = new Room("FOREST","the entrance to the forest, theres a beaten path that trails North. There is a fallen tree that seems to have fallen over either to old age or from a storm, it looks like its been there a while");
            Room FfallenTree = new Room("FOREST","Its a fallen tree surrounded by overgrowth. Its quite large but it looks to have been here quite a while. It looks like a good spot for mushrooms to grow.");
            
            FfallenTree.SetExit("Back to the trail", forest);

            Room FCrossRoad = new Room("FOREST","It seems the trail diverges into two paths , one goes to the left and one to the right");
            Room FRightPath = new Room("FOREST","A fallen tree is blocking the path");
            Room FLeftPath = new Room("FOREST","After a while of walking you notice you come up to a pond its of to the side of the path but the path continues on past and around the pond");

            FCrossRoad.SetExit("Left Path", FLeftPath);
            FCrossRoad.SetExit("Right Path ", FRightPath);
            FCrossRoad.SetExit("go back", FfallenTree);


            Room Pond = new Room("POND","A large pond, you can see its populated with lots of fish and lots of shrubery");
            Room PFishingDock = new Room("POND","A fishing dock, its well worn");
            Pond.SetExit("Fishing Dock", PFishingDock);
            Pond.SetExit("go Back" , FLeftPath);
            PFishingDock.SetExit("go back", Pond);
            Room DeepForest = new Room("FOREST","The trees and shrubery grow thicker around you");
            DeepForest.SetExit("go back", FLeftPath); 
            FLeftPath.SetExit("Pond", Pond);
            FLeftPath.SetExit("Deep Forest", DeepForest);
            FLeftPath.SetExit("go back", FCrossRoad);
            //forest.SetExit("North", );
            forest.SetExit("FallenTree", FfallenTree);
            


            town.SetExit("Forest", forest);
            town.SetExit("alchemyStore",alchemyStore);

            alchemyStore.SetExit("Town",town);

            forest.SetExit("Town",town);

            return town;
        }
    }
}