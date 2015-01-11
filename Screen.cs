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

namespace BookExample
{
    public abstract class Screen : Game1
    {
        #region Encapsulated Fields

        private Vector2 backPos;

        public Vector2 BackPos
        {
            get { return backPos; }
            set { backPos = value; }
        }

        private Texture2D background;

        public Texture2D Background
        {
            get { return background; }
            set { background = value; }
        }
        #endregion

        #region Constructor

        public Screen()
        {

        }

        #endregion

        #region Methods

        public virtual void Initialize(Vector2 position)
        {
            backPos = position;
        }

        public virtual void LoadContent(ContentManager Content)
        {
            //background = Content.Load<Texture2D>("Screens/TitleScreen/mainmenuback");
        }

        public virtual void Update(GameTime gameTime, Camera camera)
        {
            backPos = camera.centre;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            //spriteBatch.Draw(background, backPos, Color.White);
            //spriteBatch.End();
        }

        #endregion
    }
}
