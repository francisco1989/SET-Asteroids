
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
    public class Earth
    {
        #region Encapsulated Fields

        private Matrix forceBlockTransform;

        public Matrix ForceBlockTransform
        {
            get { return forceBlockTransform; }
            set { forceBlockTransform = value; }
        }

        private Matrix earthBlockTransform;

        public Matrix EarthBlockTransform
        {
            get { return earthBlockTransform; }
            set { earthBlockTransform = value; }
        }

        private bool isDestroyed;

        public bool IsDestroyed
        {
            get { return isDestroyed; }
            set { isDestroyed = value; }
        }
        private int forceWidth;

        public int ForceWidth
        {
            get { return forceWidth; }
            set { forceWidth = value; }
        }
        private int forceHeight;

        public int ForceHeight
        {
            get { return forceHeight; }
            set { forceHeight = value; }
        }

        private Rectangle forceRect;

        public Rectangle ForceRect
        {
            get { return forceRect; }
            set { forceRect = value; }
        }

        private Texture2D forceField;

        public Texture2D ForceField
        {
            get { return forceField; }
            set { forceField = value; }
        }

        private Texture2D earthImage;

        public Texture2D EarthImage
        {
            get { return earthImage; }
            set { earthImage = value; }
        }
        private Vector2 earthPos;

        public Vector2 EarthPos
        {
            get { return earthPos; }
            set { earthPos = value; }
        }
        private Animation earthAnimation = new Animation();

        public Animation EarthAnimation
        {
            get { return earthAnimation; }
            set { earthAnimation = value; }
        }
        private Rectangle earthRect;

        public Rectangle EarthRect
        {
            get { return earthRect; }
            set { earthRect = value; }
        }
        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        private int animMod;

        public int AnimMod
        {
            get { return animMod; }
            set { animMod = value; }
        }

        private int hitPoints;

        public int HitPoints
        {
            get { return hitPoints; }
            set { hitPoints = value; }
        }
        private int forceFieldPoints;

        public int ForceFieldPoints
        {
            get { return forceFieldPoints; }
            set { forceFieldPoints = value; }
        }

        #endregion

        #region Constructors

        public Earth()
        {

        }

        #endregion

        #region Methods

        public void Initialize(Vector2 position)
        {
            earthPos = position;
            forceFieldPoints = 10;
            hitPoints = 20;
        }

        public void LoadContent(ContentManager Content)
        {
            forceField = Content.Load<Texture2D>("forcefield");
            forceWidth = forceField.Width;
            forceHeight = forceField.Height;

            Vector2 tmpVector = new Vector2(38, 1);
            earthAnimation.Initialize(earthPos, tmpVector);
            earthImage = Content.Load<Texture2D>("earthSpriteSheet");
            width = earthImage.Width / (int)tmpVector.X;
            height = earthImage.Height / (int)tmpVector.Y;
            earthAnimation.LoadContent(Content, earthImage);
        }

        public void Update(GameTime gameTime)
        {
            animMod = 2;
            earthAnimation.Active = true;
            earthRect = new Rectangle((int)earthPos.X, (int)earthPos.Y, 0, 0);
            earthAnimation.Update(gameTime, animMod, true, earthRect);
            earthRect = earthAnimation.AnimationRect;
            forceRect = new Rectangle((int)earthPos.X - 10, (int)earthPos.Y - 10, forceWidth, forceHeight);
            earthBlockTransform = Matrix.CreateTranslation(new Vector3(earthPos, 0.0f));
            forceBlockTransform = Matrix.CreateTranslation(new Vector3(new Vector2(forceRect.X,forceRect.Y),0.0f));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            earthAnimation.Draw(spriteBatch, 0, earthPos, 0);
            if (forceFieldPoints > 0)
            {
                spriteBatch.Draw(forceField, forceRect, Color.White * 0.25f);
            }
        }

        #endregion

        #region Destructor

        ~Earth()
        {

        }

        #endregion
    }
}
