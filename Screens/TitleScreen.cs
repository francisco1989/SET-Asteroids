#region Using Statements

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using BookExample.Content;

#endregion

namespace BookExample.Screens
{
    class TitleScreen : Screen
    {
        #region Fields

        private ContentManager Content;
        private MouseState previousMouseState;
        private Rectangle mouseRect;
        private Vector2 cursorPos;
        private Texture2D newButton;
        private Vector2 newButtonPos;
        private Rectangle newButtonRect;
        private Texture2D aboutButton;
        private Vector2 aboutButtonPos;
        private Rectangle aboutButtonRect;
        private Texture2D exitButton;
        private Vector2 exitButtonPos;
        private Rectangle exitButtonRect;
        private Texture2D controlButton;
        private Vector2 controlButtonPos;
        private Rectangle controlButtonRect;

        #endregion

        #region Constructor

        public TitleScreen()
        {

        }

        #endregion

        #region Methods

        public override void Initialize(Vector2 position, Camera camera)
        {
            BackPos = position;
            previousMouseState = Mouse.GetState();
        }

        public override void LoadContent(ContentManager newContent)
        {
            Content = newContent;
            Background = Content.Load<Texture2D>("Screens/TitleScreen/mainmenuback");
            newButton = Content.Load<Texture2D>("Screens/TitleScreen/newgamebutton");
            aboutButton = Content.Load<Texture2D>("Screens/TitleScreen/aboutbutton");
            exitButton = Content.Load<Texture2D>("Screens/TitleScreen/exitbutton");
            controlButton = Content.Load<Texture2D>("Screens/TitleScreen/controlbutton");
        }

        public override void Update(GameTime gameTime, Camera camera)
        {
            BackPos = camera.centre;
            newButtonPos = new Vector2(camera.centre.X + 550, camera.centre.Y + 380);
            newButtonRect = new Rectangle((int)newButtonPos.X, (int)newButtonPos.Y, newButton.Width, newButton.Height);
            aboutButtonPos = new Vector2(camera.centre.X + 550, camera.centre.Y + 440);
            aboutButtonRect = new Rectangle((int)aboutButtonPos.X, (int)aboutButtonPos.Y, aboutButton.Width, aboutButton.Height);
            controlButtonPos = new Vector2(camera.centre.X + 550, camera.centre.Y + 500);
            controlButtonRect = new Rectangle((int)controlButtonPos.X, (int)controlButtonPos.Y, controlButton.Width, controlButton.Height);
            exitButtonPos = new Vector2(camera.centre.X + 550, camera.centre.Y + 560);
            exitButtonRect = new Rectangle((int)exitButtonPos.X, (int)exitButtonPos.Y, exitButton.Width, exitButton.Height);

            MouseState curMouse = Mouse.GetState();
            cursorPos = new Vector2(curMouse.X + camera.centre.X, curMouse.Y + camera.centre.Y);
            mouseRect = new Rectangle((int)cursorPos.X, (int)cursorPos.Y, 1, 1);

            // check newButton
            if (newButtonRect.Intersects(mouseRect))
            {
                newButton = Content.Load<Texture2D>("Screens/TitleScreen/newgamebuttonselect");
                if (previousMouseState.LeftButton == ButtonState.Released
                && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Game1.CurrentScreen = 2;
                }
            }
            else
            {
                newButton = Content.Load<Texture2D>("Screens/TitleScreen/newgamebutton");
            }
            //check about button
            if (aboutButtonRect.Intersects(mouseRect))
            {
                aboutButton = Content.Load<Texture2D>("Screens/TitleScreen/aboutbuttonselect");
                if (previousMouseState.LeftButton == ButtonState.Released
                && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Game1.CurrentScreen = 3;
                }
            }
            else
            {
                aboutButton = Content.Load<Texture2D>("Screens/TitleScreen/aboutbutton");
            }
            //check controls button
            if (controlButtonRect.Intersects(mouseRect))
            {
                controlButton = Content.Load<Texture2D>("Screens/TitleScreen/controlsselect");
                if (previousMouseState.LeftButton == ButtonState.Released
                && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Game1.CurrentScreen = 7;
                }
            }
            else
            {
                controlButton = Content.Load<Texture2D>("Screens/TitleScreen/controlbutton");
            }
            //check exit button
            if (exitButtonRect.Intersects(mouseRect))
            {
                exitButton = Content.Load<Texture2D>("Screens/TitleScreen/exitbuttonselect");
                if (previousMouseState.LeftButton == ButtonState.Released
                && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Game1.CurrentScreen = 4;
                }
            }
            else
            {
                exitButton = Content.Load<Texture2D>("Screens/TitleScreen/exitbutton");
            }
            

            previousMouseState = Mouse.GetState();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Background, BackPos, Color.White);
            spriteBatch.Draw(newButton, newButtonPos, Color.White);
            spriteBatch.Draw(aboutButton, aboutButtonPos, Color.White);
            spriteBatch.Draw(controlButton, controlButtonPos, Color.White);
            spriteBatch.Draw(exitButton, exitButtonPos, Color.White);
            spriteBatch.End();
        }

        #endregion
    }
}
