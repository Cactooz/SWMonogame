using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Load the xwing texture and choose its start position
        Texture2D xwing;
        Vector2 xwingPos = new Vector2(100,300);

        //A list with all bullet positions
        Texture2D laser;
        List<Vector2> xwingBulletPos = new List<Vector2>();

        //Load the background
        Texture2D background;
        Vector2 backgroundPos = new Vector2(0,0);

        KeyboardState kNewState;
        KeyboardState kOldState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load the xwing texture into the game
            xwing = Content.Load<Texture2D>("xwing");
            //Load the laser texture into the game
            laser = Content.Load<Texture2D>("laser");

            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Stop the program if esc is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) //kNewState.IsKeyDown(Keys.Escape)
                Exit();

            //Look what is pressed on the keyboard
            kNewState = Keyboard.GetState();

            //Move the xwing right and left if the buttons are pressed
            if (kNewState.IsKeyDown(Keys.Right))
                xwingPos.X += 5;
            if (kNewState.IsKeyDown(Keys.Left))
                xwingPos.X -= 5;

            //Check if space is clicked to shoot bullet
            if(kNewState.IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space)) {
                xwingBulletPos.Add(xwingPos);
            }

            //Move the xwing bullets upwards
            for (int i = 0; i < xwingBulletPos.Count; i++) {
                xwingBulletPos[i] = xwingBulletPos[i] - new Vector2(0, 5);
                //Remove the bullets - unsecure
                if (xwingBulletPos[i].Y < 0){
                    xwingBulletPos.RemoveAt(i);
                    i--;
                }
            }

            //Save the keyboard state as the last frame, needs to be last!
            kOldState = kNewState;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Background color for the game
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            
            //How to draw background image
            //spriteBatch.Draw(background, backgroundPos, Color.White);

            //Draws the xwing, Color.White does not add any extra color on the object
            spriteBatch.Draw(xwing, xwingPos, Color.White);

            //Draws the xwing bullets
            foreach (Vector2 bulletPos in xwingBulletPos) {
                //Rectangle to resize the bullet size
                Rectangle rec = new Rectangle();
                rec.Location = bulletPos.ToPoint();
                rec.Size = new Point(5, 12);

                //Draw the bullets
                spriteBatch.Draw(laser, rec, Color.White);
            }

            spriteBatch.End();

            // TODO: Add your drawing code here.

            base.Draw(gameTime);
        }
    }
}