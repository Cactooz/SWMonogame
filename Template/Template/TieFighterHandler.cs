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
        private int windowHeight = Game1.windowHeight;
        private int spawnAmount = 10;
        private Texture2D texture;
        private List<TieFighter> tieFighters = new List<TieFighter>();

        public List<TieFighter> TieFighters { get => tieFighters; set => tieFighters = value; }
        public int SpawnAmount { set => spawnAmount = value; }

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
            //Move the tiefighters downwards
            foreach (TieFighter tieFighter in tieFighters)
            {
                tieFighter.Update();
            }

            CheckIfOutside();
            RemoveObjects();
        }
        private void CheckIfOutside()
        {
            foreach (TieFighter tieFighter in tieFighters) {
                if (tieFighter.Position.Y >= windowHeight)
                    tieFighter.Alive = false;
            }
        }
        private void RemoveObjects()
        {
            //Remove tieFighters
            List<TieFighter> tieFightersTemp = new List<TieFighter>();
            foreach (TieFighter tieFighter in tieFighters) {
                if (tieFighter.Alive)
                    tieFightersTemp.Add(tieFighter);
            }
            tieFighters = tieFightersTemp;
        }
    }
}
