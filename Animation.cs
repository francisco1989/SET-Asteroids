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

namespace BookExample.Content
{
    public class Animation
    {
        #region Encapsulated Methods

        private Vector3 animationBlock;

        public Vector3 AnimationBlock
        {
            get { return animationBlock; }
            set { animationBlock = value; }
        }
        private Vector2 animationOrigin;

        public Vector2 AnimationOrigin
        {
            get { return animationOrigin; }
            set { animationOrigin = value; }
        }

        private int frameCounter;

        public int FrameCounter
        {
            get { return frameCounter; }
            set { frameCounter = value; }
        }
        private int switchFrame;

        public int SwitchFrame
        {
            get { return switchFrame; }
            set { switchFrame = value; }
        }
        private Rectangle animationRect;

        public Rectangle AnimationRect
        {
            get { return animationRect; }
            set { animationRect = value; }
        }
        private Texture2D animationImage;

        public Texture2D AnimationImage
        {
            get { return animationImage; }
            set { animationImage = value; }
        }
        private int frameWidth;

        public int FrameWidth
        {
            get { return frameWidth; }
            set { frameWidth = value; }
        }
        private int frameHeight;

        public int FrameHeight
        {
            get { return frameHeight; }
            set { frameHeight = value; }
        }
        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        private Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        private Vector2 amountOfFrames;

        public Vector2 AmountOfFrames
        {
            get { return amountOfFrames; }
            set { amountOfFrames = value; }
        }
        private Vector2 currentFrame;

        public Vector2 CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }
        private Rectangle sourceRect;

        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }
        private float rotation;

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        private Texture2D tmp;

        public Texture2D Tmp
        {
            get { return tmp; }
            set { tmp = value; }
        }

        #endregion

        #region Constructors

        public Animation()
        {

        }

        #endregion

        #region Methods

        public void Initialize(Vector2 position, Vector2 frames)
        {
            active = false;
            switchFrame = 60;
            frameCounter = 0;
            this.position = position;
            this.amountOfFrames = frames;
            animationRect = new Rectangle(0,0,0,0);
            frameWidth = 0;
            frameHeight = 0;
            currentFrame = new Vector2(0,0);
            sourceRect = new Rectangle(0,0,0,0);
            rotation = 0;
        }

        public void LoadContent(ContentManager Content, Texture2D theSheet)
        {
            animationImage = theSheet;
            animationRect = new Rectangle((int)position.X, (int)position.Y, theSheet.Width, theSheet.Height);
            frameWidth = theSheet.Width / (int)amountOfFrames.X;
            frameHeight = theSheet.Height / (int)amountOfFrames.Y;
        }

        public void Update(GameTime gameTime, int animMod, bool isMoving, Rectangle spriteRect)
        {
            if (active)
            {
                frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds / animMod;
            }
            else
            {
                frameCounter = 0;
            }

            if (frameCounter >= switchFrame)
            {
                if (animationImage.Name == "shipSpriteSheet")
                {
                    if (isMoving)
                    {
                        frameCounter = 0;
                        currentFrame.X += frameWidth;
                        if (currentFrame.X >= animationImage.Width)
                        {
                            currentFrame.X = 0;
                        }
                    }
                    else
                    {
                        frameCounter = 0;
                        currentFrame.X = 0;
                    }
                }
                else
                {
                    frameCounter = 0;
                    currentFrame.X += frameWidth;
                    if (currentFrame.X >= animationImage.Width)
                    {
                        currentFrame.X = 0;
                    }
                }
            }
            
            sourceRect = new Rectangle((int)currentFrame.X, (int)currentFrame.Y, frameWidth, frameHeight);
            animationRect = new Rectangle(spriteRect.X, spriteRect.Y, frameWidth, frameHeight);  
        }

        public void Draw(SpriteBatch spriteBatch, float rotation, Vector2 position, float scale)
        {
            float rotMod = 80;
            rotation -= rotMod;
            if(animationImage.Name == "earthSpriteSheet")
            {
                spriteBatch.Draw(animationImage, position, sourceRect, Color.White);
            }

            if (animationImage.Name == "asteroid1Sheet" || animationImage.Name == "asteroid2Sheet" || animationImage.Name == "asteroid3Sheet")
            {
                spriteBatch.Draw(animationImage, position, sourceRect, Color.White);
            }
            if (animationImage.Name == "astExplodeMain")
            {
                spriteBatch.Draw(animationImage, position, sourceRect, Color.White, rotation, Vector2.One * 35, scale, SpriteEffects.None, 0);
            }
            if (animationImage.Name == "shipSpriteSheet" || animationImage.Name == "shipExplodeSheet")
            {
                spriteBatch.Draw(animationImage, position, sourceRect, Color.White, rotation, Vector2.One * 35, scale, SpriteEffects.None, 0);
            }
        }

        #endregion

        #region Destructor

        ~Animation()
        {

        }

        #endregion

    }
}
