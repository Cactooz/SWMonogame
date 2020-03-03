using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Laser
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox = new Rectangle();
        private int movementSpeed = 10;
        public Laser(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public void Update()
        {
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Rectangle to resize the bullet size
            hitbox.Location = position.ToPoint();
            hitbox.Size = new Point(5, 12);

            //Draw the bullet
            spriteBatch.Draw(texture, hitbox, Color.White);
        }
        private void Move()
        {
           /* //Check if space or left mouse button is clicked to shoot bullet 
            if (kNewState.IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space) || mNewState.LeftButton == ButtonState.Pressed && mOldState.LeftButton == ButtonState.Released)
            {
                //Add bullets
                position.Add(xwingPos + new Vector2(7, 27));
                position.Add(xwingPos + new Vector2(xwingImg.Width - 11, 27));
            } */
        }
    }
}
