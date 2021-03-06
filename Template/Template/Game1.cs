﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Template
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Declare variables for window size
        public static int windowWidth;
        public static int windowHeight;
        /// <summary>
        /// This is the main type for your game.
        /// </summary>

        //Load the xwing texture and declare its position
        Texture2D xwingImg;

        //A list with all bullet positions
        Texture2D redLaser;
        List<Vector2> xwingBulletPos = new List<Vector2>();

        //Load the background
        Texture2D background;
        Vector2 backgroundPos = new Vector2(0, 0);

        //Load the tie fighters
        Texture2D tieFighterImg;
        List<Vector2> tieFighterPos = new List<Vector2>();

        //Load the explotion texture
        Texture2D explosion;
        //Vector2 xwingExplosionPos;
        //Vector2 bulletExplosionPos;

        Xwing xwing;
        TieFighterHandler tieFighterHandler;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Game size & fullscreen mode
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.IsFullScreen = false;

            //Give the window size variables their value
            windowHeight = graphics.PreferredBackBufferHeight;
            windowWidth = graphics.PreferredBackBufferWidth;
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

            //Load the xwing texture
            xwingImg = Content.Load<Texture2D>("xwing");

            //Load the red laser texture
            redLaser = Content.Load<Texture2D>("redLaser");

            //Create the xwing
            xwing = new Xwing(xwingImg, redLaser);

            //Load background image
            tieFighterImg = Content.Load<Texture2D>("tieFighter");

            //Create the tiefighters
            tieFighterHandler = new TieFighterHandler(tieFighterImg);            

            //Load background image
            background = Content.Load<Texture2D>("stars1080p");

            //Load explosion image
            explosion = Content.Load<Texture2D>("explosion");

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
            //Stop the program if esc is pressed or back (share on ps4) button on a controller
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            xwing.Update();
            tieFighterHandler.Spawn();
            tieFighterHandler.Update();

            //Check collisions between objects
            Collision();

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

            //Background image
            Rectangle backgroundRec = new Rectangle();
            backgroundRec.Location = backgroundPos.ToPoint();
            backgroundRec.Size = new Point(windowWidth, windowHeight);
            spriteBatch.Draw(background, backgroundRec, Color.White);

            /*//Explosion rectangle for xwing
            xwingExplosionPos = xwingPos - new Vector2(45, 25);
            Rectangle xwingExplosionRec = new Rectangle();
            xwingExplosionRec.Location = xwingExplosionPos.ToPoint();
            xwingExplosionRec.Size = new Point(200, 200);*/

            //Draws the xwing
            xwing.Draw(spriteBatch);

            //Draws the tiefighters
            foreach (TieFighter tieFighter in tieFighterHandler.TieFighters) {
                tieFighter.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void Collision()
        {
            foreach (TieFighter tieFighter in tieFighterHandler.TieFighters) {
                foreach (Laser laser in xwing.laserHandler.Lasers) {
                    //Remove laser and tiefight if they hit each other
                    if (laser.Hitbox.Intersects(tieFighter.Hitbox)) {
                        laser.Alive = false;
                        tieFighter.Alive = false;
                    }
                }

                //Remove tiefight if it hits xwing
                if (tieFighter.Hitbox.Intersects(xwing.Hitbox)) {
                    tieFighter.Alive = false;
                    xwing.Lives--;
                }
            }
        }
    }
}
