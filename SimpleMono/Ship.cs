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
    public class Ship
    {
        #region Encapsulated Fields

        private Matrix shipBlockTransform;

        public Matrix ShipBlockTransform
        {
            get { return shipBlockTransform; }
            set { shipBlockTransform = value; }
        }

        private Vector2 shipOrigin;
        public Vector2 ShipOrigin
        {
            get { return shipOrigin; }
            set { shipOrigin = value; }
        }

        private Vector3 shipBlock;

        public Vector3 ShipBlock
        {
            get { return shipBlock; }
            set { shipBlock = value; }
        }

       
        private MouseState previousMouseState;

        public MouseState PreviousMouseState
        {
            get { return previousMouseState; }
            set { previousMouseState = value; }
        }
        private Rectangle shipRect;

        public Rectangle ShipRect
        {
            get { return shipRect; }
            set { shipRect = value; }
        }
        private Vector2 shipPos;

        public Vector2 ShipPos
        {
            get { return shipPos; }
            set { shipPos = value; }
        }
        private Vector2 shipVelocity;

        public Vector2 ShipVelocity
        {
            get { return shipVelocity; }
            set { shipVelocity = value; }
        }
        private Texture2D ship;

        public Texture2D Ship1
        {
            get { return ship; }
            set { ship = value; }
        }
        private int shipHeight;

        public int ShipHeight
        {
            get { return shipHeight; }
            set { shipHeight = value; }
        }
        private int shipWidth;

        public int ShipWidth
        {
            get { return shipWidth; }
            set { shipWidth = value; }
        }
        private Vector2 shipDirection;

        public Vector2 ShipDirection
        {
            get { return shipDirection; }
            set { shipDirection = value; }
        }
        private float shipRotation;

        public float ShipRotation
        {
            get { return shipRotation; }
            set { shipRotation = value; }
        }
        private Animation shipAnimation = new Animation();

        public Animation ShipAnimation
        {
            get { return shipAnimation; }
            set { shipAnimation = value; }
        }
        private int animMod;

        public int AnimMod
        {
            get { return animMod; }
            set { animMod = value; }
        }
        private int xViewMod;

        public int XViewMod
        {
            get { return xViewMod; }
            set { xViewMod = value; }
        }
        private int yViewMod;

        public int YViewMod
        {
            get { return yViewMod; }
            set { yViewMod = value; }
        }
        private bool isMoving;

        public bool IsMoving
        {
            get { return isMoving; }
            set { isMoving = value; }
        }
        private float shipScale;

        public float ShipScale
        {
            get { return shipScale; }
            set { shipScale = value; }
        }

        private bool isDestroyed;

        public bool IsDestroyed
        {
            get { return isDestroyed; }
            set { isDestroyed = value; }
        }

        #endregion

        #region Constructors

        public Ship()
        {

        }

        #endregion

        #region Methods

        public void Initialize(Vector2 position, bool destroyed)
        {
            previousMouseState = Mouse.GetState();
            isMoving = false;
            shipPos = position;
            isDestroyed = destroyed;
            xViewMod = 700;
            yViewMod = 500;
            shipScale = 1.0f;
            shipVelocity = new Vector2(1, 1);
        }

        public void LoadContent(ContentManager Content)
        {
            if (isDestroyed)
            {
                Vector2 tmpVector = new Vector2(17, 1);
                shipAnimation.Initialize(shipPos, tmpVector);
                ship = Content.Load<Texture2D>("shipExplodeSheet");
                shipWidth = ship.Width / (int)tmpVector.X;
                shipHeight = ship.Height / (int)tmpVector.Y;
                shipAnimation.LoadContent(Content, ship);
            }
            else
            {
                Vector2 tmpVector = new Vector2(10, 1);
                shipAnimation.Initialize(shipPos, tmpVector);
                ship = Content.Load<Texture2D>("shipSpriteSheet");
                shipWidth = ship.Width / (int)tmpVector.X;
                shipHeight = ship.Height / (int)tmpVector.Y;
                shipAnimation.LoadContent(Content, ship);
            }

            shipOrigin = Vector2.One * 35;
        }

        public void Update(GameTime gameTime, Camera camera, Texture2D backgroundTexture)
        {
            shipVelocity = shipVelocity - new Vector2(0.005f, 0.005f);
            if (shipVelocity.X < 0 && shipVelocity.Y < 0)
            {
                shipVelocity = new Vector2(0, 0);
            }
            MouseState curMouse = Mouse.GetState();
            Vector2 mouseLoc = new Vector2(curMouse.X + camera.centre.X, curMouse.Y + camera.centre.Y);
            shipPos += shipDirection * (shipVelocity) * gameTime.ElapsedGameTime.Milliseconds;
            if (shipPos.X > backgroundTexture.Bounds.Right)
            {
                shipPos.X = backgroundTexture.Bounds.Left;
            }
            else if (shipPos.X < backgroundTexture.Bounds.Left)
            {
                shipPos.X = backgroundTexture.Bounds.Right;
            }
            else if (shipPos.Y > backgroundTexture.Bounds.Bottom)
            {
                shipPos.Y = backgroundTexture.Bounds.Top;
            }
            else if (shipPos.Y < backgroundTexture.Bounds.Top)
            {
                shipPos.Y = backgroundTexture.Bounds.Bottom;
            }
            
            if (previousMouseState.X != Mouse.GetState().X || previousMouseState.Y != Mouse.GetState().Y)
            {
                shipDirection = mouseLoc - shipPos;
                shipDirection.Normalize();
                shipRotation = (float)(Math.Atan2(shipDirection.Y, shipDirection.X));
            }
            if (previousMouseState.RightButton == ButtonState.Pressed
            && Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                isMoving = true;
                shipVelocity = shipVelocity + new Vector2(0.02f, 0.02f);
                if (shipVelocity.X > 1 && shipVelocity.Y > 1)
                {
                    shipVelocity = new Vector2(1, 1);
                }
                if (shipPos.X <= backgroundTexture.Bounds.Right && 
                    shipPos.X >= backgroundTexture.Bounds.Left && 
                    shipPos.Y <= backgroundTexture.Bounds.Bottom &&
                    shipPos.Y >= backgroundTexture.Bounds.Top)
                {

                    shipDirection = new Vector2((float)Math.Cos(shipRotation), (float)Math.Sin(shipRotation));
                    shipPos += shipDirection * shipVelocity * gameTime.ElapsedGameTime.Milliseconds;
                }
                else
                {
                    if (shipPos.X > backgroundTexture.Bounds.Right)
                    {
                        shipPos.X = backgroundTexture.Bounds.Left;
                    }
                    else if (shipPos.X < backgroundTexture.Bounds.Left)
                    {
                        shipPos.X = backgroundTexture.Bounds.Right;
                    }
                    else if (shipPos.Y > backgroundTexture.Bounds.Bottom)
                    {
                        shipPos.Y = backgroundTexture.Bounds.Top;
                    }
                    else if (shipPos.Y < backgroundTexture.Bounds.Top)
                    {
                        shipPos.Y = backgroundTexture.Bounds.Bottom;
                    }
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                shipRotation += 0.15f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                shipRotation -= 0.15f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                isMoving = true;
                shipVelocity = shipVelocity + new Vector2(0.02f, 0.02f);
                if (shipVelocity.X > 2 && shipVelocity.Y > 2)
                {
                    shipVelocity = new Vector2(2, 2);
                }
                if (shipPos.X <= backgroundTexture.Bounds.Right &&
                    shipPos.X >= backgroundTexture.Bounds.Left &&
                    shipPos.Y <= backgroundTexture.Bounds.Bottom &&
                    shipPos.Y >= backgroundTexture.Bounds.Top)
                {
                    shipDirection = new Vector2((float)Math.Cos(shipRotation), (float)Math.Sin(shipRotation));
                    shipPos += shipDirection * shipVelocity * gameTime.ElapsedGameTime.Milliseconds;
                }
                else
                {
                    if (shipPos.X > backgroundTexture.Bounds.Right)
                    {
                        shipPos.X = backgroundTexture.Bounds.Left;
                    }
                    else if (shipPos.X < backgroundTexture.Bounds.Left)
                    {
                        shipPos.X = backgroundTexture.Bounds.Right;
                    }
                    else if (shipPos.Y > backgroundTexture.Bounds.Bottom)
                    {
                        shipPos.Y = backgroundTexture.Bounds.Top;
                    }
                    else if (shipPos.Y < backgroundTexture.Bounds.Top)
                    {
                        shipPos.Y = backgroundTexture.Bounds.Bottom;
                    }
                }
            }
            else
            {
                isMoving = false;
            }

            previousMouseState = Mouse.GetState();

            animMod = 1;
            shipAnimation.Active = true;
            shipRect = new Rectangle((int)shipPos.X, (int)shipPos.Y, 0, 0);
            shipAnimation.Update(gameTime, animMod, isMoving, shipRect);
            shipRect = shipAnimation.AnimationRect;
            shipBlock = new Vector3(shipPos, shipRotation - 80);
            shipBlockTransform = Matrix.CreateTranslation(new Vector3(-shipOrigin, 0.0f)) *
                                 Matrix.CreateRotationZ(shipRotation) *
                                 Matrix.CreateTranslation(new Vector3(shipPos, 0.0f));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            shipAnimation.Draw(spriteBatch, shipRotation, shipPos, shipScale);
        }

        #endregion

        #region Destructor

        ~Ship()
        {

        }

        #endregion
    }
}
