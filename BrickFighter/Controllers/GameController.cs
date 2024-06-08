using BrickFighter.Scenes;
using BrickFighter.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickFighter.Controllers
{
    public class GameController
    {
        public int curentLevel { get; private set; } = 1; //on commence par lvl 1
        public int maxLevel { get; private set; } = 0;
        public int score { get; private set; } = 0;
        //public int buff { get; private set; } = 0;
        public List<string> inventory { get; private set; }
        public int lifes { get; private set; } = 3; // on a trois vies

        public GameController()
        {
            ServiceLocator.Register(this);
            maxLevel = CountLevels();
        }

        public void Reset()
        {
            curentLevel = 1;
            score = 0;
            lifes = 3;
            inventory = new List<string>();
        }

        public void LevelUp()
        {
            curentLevel++;
        }

        public void BallOut()
        {
            var sm = ServiceLocator.Get<ISceneManager>();

            lifes--;
            if (lifes == 0)
            {
                //sm.Load<FightScene>();
            }
        }

        /*public void AddBuff(string type)
        {
            if (type == "armor") { }
            if (type == "magic") { }
            if (type == "sword") { }
        }*/

        public int[,] GetBricksLayout()
        {
            string filePath = $"Levels/Level{curentLevel}.txt";
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null) { lines.Add(line); }
            }

            int rows = lines.Count;
            int cols = lines[0].Length;
            int[,] bricksLayout = new int[cols, rows];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char ch = lines[row][col];
                    bricksLayout[col, row] = ch == '1' ? 1 : ch == '2' ? 2 : ch == '3' ? 3 : ch == '4' ? 4 : 0;
                }
            }
            return bricksLayout;
        }

        private int CountLevels()
        {
            string path = "Levels";
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path, "Level*.txt");
                return files.Length;
            }
            else
            {
                throw new DirectoryNotFoundException($"Directory not found at {path}");
            }
        }
    }
}
