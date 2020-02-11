using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class TieFighter
    {

        //Variables
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox = new Rectangle();
        private int movementSpeed = 10;

        public TieFighter(Texture2D texture)
        {
            this.texture = texture;

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
            position = position + new Vector2(0, speed);
        }
    }
}
