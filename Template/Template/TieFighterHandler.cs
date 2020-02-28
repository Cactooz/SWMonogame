using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class TieFighterHandler
    {
        //Random generator
        Random random = new Random();

        private int windowWidth = Game1.windowWidth;
        private int spawnAmount = 10;
        private Texture2D texture;
        private List<TieFighter> tieFighters = new List<TieFighter>();

        public List<TieFighter> TieFighters
        {
            get { return tieFighters; }
            set { tieFighters = value; }
        }

        public TieFighterHandler(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Spawn()
        {
            //Check if the game should spawn a tieFighter
            int spawnrate = random.Next(spawnAmount);
            if (spawnrate == 0)
            {
                //Get random X position
                int XPos = random.Next(windowWidth);

                //Add tieFighters
                tieFighters.Add(new TieFighter(texture, XPos));
            }
        }
        public void Update()
        {
            CheckIfOutside();
        }
        private void CheckIfOutside()
        {
            /*//Remove tieFighters
            List<TieFighter> tieFighterTemp = new List<TieFighter>();
            foreach (var tieFighter in tieFighters)
            {
                if (tieFighter.Y <= windowHeight)
                    tieFighterTemp.Add(tieFighter);
            }*/
        }
    }
}
