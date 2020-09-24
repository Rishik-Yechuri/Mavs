using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Mavs
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Stuff for Background
        Rectangle backgroundRectangle;
        Texture2D backgroundTexture;

        //Stuff for Basketball
        Rectangle ballRectangle;
        Texture2D ballTexture;
        double ballxPos;
        double ballyPos;
        double xVel;
        double yVel;
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
            //Initialize Background
            backgroundRectangle = new Rectangle(0,0,780, 312);

            //Initialize Ball
            ballxPos = 150;
            ballyPos = 200;
            xVel = 48;
            yVel = -60;
            ballRectangle = new Rectangle((int)ballxPos, (int)ballyPos, 96, 90);
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

            // TODO: use this.Content to load your game content here
            backgroundTexture = this.Content.Load<Texture2D>("basketballcourt");
            ballTexture = this.Content.Load<Texture2D>("basketball");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (ballxPos >= 600) {
                xVel = 0;
            }
            if (ballyPos >= 201) {
                yVel = 0;
            }
            yVel += 9.8 / 60;
            ballxPos += xVel/60;
            ballyPos += yVel/60;
            ballRectangle = new Rectangle((int)ballxPos,(int)ballyPos,96,90);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White);
            spriteBatch.Draw(ballTexture, ballRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
