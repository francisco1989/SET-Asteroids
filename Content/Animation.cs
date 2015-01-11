using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookExample.Content
{
    public class Animation
    {
        public int frameCounter;
        public int switchFrame;
        public Rectangle animationRect;
        public Texture2D animationImage;
        public int frameWidth;
        public int frameHeight;
        public bool active;
        public Vector2 position, amountOfFrames, currentFrame;
        public Rectangle sourceRect;
        public float rotation;
        public Texture2D tmp;

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
                        if (currentFrame.X >= animationImage.Width)
                        {
                            currentFrame.X = 0;
                        }
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
            if(animationImage.Name == "earthSpriteSheet")
            {
                spriteBatch.Draw(animationImage, position, sourceRect, Color.White);
            }

            if (animationImage.Name == "asteroid1Sheet" || animationImage.Name == "asteroid2Sheet" || animationImage.Name == "asteroid3Sheet")
            {
                spriteBatch.Draw(animationImage, position, sourceRect, Color.White);
            }

            if (animationImage.Name == "shipSpriteSheet")
            {
                spriteBatch.Draw(animationImage, position, sourceRect, Color.White, rotation - 80, Vector2.One * 35, scale, SpriteEffects.None, 0);
            }
        }
    }
}
