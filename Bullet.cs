#region Using Statements

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookExample.Content;

#endregion

namespace BookExample
{
    public class Bullet
    {
        #region Encapsulated Fields

        private Matrix bulletBlockTransform;

        public Matrix BulletBlockTransform
        {
            get { return bulletBlockTransform; }
            set { bulletBlockTransform = value; }
        }

        private MouseState previousMouseState;

        public MouseState PreviousMouseState
        {
            get { return previousMouseState; }
            set { previousMouseState = value; }
        }
        private Texture2D bulletTexture;

        public Texture2D BulletTexture
        {
            get { return bulletTexture; }
            set { bulletTexture = value; }
        }
        private Vector2 bulletDirection;

        public Vector2 BulletDirection
        {
            get { return bulletDirection; }
            set { bulletDirection = value; }
        }
        private Vector2 bulletPos;

        public Vector2 BulletPos
        {
            get { return bulletPos; }
            set { bulletPos = value; }
        }
        private Vector2 bulletEnd;

        public Vector2 BulletEnd
        {
            get { return bulletEnd; }
            set { bulletEnd = value; }
        }
        private Vector2 bulletVelocity;

        public Vector2 BulletVelocity
        {
            get { return bulletVelocity; }
            set { bulletVelocity = value; }
        }
        private Vector2 bulletOrigin;

        public Vector2 BulletOrigin
        {
            get { return bulletOrigin; }
            set { bulletOrigin = value; }
        }
        private float bulletRotation;

        public float BulletRotation
        {
            get { return bulletRotation; }
            set { bulletRotation = value; }
        }
        private Rectangle sourceRect;

        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }
        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        #endregion

        #region Constructors

        public Bullet(Texture2D newTexture)
        {
            previousMouseState = Mouse.GetState();
            bulletTexture = newTexture;
            isVisible = false;
            bulletVelocity = new Vector2(3, 3);
        }

        #endregion

        #region Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(bulletTexture, bulletPos, sourceRect, Color.White, bulletRotation - 80, new Vector2(0,0), 1, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime, Camera camera)
        {
            bulletDirection = new Vector2((float)Math.Cos(bulletRotation), (float)Math.Sin(bulletRotation));
            bulletPos += bulletDirection * bulletVelocity *gameTime.ElapsedGameTime.Milliseconds;
            sourceRect = new Rectangle((int)bulletPos.X, (int)bulletPos.Y, bulletTexture.Width, bulletTexture.Height);
            if (Vector2.Distance(bulletPos, bulletEnd) > 1500)
            {
                isVisible = false;
            }

            previousMouseState = Mouse.GetState();
            bulletBlockTransform = Matrix.CreateTranslation(new Vector3(bulletPos, 0.0f));
        }

        #endregion

        #region Destructor

        ~Bullet()
        {

        }

        #endregion
    }
}
