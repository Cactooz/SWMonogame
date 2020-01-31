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
        //Random generator
        Random random = new Random();

        //Variables
        private Texture2D texture;
        private List<Vector2> position;
        private Rectangle rectangle = new Rectangle();
        private int windowWidth;
        private int spawnAmount = 10;

        public TieFighter(Texture2D texture, List<Vector2> position, int windowWidth)
        {
            this.texture = texture;
            this.windowWidth = windowWidth;
            this.position = position;
        }

        public void Update()
        {
            //Check if the game should spawn a tieFighter
            int tieFighterSpawn = random.Next(spawnAmount);
            int tieFighterXPos = random.Next(windowWidth);
            if (tieFighterSpawn == 0)
            {
                //Add tieFighters
                position.Add(new Vector2(tieFighterXPos, -50));
            }

            //Move the tieFighters downwards
            for (int i = 0; i < position.Count; i++)
            {
                position[i] = position[i] + new Vector2(0, 10);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Vector2 tieFighter in position)
            {
                //Draws the tieFighters, Color.White does not add any extra color on the object
                rectangle.Location = tieFighter.ToPoint();
                rectangle.Size = new Point(80, 80);
                spriteBatch.Draw(texture, rectangle, Color.White);
            }
        }
    }
}
