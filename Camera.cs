//followed tutrial at http://www.youtube.com/watch?v=pin8_ZfBgq0
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookExample
{
    public class Camera
    {
        public Matrix transform;
        public Viewport view;
        public Vector2 centre;

        public Camera(Viewport newView)
        {
            view = newView;
        }

        public void Update(GameTime gameTime, Game1 game, Texture2D backgroundTexture)
        {
            centre = new Vector2(game.Ship.ShipPos.X + (game.Ship.ShipRect.Width / 2) - game.Graphics.PreferredBackBufferWidth / 2, game.Ship.ShipPos.Y + (game.Ship.ShipRect.Height / 2) - game.Graphics.PreferredBackBufferHeight / 2);
            
            if (centre.X >= backgroundTexture.Bounds.Right - game.Graphics.PreferredBackBufferWidth)
            {
                centre.X = backgroundTexture.Bounds.Right - game.Graphics.PreferredBackBufferWidth;
            }
            if (centre.X <= backgroundTexture.Bounds.Left)
            {
                centre.X = backgroundTexture.Bounds.Left;
            }
            if (centre.Y >= backgroundTexture.Bounds.Bottom - game.Graphics.PreferredBackBufferHeight)
            {
                centre.Y = backgroundTexture.Bounds.Bottom - game.Graphics.PreferredBackBufferHeight;
            }
            if (centre.Y <= backgroundTexture.Bounds.Top)
            {
                centre.Y = backgroundTexture.Bounds.Top;
            }
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));
        }

    }
}
