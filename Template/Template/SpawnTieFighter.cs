using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class SpawnTieFighter
    {
        //Random generator
        Random random = new Random();

        private int windowWidth;
        private int spawnAmount = 10;
        private List<Vector2> position = new List<Vector2>();

        public SpawnTieFighter(int windowWidth)
        {
            this.windowWidth = windowWidth;
        }
        public void Update()
        {
            //Check if the game should spawn a tieFighter
            int tieFighterSpawn = random.Next(spawnAmount);
            if (tieFighterSpawn == 0)
            {
                //Get random X value
                int tieFighterXPos = random.Next(windowWidth);

                //Add tieFighters
                position.Add(new Vector2(tieFighterXPos, -50));
            }
        }
    }
}
