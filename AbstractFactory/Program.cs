using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeFactory mazeFactory = new MazeFactory();

            MazeGame mazeGame = new MazeGame();
            Maze aMaze = mazeGame.CreateMaze(mazeFactory);

            Console.WriteLine(aMaze.ToString());

            EnchantedMazeFactory enchantedMazeFactory = new EnchantedMazeFactory();

            Maze aEnchantedMaze = mazeGame.CreateMaze(enchantedMazeFactory);

            Console.WriteLine(aEnchantedMaze.ToString());

            BombedMazeFactory bombedMazeFactory = new BombedMazeFactory();

            Maze aMazeWithABomb = mazeGame.CreateMaze(bombedMazeFactory);

            Console.WriteLine(aMazeWithABomb.ToString());
        }
    }
}
