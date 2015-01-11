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
    class AboutScreen : Screen
    {
        #region Fields

        private ContentManager Content;
        private Texture2D line1;
        private Vector2 line1Pos;
        private float line1Scale;
        private Texture2D line2;
        private Vector2 line2Pos;
        private float line2Scale;
        private Texture2D line3;
        private Vector2 line3Pos;
        private float line3Scale;
        private Texture2D line4;
        private Vector2 line4Pos;
        private float line4Scale;
        private Texture2D line5;
        private Vector2 line5Pos;
        private float line5Scale;
        private Texture2D line6;
        private Vector2 line6Pos;
        private float line6Scale;
        private float speedCounter;
        #endregion

        #region Constructor

        public AboutScreen()
        {
            //1060 by 180
        }

        #endregion

        #region Methods

        public override void Initialize(Vector2 position, Camera camera)
        {
            speedCounter = 0;
            BackPos = camera.centre;
            line1Scale = 1.0f;
            line2Scale = 1.0f;
            line3Scale = 1.0f;
            line4Scale = 1.0f;
            line5Scale = 1.0f;
            line6Scale = 1.0f;
            //line1Pos = camera.centre;
            line1Pos = new Vector2(camera.centre.X + 100, camera.centre.Y + 760);
            line2Pos = new Vector2(camera.centre.X + 100, camera.centre.Y + 950);
            line3Pos = new Vector2(camera.centre.X + 100, camera.centre.Y + 1140);
            line4Pos = new Vector2(camera.centre.X + 100, camera.centre.Y + 1330);
            line5Pos = new Vector2(camera.centre.X + 100, camera.centre.Y + 1520);
            line6Pos = new Vector2(camera.centre.X + 100, camera.centre.Y + 1710);
        }

        public override void LoadContent(ContentManager newContent)
        {
            Content = newContent;
            Background = Content.Load<Texture2D>("Screens/AboutScreen/background");
            line1 = Content.Load<Texture2D>("Screens/AboutScreen/line1");
            line2 = Content.Load<Texture2D>("Screens/AboutScreen/line2");
            line3 = Content.Load<Texture2D>("Screens/AboutScreen/line3");
            line4 = Content.Load<Texture2D>("Screens/AboutScreen/line4");
            line5 = Content.Load<Texture2D>("Screens/AboutScreen/line5");
            line6 = Content.Load<Texture2D>("Screens/AboutScreen/line6");
        }

        public override void Update(GameTime gameTime, Camera camera)
        {

            speedCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (speedCounter > 60)
            {
                line1Pos.Y -= 5;
                line1Pos.X += 3.5f;
                line1Scale -= 0.007f;

                line2Pos.Y -= 5;
                if (line2Pos.Y < camera.centre.Y + 760)
                {
                    line2Pos.X += 3.5f;
                    line2Scale -= 0.007f;
                }

                line3Pos.Y -= 5;
                if (line3Pos.Y < camera.centre.Y + 760)
                {
                    line3Pos.X += 3.5f;
                    line3Scale -= 0.007f;
                }

                line4Pos.Y -= 5;
                if (line4Pos.Y < camera.centre.Y + 760)
                {
                    line4Pos.X += 3.5f;
                    line4Scale -= 0.007f;
                }

                line5Pos.Y -= 5;
                if (line5Pos.Y < camera.centre.Y + 760)
                {
                    line5Pos.X += 3.5f;
                    line5Scale -= 0.007f;
                }

                line6Pos.Y -= 5;
                if (line6Pos.Y < camera.centre.Y + 760)
                {
                    line6Pos.X += 3.5f;
                    line6Scale -= 0.007f;
                    if (line6Scale < 0)
                    {
                        Game1.CurrentScreen = 1;
                        speedCounter = 0;
                        BackPos = camera.centre;
                        line1Scale = 1.0f;
                        line2Scale = 1.0f;
                        line3Scale = 1.0f;
                        line4Scale = 1.0f;
                        line5Scale = 1.0f;
                        line6Scale = 1.0f;
                        //line1Pos = camera.centre;
                        line1Pos = new Vector2(camera.centre.X + 100, camera.centre.Y + 760);
                        line2Pos = new Vector2(camera.centre.X + 100, camera.centre.Y + 950);
                        line3Pos = new Vector2(camera.centre.X + 100, camera.centre.Y + 1140);
                        line4Pos = new Vector2(camera.centre.X + 100, camera.centre.Y + 1330);
                        line5Pos = new Vector2(camera.centre.X + 100, camera.centre.Y + 1520);
                        line6Pos = new Vector2(camera.centre.X + 100, camera.centre.Y + 1710);
                    }
                }
                speedCounter = 0;
            }
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Background, BackPos, Color.White);
            spriteBatch.Draw(line1, line1Pos, null, Color.White, 0.0f, Vector2.One, line1Scale, SpriteEffects.None, 0);
            spriteBatch.Draw(line2, line2Pos, null, Color.White, 0.0f, Vector2.One, line2Scale, SpriteEffects.None, 0);
            spriteBatch.Draw(line3, line3Pos, null, Color.White, 0.0f, Vector2.One, line3Scale, SpriteEffects.None, 0);
            spriteBatch.Draw(line4, line4Pos, null, Color.White, 0.0f, Vector2.One, line4Scale, SpriteEffects.None, 0);
            spriteBatch.Draw(line5, line5Pos, null, Color.White, 0.0f, Vector2.One, line5Scale, SpriteEffects.None, 0);
            spriteBatch.Draw(line6, line6Pos, null, Color.White, 0.0f, Vector2.One, line6Scale, SpriteEffects.None, 0);
            spriteBatch.End();
        }

        #endregion
    }
}
