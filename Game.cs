using System.Collections;
using System.Collections.Generic;
using System;

namespace FinalProject
{
    /*
     * Spring 2026
     */
    public class Game
    {
        private Player _player;
        private Parser _parser;
        private bool _playing;

        public Game()
        {
            _playing = false;
            _parser = new Parser(new CommandWords());
            _player = new Player(CreateWorld());
        }

        public Room CreateWorld()
        {
            Room town = new Room("in the town square.", "standing");
            Room alchemyStore = new Room("your very own alchemy store");

            Room forest = new Room("the entrance to the forest, theres a beaten path that trails North. There is a fallen tree that seems to have fallen over either to old age or from a storm, it looks like its been there a while");
            Room FfallenTree = new Room("Its a fallen tree surrounded by overgrowth. Its quite large but it looks to have been here quite a while. It looks like a good spot for mushrooms to grow.");
            

            FfallenTree.SetExit("Back to the trail", forest);

            Room FCrossRoad = new Room("It seems the trail diverges into two paths , one goes to the left and one to the right");
            Room FRightPath = new Room("A fallen tree is blocking the path");
            Room FLeftPath = new Room("After a while of walking you notice you come up to a pond its of to the side of the path but the path continues on past and around the pond");

            FCrossRoad.SetExit("Left Path", FLeftPath);
            FCrossRoad.SetExit("Right Path ", FRightPath);
            FCrossRoad.SetExit("go back", FfallenTree);


            Room Pond = new Room("A large pond, you can see its populated with lots of fish and lots of shrubery");
            Room PFishingDock = new Room("A fishing dock, its well worn");
            Pond.SetExit("Fishing Dock", PFishingDock);
            Pond.SetExit("go Back" , FLeftPath);
            PFishingDock.SetExit("go back", Pond);
            Room DeepForest = new Room("The trees and shrubery grow thicker around you");
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

    /**
     *  Main play routine.  Loops until end of play.
     *  Although this is a basic Game Loop Design pattern
     *  you may not count it as one of your design
     *  patterns in the final project.
     */
        public void Play()
        {

            // Enter the main command loop.  Here we repeatedly read commands and
            // execute them until the game is over.
            if(_playing)
            {
                bool finished = false;
                while (!finished)
                {
                    Console.Write("\n>");
                    Command command = _parser.ParseCommand(Console.ReadLine());
                    if (command == null)
                    {
                        _player.ErrorMessage("I don't understand...");
                    }
                    else
                    {
                        finished = command.Execute(_player);
                    }
                }
            }

        }


        public void Start()
        {
            _playing = true;
            _player.InfoMessage(Welcome());
        }

        public void End()
        {
            _playing = false;
            _player.InfoMessage(Goodbye());
        }

        public string Welcome()
        {
            return "Welcome to the Town, your grandfather left you a Alchemy Store and you are incharge of running it. Go out and harvest herbs to create potions to sell!\n\nType 'help' if you need help." + _player.CurrentRoom.Description();
        }

        public string Goodbye()
        {
            return "\nThank you for playing, Goodbye. \n";
        }

    }
}
