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

        /*public TieFighter(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }*/
        
        //New test
        public Texture2s Texture {
            get{ return texture; }
            set{ texture = value; }
        }
        
        public Vector2 Position {
            get{ return texture; }
            set{ texture = value; }
        }
        
        public void Update()
        {
            Move(movementSpeed);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draws the tieFighter, Color.White does not add any extra color on the object
            hitbox.Location = position.ToPoint();
            hitbox.Size = new Point(80, 80);
            spriteBatch.Draw(texture, hitbox, Color.White);
        }
        private void Move(int speed)
        {
            //Move the tieFighters downwards
            position = position + new Vector2(0, speed);
        }
    }
}
