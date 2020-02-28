using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class TieFighterHandler
    {
        //Random generator
        Random random = new Random();

        private int windowWidth;
        private int spawnAmount = 1;
        private Texture2D texture;
        private List<TieFighter> tieFighters = new List<TieFighter>();

        public List<TieFighter> TieFighters
        {
            get { return tieFighters; }
            set { tieFighters = value; }
        }

        public TieFighterHandler(Texture2D texture, int windowWidth)
        {
            this.windowWidth = windowWidth;
            this.texture = texture;

            Random random = new Random();

        }
        public void UpdateSpawn()
        {
            //Check if the game should spawn a tieFighter
            int spawnrate = random.Next(spawnAmount);
            if (spawnrate == 0)
            {
                //Get random X value
                int XPos = random.Next(windowWidth);

                //Add tieFighters
                tieFighters.Add(new TieFighter(texture, XPos));
            }
        }
    }
}
