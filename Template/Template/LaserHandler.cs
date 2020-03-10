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
        //Keyboard, mouse and controller states
        private KeyboardState kNewState;
        private KeyboardState kOldState;
        private MouseState mNewState;
        private MouseState mOldState;
        private Vector2 xwingPos;
        Xwing xwing;

        public List<Laser> Lasers
        {
            get => lasers;
            set => lasers = value;
        }

        public LaserHandler(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Spawn()
        {
            kNewState = Keyboard.GetState();
            mNewState = Mouse.GetState();
            xwingPos = xwing.Position;

            //Spawn in the lasers
            if (kNewState.IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space) || mNewState.LeftButton == ButtonState.Pressed && mOldState.LeftButton == ButtonState.Released)
            {
                lasers.Add(new Laser(texture, (xwingPos + new Vector2(7, 27))));
                lasers.Add(new Laser(texture, (xwingPos + new Vector2(texture.Width - 11, 27))));
            }

            //Save the keyboard & mouse state as the last frame, needs to be last!
            kOldState = kNewState;
            mOldState = mNewState;
        }
        public void Update()
        {
            CheckIfOutside();
        }
        private void CheckIfOutside()
        {
            //Remove bullets
            List<Laser> lasersTemp = new List<Laser>();
            foreach (Laser laser in lasers)
            {
                if (laser.Position.Y >= windowHeight)
                    lasersTemp.Add(laser);
            }
            lasers = lasersTemp;
        }
    }
}
