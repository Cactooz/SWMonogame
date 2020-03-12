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
        private int lives = 5;

        //Keyboard, mouse and controller states
        private KeyboardState kNewState;
        private KeyboardState kOldState;
        private MouseState mNewState;
        private MouseState mOldState;

        public LaserHandler laserHandler;

        public Vector2 Position { get => position; }
        public Rectangle Hitbox { get => hitbox; }
        public int Lives { get => lives; set => lives = value; }
        
        public Xwing(Texture2D texture, Texture2D laserTexture)
        {
            this.texture = texture;

            //Create the laserhandler object
            laserHandler = new LaserHandler(laserTexture, this);

            //Size of the xwing
            hitbox.Size = new Point(110, 110);

            //Set xwing start position
            position = new Vector2((Game1.windowWidth / 2) - (hitbox.Width / 2), Game1.windowHeight - hitbox.Height - 50);
        }
        public void Update()
        {
            Death();

            kNewState = Keyboard.GetState();
            mNewState = Mouse.GetState();

            Move();
            Shoot();
            laserHandler.Update();

            //Save the keyboard & mouse state as the last frame
            kOldState = kNewState;
            mOldState = mNewState;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, Color.White);

            laserHandler.Draw(spriteBatch);
        }
        private void Move()
        {
            //Move the xwing right and left if the buttons are pressed
            if (kNewState.IsKeyDown(Keys.Right) || kNewState.IsKeyDown(Keys.D))
            {
                //Make sure to not move outside the window
                if (position.X < Game1.windowWidth - texture.Width)
                    position.X += 8;
            }
            if (kNewState.IsKeyDown(Keys.Left) || kNewState.IsKeyDown(Keys.A))
            {
                //Make sure to not move outside the window
                if (position.X > 0)
                    position.X -= 8;
            }

            hitbox.Location = position.ToPoint();
        }
        private void Shoot()
        {
            if (kNewState.IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space) || mNewState.LeftButton == ButtonState.Pressed && mOldState.LeftButton == ButtonState.Released)
                laserHandler.Spawn();
        }
        private void Death()
        {
            if (lives <= 0) {
                hitbox.Size = new Point(0, 0);
            }
        }
    }
}