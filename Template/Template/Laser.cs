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

        public Vector2 Position { get => position; }

        public Laser(Texture2D texture, Vector2 position )
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
            //Move the laser uppwards
            position = new Vector2(position.X, position.Y - 15);
        }
    }
}
