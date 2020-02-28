using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class LaserHandler
    {
        private Texture2D texture;
        private List<Laser> lasers = new List<Laser>();

        public List<Laser> Lasers
        {
            get { return lasers; }
            set { lasers = value; }
        }
        public LaserHandler(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Spawn()
        {

        }
        public void Update()
        {
            CheckIfOutside();
        }
        private void CheckIfOutside()
        {

        }
    }
}
