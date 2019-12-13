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
        private Rectangle rectangle = new Rectangle();

        //Keyboard, mouse and controller states
        KeyboardState kNewState;
        KeyboardState kOldState;
        MouseState mNewState;
        MouseState mOldState;
        GamePadState gPState;

        void LoadContent()
        {

        }
        void Update()
        {
            //Look what is pressed on the keyboard, mouse and controller
            kNewState = Keyboard.GetState();
            mNewState = Mouse.GetState();
            gPState = GamePad.GetState(PlayerIndex.One);

            //Move the xwing right and left if the buttons are pressed
            if (kNewState.IsKeyDown(Keys.Right) || kNewState.IsKeyDown(Keys.D))
                //Make sure to not move outside the window
                if (position.X < windowWidth - texture.Width)
                    position.X += 8;
            if (kNewState.IsKeyDown(Keys.Left) || kNewState.IsKeyDown(Keys.A))
                //Make sure to not move outside the window
                if (position.X > 0)
                    position.X -= 8;

            //Save the keyboard & mouse state as the last frame, needs to be last!
            kOldState = kNewState;
            mOldState = mNewState;
        }
        void Draw(SpriteBatch spriteBatch)
        {
            //Draws the xwing, Color.White does not add any extra color on the object
            rectangle.Location = position.ToPoint();
            rectangle.Size = new Point(110, 110);
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}