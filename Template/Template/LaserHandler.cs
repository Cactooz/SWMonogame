using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Template
{
    class LaserHandler
    {
        private Texture2D texture;
        private List<Laser> lasers = new List<Laser>();
        private int windowHeight = Game1.windowHeight;
        Xwing xwing;

        public List<Laser> Lasers
        {
            get => lasers;
            set => lasers = value;
        }

        public LaserHandler(Texture2D texture, Xwing xwing)
        {
            this.texture = texture;
            this.xwing = xwing;
        }
        public void Spawn()
        {
            //Spawn in the lasers
            {
                lasers.Add(new Laser(texture, xwing.Position + new Vector2(7, 27)));
                lasers.Add(new Laser(texture, xwing.Position + new Vector2(100, 27)));
            }
        }
        public void Update()
        {
            foreach (Laser laser in lasers)
            {
                laser.Update();
            }
            CheckIfOutside();
        }
        private void CheckIfOutside()
        {
            //Remove bullets
            List<Laser> lasersTemp = new List<Laser>();
            foreach (Laser laser in lasers)
            {
                if (laser.Position.Y >= -10)
                    lasersTemp.Add(laser);
            }
            lasers = lasersTemp;
        }
    }
}
