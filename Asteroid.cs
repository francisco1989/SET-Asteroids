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
    class Asteroid
    {
        #region Encapsulated Fields

        private Matrix asteroidBlockTransform;

        public Matrix AsteroidBlockTransform
        {
            get { return asteroidBlockTransform; }
            set { asteroidBlockTransform = value; }
        }
        private Texture2D asteroidImage;

        public Texture2D AsteroidImage
        {
            get { return asteroidImage; }
            set { asteroidImage = value; }
        }
        private Vector2 asteroidPos;

        public Vector2 AsteroidPos
        {
            get { return asteroidPos; }
            set { asteroidPos = value; }
        }
        private Vector2 asteroidVelocity;

        public Vector2 AsteroidVelocity
        {
            get { return asteroidVelocity; }
            set { asteroidVelocity = value; }
        }
        private float asteroidRotation;

        public float AsteroidRotation1
        {
            get { return asteroidRotation; }
            set { asteroidRotation = value; }
        }
        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        private int index;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        private Animation asteroidAnimation = new Animation();

        public Animation AsteroidAnimation
        {
            get { return asteroidAnimation; }
            set { asteroidAnimation = value; }
        }
        private int animMod;

        public int AnimMod
        {
            get { return animMod; }
            set { animMod = value; }
        }
        private float asteroidScale;

        public float AsteroidScale
        {
            get { return asteroidScale; }
            set { asteroidScale = value; }
        }
        private Rectangle asteroidRect;

        public Rectangle AsteroidRect
        {
            get { return asteroidRect; }
            set { asteroidRect = value; }
        }
        private int asteroidHitPoints;

        public int AsteroidHitPoints
        {
            get { return asteroidHitPoints; }
            set { asteroidHitPoints = value; }
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

        private bool isExploded;

        public bool IsExploded
        {
            get { return isExploded; }
            set { isExploded = value; }
        }
        #endregion

        #region Constructors

        public Asteroid()
        {

        }

        #endregion

        #region Methods

        public void Initialize(Vector2 position, int points)
        {
            isExploded = false;
            asteroidHitPoints = points;
            asteroidPos = position;
            asteroidVelocity = Vector2.Zero;
            asteroidRotation = 0.0f;
            isActive = true;
            index = 0;
            asteroidScale = 1;
        }

        public void LoadContent(ContentManager Content)
        {
            
            if (asteroidHitPoints == 3)
            {
                Vector2 tmpVector = new Vector2(20, 1);
                asteroidAnimation.Initialize(asteroidPos, tmpVector);
                asteroidImage = Content.Load<Texture2D>("asteroid2Sheet");
                width = asteroidImage.Width / (int)tmpVector.X;
                height = asteroidImage.Height / (int)tmpVector.Y;
            }
            else if (asteroidHitPoints == 2)
            {
                Vector2 tmpVector = new Vector2(25, 1);
                asteroidAnimation.Initialize(asteroidPos, tmpVector);
                asteroidImage = Content.Load<Texture2D>("asteroid3Sheet");
                width = asteroidImage.Width / (int)tmpVector.X;
                height = asteroidImage.Height / (int)tmpVector.Y;
            }
            else if (asteroidHitPoints == 1)
            {
                Vector2 tmpVector = new Vector2(20, 1);
                asteroidAnimation.Initialize(asteroidPos, tmpVector);
                asteroidImage = Content.Load<Texture2D>("asteroid1Sheet");
                width = asteroidImage.Width / (int)tmpVector.X;
                height = asteroidImage.Height / (int)tmpVector.Y;
            }
            else
            {
                Vector2 tmpVector = new Vector2(39, 1);
                asteroidAnimation.Initialize(asteroidPos, tmpVector);
                asteroidImage = Content.Load<Texture2D>("astExplodeMain");
                width = asteroidImage.Width / (int)tmpVector.X;
                height = asteroidImage.Height / (int)tmpVector.Y;
            }
            asteroidAnimation.LoadContent(Content, asteroidImage);
        }

        public void Update(GameTime gameTime, Texture2D backgroundTexture, Camera camera)
        {
            asteroidPos -= asteroidVelocity;

            if (asteroidPos.X < backgroundTexture.Bounds.Left - width)
            {
                asteroidPos = new Vector2(backgroundTexture.Bounds.Right, asteroidPos.Y);
            }
            if (asteroidPos.Y < backgroundTexture.Bounds.Top - height)
            {
                asteroidPos = new Vector2(asteroidPos.X, backgroundTexture.Bounds.Bottom);
            }
            if (asteroidPos.X > backgroundTexture.Bounds.Right + width)
            {
                asteroidPos = new Vector2(backgroundTexture.Bounds.Left, asteroidPos.Y);
            }
            if (asteroidPos.Y > backgroundTexture.Bounds.Bottom + height)
            {
                asteroidPos = new Vector2(asteroidPos.X, backgroundTexture.Bounds.Top);
            }
            

            animMod = 1;
            asteroidAnimation.Active = true;
            asteroidRect = new Rectangle((int)asteroidPos.X, (int)asteroidPos.Y, 0, 0);
            
            asteroidAnimation.Update(gameTime, animMod, true, asteroidRect);
            asteroidRect = asteroidAnimation.AnimationRect;
            asteroidBlockTransform = Matrix.CreateTranslation(new Vector3(asteroidPos, 0.0f));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            asteroidAnimation.Draw(spriteBatch, asteroidRotation, asteroidPos, asteroidScale);
        }

        #endregion

        #region Destructor

        ~Asteroid()
        {

        }

        #endregion

    }

}
