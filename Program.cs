using System;

namespace FinalProject
{
    /*
     * Spring 2026
     */
    class Program
    {
        static void Main(string[] args)
        {
            // This is the top level of the application
            //Game game = new Game();
            //game.Start();
            //game.Play();
            //game.End();

            GameDataManager data = new GameDataManager();
            List<Plants> plants = data.ReadAndParseGameData();
            Console.WriteLine(plants);
        }
    }
}
