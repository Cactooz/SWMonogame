using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class TieFighter
    {

        //Variables
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox = new Rectangle();
        private int movementSpeed = 10;

        public Vector2 Position { get => position; }

        public TieFighter(Texture2D texture, int xPos)
        {
            this.texture = texture;

            position.Y = -50;
            position.X = xPos;

            hitbox.Location = position.ToPoint();
            hitbox.Size = new Point(80, 80);
        }
        
        public void Update()
        {
            Move(movementSpeed);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draws the tieFighter, Color.White does not add any extra color on the object
            spriteBatch.Draw(texture, hitbox, Color.White);
        }
        private void Move(int speed)
        {
            //Move the tieFighters downwards
            position = new Vector2(position.X, position.Y + speed);
            hitbox.Location = position.ToPoint();
        }
    }
}
