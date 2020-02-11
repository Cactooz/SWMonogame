using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class SpawnTieFighter
    {
        //Random generator
        Random random = new Random();

        private int windowWidth;
        private int spawnAmount = 10;
        private Texture2D texture;
        private List<TieFighter> tieFighters = new List<TieFighter>();

        public List<TieFighter> TieFighters { get { return TieFighters; } }

        public SpawnTieFighter(Texture2D texture, int windowWidth)
        {
            this.windowWidth = windowWidth;
            this.texture = texture;

            Random random = new Random();

            int tieFighterXPos = random.Next(windowWidth);

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
                tieFighters.Add(new TieFighter(texture));
            }
        }
    }
}
