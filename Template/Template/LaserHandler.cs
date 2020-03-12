using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Template
{
    class LaserHandler
    {
        private Texture2D texture;
        private List<Laser> lasers = new List<Laser>();
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
            //Width and height of xwing hitbox
            float width = xwing.Hitbox.Width;
            float height = xwing.Hitbox.Height;
            //Spawn in the lasers
            lasers.Add(new Laser(texture, xwing.Position + new Vector2(width * 0.065f, height * 0.245f)));
            lasers.Add(new Laser(texture, xwing.Position + new Vector2(width - (width * 0.09f), height * 0.245f)));
        }
        public void Update()
        {
            //Update the lasers position
            foreach (Laser laser in lasers)
            {
                laser.Update();
            }
            //Check if the laser is outside of the window
            CheckIfOutside();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Laser laser in lasers)
            {
                laser.Draw(spriteBatch);
            }
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
