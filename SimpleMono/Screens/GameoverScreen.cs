/*
* FILE : Brick.cs
* PROJECT : PROG3105 - SETBreakout Assignment
* PROGRAMMER : Darryl Poworoznyk and Francisco Granados
* FIRST VERSION : 2014-01-28
* DESCRIPTION :
* The functions in this file are used to set up the parent class Brick
*/
#region Using Statements

using System.Threading;
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
    class GameoverScreen : Screen
    {
        #region Fields

        private ContentManager Content;

        #endregion

        #region Constructor

        public GameoverScreen()
        {
            //1060 by 180
        }

        #endregion

        #region Methods

        /*
        *   FUNCTION :       Brick
        *   DESCRIPTION :    This function is the default constructor for the class
        *   PARAMETERS :     NONE
        *   RETURNS :        NONE
        */
        public override void Initialize(Vector2 position, Camera camera)
        {
            BackPos = camera.centre;
        }

        public override void LoadContent(ContentManager newContent)
        {
            Content = newContent;
            Background = Content.Load<Texture2D>("Screens/GameoverScreen/gameover");
        }

        public override void Update(GameTime gameTime, Camera camera)
        {
            Thread.Sleep(5000);
            Game1.CurrentScreen = 6;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Background, BackPos, Color.White);
            spriteBatch.End();
        }

        #endregion
    }
}
