﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace FloorIsLava
{
    class InstructionScreen
    {
        #region Attributes
        //Attributes
        private SpriteFont font1;
        private Game1 game;
        private KeyboardState lastState;
        private GameState gameState;
        #endregion Attributes

        #region Constructor 
        //Constructor
        public InstructionScreen(Game1 game1)
        {
            game = game1; //assigns the game1 object to game attribute
            gameState = new GameState(game); // creates the gameState object and puts it into gamestate attribute
            font1 = game.Content.Load<SpriteFont>("Font1"); //loads the Font1 sprite font
        }
        #endregion Constructor

        #region Methods
        //Update Method
        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (gameState.PauseScreen == null)
            {
                
                if (keyState.IsKeyDown(Keys.S) && lastState.IsKeyDown(Keys.S))
                {
                    gameState.CurrentScreen = Screen.StartScreen;
                }
                if (keyState.IsKeyDown(Keys.Back) && keyState.IsKeyDown(Keys.Back))
                {
                    gameState.CurrentScreen = Screen.StartScreen;
                }
                lastState = keyState;

                keyState = Keyboard.GetState(); //create a keyboard state variable to hold current keyboard state
                if (keyState.IsKeyDown(Keys.S) && lastState.IsKeyDown(Keys.S))
                {
                    gameState.CurrentScreen = Screen.StartScreen;
                }
                if (keyState.IsKeyDown(Keys.G) && lastState.IsKeyDown(Keys.G))
                {
                    gameState.StartGame("test.txt");
                }
                if (keyState.IsKeyDown(Keys.O) && lastState.IsKeyDown(Keys.O))
                {
                    gameState.SwitchOption(game);
                }
                if (keyState.IsKeyDown(Keys.L) && lastState.IsKeyDown(Keys.L))
                {
                    gameState.SwitchLevel(game);
                }
                if (keyState.IsKeyDown(Keys.C) && lastState.IsKeyDown(Keys.C))
                {
                    gameState.SwitchCredit(game);
                }
                
            }
            else
            {
                if(keyState.IsKeyDown(Keys.Back)&&lastState.IsKeyDown(Keys.Back))
                {
                    gameState.SwitchPause();
                }
            }
            lastState = keyState; // assigns current keyboard state to lastState
        }

        //Draw Method
        public void Draw(SpriteBatch spriteBatch, Texture2D background)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, game.screenWidth, game.screenHeight), Color.White);
            spriteBatch.DrawString(font1, "this is instruction Screen", new Vector2(50f, 50f), Color.Black);
            spriteBatch.DrawString(font1, "Press \"Back\" to go back", new Vector2(50f, 70f), Color.Black);

            spriteBatch.DrawString(font1, "D or Right Arrow Key to go forward", new Vector2(game.screenWidth / 2 - 100, 200f), Color.Gold);
            spriteBatch.DrawString(font1, "A or Left Arrow Key to go backwards", new Vector2(game.screenWidth / 2 - 100, 300f), Color.Gold);
            spriteBatch.DrawString(font1, "Space to jump", new Vector2(game.screenWidth / 2 - 100, 400f), Color.Gold);
            spriteBatch.DrawString(font1, "Press E, LeftShift or RightShift to shoot Grappling Hook", new Vector2(game.screenWidth / 2 - 100, 500f), Color.Gold);
            spriteBatch.DrawString(font1, "W or Up Arrow Key to go up grappling hook", new Vector2(game.screenWidth / 2 - 100, 600f), Color.Gold);
            spriteBatch.DrawString(font1, "S or Down Arrow Key to go up grappling hook", new Vector2(game.screenWidth / 2 - 100, 700f), Color.Gold);
            spriteBatch.DrawString(font1, "P to Pause", new Vector2(game.screenWidth / 2 - 100, 800f), Color.Gold);
        }
        #endregion Methods
    }
}
