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
        //Keyboard, mouse and controller states
        private KeyboardState kNewState;
        private KeyboardState kOldState;
        private MouseState mNewState;
        private MouseState mOldState;
        private Vector2 xwingPos;
        Xwing xwing;

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
            kNewState = Keyboard.GetState();
            mNewState = Mouse.GetState();
            xwingPos = xwing.Position;
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

        }
    }
}
