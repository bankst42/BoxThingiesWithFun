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

namespace BoxThingiesWithFun
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D square;
        Rectangle[] CrazyTile = new Rectangle[100];
        int CurrentScreen = 1;
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
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
               CrazyTile[i] = new Rectangle(random.Next(0, 800), random.Next(0, 600), random.Next(10,100), random.Next(10,100)); 
            }
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
            square = Content.Load<Texture2D>("Square");

            // TODO: use this.Content to load your game content here
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
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.D1))
                CurrentScreen = 1;
            else if (kb.IsKeyDown(Keys.D2))
                CurrentScreen = 2;
            else if (kb.IsKeyDown(Keys.D3))
                CurrentScreen = 3;
            else if (kb.IsKeyDown(Keys.D4))
                CurrentScreen = 4;
            else if (kb.IsKeyDown(Keys.D5))
                CurrentScreen = 5;
            




            base.Initialize();
            this.IsMouseVisible = true;
 
            base.Update(gameTime);
        }


        public void DrawRainbow()
        {

            int x = 0;
            int y = 0;
            for (int i = 0; i < 7; i++)
            {
                Rectangle Rainbow = new Rectangle(x, y, 115, 800);
                spriteBatch.Begin();

                if (i == 0)
                    spriteBatch.Draw(square, Rainbow, Color.Red);
               else if (i == 1)
                    spriteBatch.Draw(square, Rainbow, Color.Orange);
               else if (i == 2)
                    spriteBatch.Draw(square, Rainbow, Color.Yellow);
               else if (i == 3)
                    spriteBatch.Draw(square, Rainbow, Color.Green);
               else if (i == 4)
                    spriteBatch.Draw(square, Rainbow, Color.Blue);
               else if (i == 5)
                    spriteBatch.Draw(square, Rainbow, Color.Indigo);
               else if (i == 6)
                    spriteBatch.Draw(square, Rainbow, Color.Violet);

                x += 115;
                

                spriteBatch.End();
            }
        }
        

        public void DrawBlankScreen()
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < 2000; i++)
            {
                Rectangle BlankRect = new Rectangle(x, y, 14, 14);
                spriteBatch.Begin();

                spriteBatch.Draw(square, BlankRect, Color.BurlyWood);

                x += 15;
                if (i % 53 == 52)
                {
                    y += 15;
                    x = 0;
                }

                spriteBatch.End();

            }
        }

        public void DrawCheckerBoard()
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < 2000; i++)
            {
                Rectangle CheckerBoard = new Rectangle(x, y, 15, 15);
                spriteBatch.Begin();
                
                if (i % 2 == 0)
                    spriteBatch.Draw(square, CheckerBoard, Color.White);
                else
                    spriteBatch.Draw(square, CheckerBoard, Color.Black);
                
                x += 15;
                if (i % 53 == 52)
                {
                    y += 15;
                    x = 0;
                }

                spriteBatch.End();
                
            }
        }


        
        public void DrawCrazySquares()
        { 
            spriteBatch.Begin();
            for (int i = 0; i < CrazyTile.Length; i++)
            {
                spriteBatch.Draw(square, CrazyTile[i], Color.Black);
            }
            spriteBatch.End();
        }

        public void DrawStatic()
        {
            Rectangle StaticTile;
            Random random = new Random();
           
            spriteBatch.Begin();
            for (int i = 0; i < 50000; i++)
            {
                StaticTile = new Rectangle(random.Next(0, 800), random.Next(0, 600), 3, 3);
                spriteBatch.Draw(square, StaticTile, Color.Black);
            }
            spriteBatch.End();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            if (CurrentScreen == 1)
            DrawBlankScreen();
            else if (CurrentScreen == 2)
            DrawCheckerBoard();
            else if (CurrentScreen == 3)
            DrawRainbow();
            else if (CurrentScreen == 4)
            DrawCrazySquares();
            else if (CurrentScreen == 5)
            DrawStatic();

            base.Draw(gameTime);
        }
    }
}


//if (i % 2 == 0)
                 //{
                //spriteBatch.Draw(square, CrazyTile[i], Color.Black);
                 // }
               // else
               // spriteBatch.Draw(square, CrazyTile[i], Color.Red);