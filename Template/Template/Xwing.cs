using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Xwing
    {
        //Load the xwing texture and declare its position
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox = new Rectangle();
        private int windowWidth = Game1.windowWidth;
        //Keyboard, mouse and controller states
        private KeyboardState kNewState;
        private KeyboardState kOldState;
        private MouseState mNewState;
        private MouseState mOldState;
        public LaserHandler laserHandler;
        public Vector2 Position { get => position; }
        public Xwing(Texture2D texture, Texture2D laserTexture)
        {
            this.texture = texture;
            laserHandler = new LaserHandler(laserTexture, this);
            //Set xwing start position
            position = new Vector2(windowWidth / 2, Game1.windowHeight - 150);
        }
        public void Update()
        {
            Move();
            Shoot();
            laserHandler.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draws the xwing, Color.White does not add any extra color on the object
            hitbox.Location = position.ToPoint();
            hitbox.Size = new Point(110, 110);
            spriteBatch.Draw(texture, hitbox, Color.White);
        }
        private void Move()
        {
            //Move the xwing right and left if the buttons are pressed
            if (kNewState.IsKeyDown(Keys.Right) || kNewState.IsKeyDown(Keys.D))
                //Make sure to not move outside the window
                if (position.X < windowWidth - texture.Width)
                    position.X += 8;
            if (kNewState.IsKeyDown(Keys.Left) || kNewState.IsKeyDown(Keys.A))
                //Make sure to not move outside the window
                if (position.X > 0)
                    position.X -= 8;
        }
        private void Shoot()
        {
            kNewState = Keyboard.GetState();
            mNewState = Mouse.GetState();
            if (kNewState.IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space) || mNewState.LeftButton == ButtonState.Pressed && mOldState.LeftButton == ButtonState.Released)
                laserHandler.Spawn();
            //Save the keyboard & mouse state as the last frame, needs to be last!
            kOldState = kNewState;
            mOldState = mNewState;
        }
    }
}