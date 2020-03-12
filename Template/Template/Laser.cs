using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class Laser
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox = new Rectangle();
        bool alive = true;

        public Vector2 Position { get => position; }
        public Rectangle Hitbox { get => hitbox; }
        public bool Alive { get => alive; set => alive = value; }

        public Laser(Texture2D texture, Vector2 position )
        {
            //Load in texture and position
            this.texture = texture;
            this.position = position;

            //Set the laser hitbox size
            hitbox.Size = new Point(5, 12);
        }

        public void Update() {
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw the bullet
            spriteBatch.Draw(texture, hitbox, Color.White);
        }
        private void Move()
        {
            //Move the laser uppwards
            position = new Vector2(position.X, position.Y - 15);

            //Set the hitbox to the location of the texture
            hitbox.Location = position.ToPoint();
        }
    }
}
