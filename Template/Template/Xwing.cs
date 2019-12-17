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
        private int windowWidth;

        public Xwing(Texture2D texture, Vector2 position, int windowWidth)
        {
            this.texture = texture;
            this.position = position;
            this.windowWidth = windowWidth;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draws the xwing, Color.White does not add any extra color on the object
            rectangle.Location = position.ToPoint();
            rectangle.Size = new Point(110, 110);
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
        public void MoveLeft()
        {
            if (position.X > 0)
                position.X -= 8;
        }

        public void MoveRight()
        {
            if (position.X < windowWidth - texture.Width)
                position.X += 8;
        }
    }
}