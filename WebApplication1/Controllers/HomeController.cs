using AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MazeFactory mazeFactory = new MazeFactory();

            MazeGame mazeGame = new MazeGame();
            Maze aMaze = mazeGame.CreateMaze(mazeFactory);

            return View(aMaze);
        }

        public ActionResult EnchantedMaze()
        {
            EnchantedMazeFactory enchantedMazeFactory = new EnchantedMazeFactory();

            MazeGame mazeGame = new MazeGame();
            Maze aEnchantedMaze = mazeGame.CreateMaze(enchantedMazeFactory);

            return View(aEnchantedMaze);
        }

        public ActionResult MazeWithABomb()
        {
            BombedMazeFactory bombedMazeFactory = new BombedMazeFactory();

            MazeGame mazeGame = new MazeGame();
            Maze aMazeWithABomb = mazeGame.CreateMaze(bombedMazeFactory);

            return View(aMazeWithABomb);
        }
    }
}