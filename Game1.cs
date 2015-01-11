// crop method was taken from http://stackoverflow.com/questions/8331494/crop-texture2d-spritesheet
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
using BookExample.Screens;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

#endregion

namespace BookExample
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        #region Encapsulated Fields

        private static int prevScreen;
        public static int PrevScreen
        {
            get { return Game1.prevScreen; }
            set { Game1.prevScreen = value; }
        }

        private ControlScreen controlScreen;
        internal ControlScreen ControlScreen
        {
            get { return controlScreen; }
            set { controlScreen = value; }
        }

        private SoundEffectInstance laser1Instance;
        public SoundEffectInstance Laser1Instance
        {
            get { return laser1Instance; }
            set { laser1Instance = value; }
        }

        private SoundEffectInstance explosion1Instance;
        public SoundEffectInstance Explosion1Instance
        {
            get { return explosion1Instance; }
            set { explosion1Instance = value; }
        }

        private SoundEffectInstance explosion2Instance;
        public SoundEffectInstance Explosion2Instance
        {
            get { return explosion2Instance; }
            set { explosion2Instance = value; }
        }

        private SoundEffectInstance thrusterInstance;
        public SoundEffectInstance ThrusterInstance
        {
            get { return thrusterInstance; }
            set { thrusterInstance = value; }
        }

        private SoundEffectInstance mainMusicInstance;
        public SoundEffectInstance MainMusicInstance
        {
          get { return mainMusicInstance; }
          set { mainMusicInstance = value; }
        }

        private SoundEffectInstance lastMusicInstance;
        public SoundEffectInstance LastMusicInstance
        {
            get { return lastMusicInstance; }
            set { lastMusicInstance = value; }
        }

        private SoundEffect lastMusic;
        public SoundEffect LastMusic
        {
            get { return lastMusic; }
            set { lastMusic = value; }
        }

        private SoundEffect explosion1Sound;
        public SoundEffect Explosion1Sound
        {
            get { return explosion1Sound; }
            set { explosion1Sound = value; }
        }

        private SoundEffect explosion2Sound;
        public SoundEffect Explosion2Sound
        {
            get { return explosion2Sound; }
            set { explosion2Sound = value; }
        }

        private SoundEffect laserSound;
        public SoundEffect LaserSound
        {
            get { return laserSound; }
            set { laserSound = value; }
        }

        private SoundEffect thrusterSound;
        public SoundEffect ThrusterSound
        {
          get { return thrusterSound; }
          set { thrusterSound = value; }
        }

        private SoundEffect mainMusic;
        public SoundEffect MainMusic
        {
            get { return mainMusic; }
            set { mainMusic = value; }
        }

        private Texture2D power;
        public Texture2D Power
        {
            get { return power; }
            set { power = value; }
        }

        private float forcePowerWidth;
        public float ForcePowerWidth
        {
            get { return forcePowerWidth; }
            set { forcePowerWidth = value; }
        }

        private float forcePowerHeight;
        public float ForcePowerHeight
        {
            get { return forcePowerHeight; }
            set { forcePowerHeight = value; }
        }

        private Texture2D pauseTexture;
        public Texture2D PauseTexture
        {
            get { return pauseTexture; }
            set { pauseTexture = value; }
        }

        private bool isPaused;
        public bool IsPaused
        {
            get { return isPaused; }
            set { isPaused = value; }
        }

        private GameoverScreen gameoverScreen;
        internal GameoverScreen GameoverScreen
        {
            get { return gameoverScreen; }
            set { gameoverScreen = value; }
        }

        private int hudsVisible;
        public int HudsVisible
        {
            get { return hudsVisible; }
            set { hudsVisible = value; }
        }

        private int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        private AboutScreen aboutScreen;

        internal AboutScreen AboutScreen
        {
            get { return aboutScreen; }
            set { aboutScreen = value; }
        }

        private TitleScreen titleScreen;

        internal TitleScreen TitleScreen
        {
            get { return titleScreen; }
            set { titleScreen = value; }
        }

        private static int currentScreen;

        public static int CurrentScreen
        {
            get { return Game1.currentScreen; }
            set { Game1.currentScreen = value; }
        }

        private Matrix cursorBlockTransform;

        public Matrix CursorBlockTransform
        {
            get { return cursorBlockTransform; }
            set { cursorBlockTransform = value; }
        }

        private KeyboardState oldState2;
        public KeyboardState OldState2
        {
            get { return oldState2; }
            set { oldState2 = value; }
        }

        private KeyboardState oldState;
        public KeyboardState OldState
        {
            get { return oldState; }
            set { oldState = value; }
        }

        private bool wasCollision;
        public bool WasCollision
        {
            get { return wasCollision; }
            set { wasCollision = value; }
        }

        private Texture2D shipLives;

        public Texture2D ShipLives
        {
            get { return shipLives; }
            set { shipLives = value; }
        }
        private int lives;

        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        private Texture2D miniEarth;

        public Texture2D MiniEarth
        {
            get { return miniEarth; }
            set { miniEarth = value; }
        }
        private Texture2D greenDot;

        public Texture2D GreenDot
        {
            get { return greenDot; }
            set { greenDot = value; }
        }
        private Texture2D redDot;

        public Texture2D RedDot
        {
            get { return redDot; }
            set { redDot = value; }
        }

        private Texture2D bottomhud;
        public Texture2D Bottomhud
        {
            get { return bottomhud; }
            set { bottomhud = value; }
        }

        private Texture2D tophud;
        public Texture2D Tophud
        {
            get { return tophud; }
            set { tophud = value; }
        }

        private Texture2D minimap;
        public Texture2D Minimap
        {
            get { return minimap; }
            set { minimap = value; }
        }

        private Animation asteroidExplode;
        public Animation AsteroidExplode
        {
            get { return asteroidExplode; }
            set { asteroidExplode = value; }
        }
        private SpriteFont font;

        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }
        private GraphicsDeviceManager graphics;

        public GraphicsDeviceManager Graphics
        {
            get { return graphics; }
            set { graphics = value; }
        }
        private SpriteBatch spriteBatch;

        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
            set { spriteBatch = value; }
        }
        private MouseState previousMouseState;

        public MouseState PreviousMouseState
        {
            get { return previousMouseState; }
            set { previousMouseState = value; }
        }
        private Texture2D customCursor;

        public Texture2D CustomCursor
        {
            get { return customCursor; }
            set { customCursor = value; }
        }
        private Vector2 cursorPos;

        public Vector2 CursorPos
        {
            get { return cursorPos; }
            set { cursorPos = value; }
        }
        private Rectangle cursorRect;

        public Rectangle CursorRect
        {
            get { return cursorRect; }
            set { cursorRect = value; }
        }
        private Texture2D tmp;

        public Texture2D Tmp
        {
            get { return tmp; }
            set { tmp = value; }
        }
        private List<Asteroid> asteroids;

        internal List<Asteroid> Asteroids
        {
            get { return asteroids; }
            set { asteroids = value; }
        }
        private int roundNumber;

        public int RoundNumber
        {
            get { return roundNumber; }
            set { roundNumber = value; }
        }
        private bool crosshairOn;

        public bool CrosshairOn
        {
            get { return crosshairOn; }
            set { crosshairOn = value; }
        }

        //Camera
        private Camera camera;

        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        //Background
        private Texture2D backgroundTexture;

        public Texture2D BackgroundTexture
        {
            get { return backgroundTexture; }
            set { backgroundTexture = value; }
        }
        private Vector2 backPos;

        public Vector2 BackPos
        {
            get { return backPos; }
            set { backPos = value; }
        }

        //Bullets
        private List<Bullet> bullets;

        public List<Bullet> Bullets
        {
            get { return bullets; }
            set { bullets = value; }
        }

        //class sprites
        private Ship ship;

        public Ship Ship
        {
            get { return ship; }
            set { ship = value; }
        }
        private Earth earth;

        public Earth Earth
        {
            get { return earth; }
            set { earth = value; }
        }
        

        #endregion

        #region  Constructors

        public Game1() : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = true;
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            forcePowerHeight = 15;
            forcePowerWidth = 100;
            isPaused = false;
            hudsVisible = 0;
            currentScreen = 1;
            wasCollision = false;
            lives = 3;
            earth = new Earth();
            ship = new Ship();
            bullets = new List<Bullet>();
            asteroids = new List<Asteroid>();
            backgroundTexture = Content.Load<Texture2D>("back3");
            backPos = new Vector2(0, 0);
            camera = new Camera(GraphicsDevice.Viewport);
            previousMouseState = Mouse.GetState();
            IsMouseVisible = false;
            ship.Initialize(new Vector2(2000, 2000), false);
            earth.Initialize(ship.ShipPos);
            roundNumber = 1;
            crosshairOn = true;
            CreateAsteroids();
            titleScreen = new TitleScreen();
            titleScreen.Initialize(new Vector2(2000,2000), camera);
            aboutScreen = new AboutScreen();
            aboutScreen.Initialize(new Vector2(2000, 2000), camera);
            gameoverScreen = new GameoverScreen();
            gameoverScreen.Initialize(new Vector2(2000, 2000), camera);
            controlScreen = new ControlScreen();
            controlScreen.Initialize(new Vector2(2000, 2000), camera);
            prevScreen = 1;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //sounds
            mainMusic = Content.Load<SoundEffect>("Audio/mainmusic");
            mainMusicInstance = mainMusic.CreateInstance();
            mainMusicInstance.IsLooped = true;
            mainMusicInstance.Play();
            mainMusicInstance.Volume = 0.0f;

            lastMusic = Content.Load<SoundEffect>("Audio/lastmusic");
            lastMusicInstance = lastMusic.CreateInstance();
            lastMusicInstance.IsLooped = true;
            
            thrusterSound = Content.Load<SoundEffect>("Audio/thrusters");
            thrusterInstance = thrusterSound.CreateInstance();

            explosion1Sound = Content.Load<SoundEffect>("Audio/exp1");
            explosion1Instance = explosion1Sound.CreateInstance();

            explosion2Sound = Content.Load<SoundEffect>("Audio/exp2");
            explosion2Instance = explosion2Sound.CreateInstance();

            laserSound = Content.Load<SoundEffect>("Audio/laser");
            laser1Instance = laserSound.CreateInstance();
            
            //fonts
            font = Content.Load<SpriteFont>("Fonts/stencil");

            //textures
            power = Content.Load<Texture2D>("greentexture");
            customCursor = Content.Load<Texture2D>("greencrosshair");
            pauseTexture = Content.Load<Texture2D>("paused");
            shipLives = Content.Load<Texture2D>("shiplives");
            redDot = Content.Load<Texture2D>("reddot");
            greenDot = Content.Load<Texture2D>("greendot");
            tophud = Content.Load<Texture2D>("tophud");
            bottomhud = Content.Load<Texture2D>("bottomhud");
            miniEarth = Content.Load<Texture2D>("miniEarth");
            tmp = Content.Load<Texture2D>("forcefield");

            spriteBatch = new SpriteBatch(GraphicsDevice);
            earth.LoadContent(Content);
            ship.LoadContent(Content);
            titleScreen.LoadContent(Content);
            aboutScreen.LoadContent(Content);
            gameoverScreen.LoadContent(Content);
            controlScreen.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            switch (currentScreen)
            {
                case 1:
                    prevScreen = 1;
                    mainMusicInstance.Volume = 0.0f;
                    IsMouseVisible = true;
                    titleScreen.Update(gameTime, camera);
                    break;

                case 2:
                    prevScreen = 2;
                    KeyboardState newState = Keyboard.GetState();
                    MouseState curMouse = Mouse.GetState();
                    cursorPos = new Vector2(curMouse.X + camera.centre.X, curMouse.Y + camera.centre.Y);
                    cursorRect = new Rectangle((int)cursorPos.X, (int)cursorPos.Y, customCursor.Width, customCursor.Height);
                    if (newState.IsKeyDown(Keys.P))
                    {
                        // If not down last update, key has just been pressed.
                        if (!oldState.IsKeyDown(Keys.P))
                        {
                            if (isPaused == true)
                            {
                                isPaused = false;
                            }
                            else
                            {
                                isPaused = true;
                            }
                        }
                    }
                    else if (oldState.IsKeyDown(Keys.P))
                    {
                        // Key was down last update, but not down now, so
                        // it has just been released.
                    }
                    oldState = newState;

                    if (isPaused == false)
                    {
                        mainMusicInstance.Volume = 0.3f;

                        #region Update Keyboard
                        KeyboardState newState2 = Keyboard.GetState();

                        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                        {
                            Exit();
                        }
                        else if (newState2.IsKeyDown(Keys.M))
                        {
                            // If not down last update, key has just been pressed.
                            if (!oldState2.IsKeyDown(Keys.M))
                            {
                                hudsVisible += 1;
                                if (hudsVisible > 2)
                                {
                                    hudsVisible = 0;
                                }
                            }
                        }
                        else if (oldState2.IsKeyDown(Keys.M))
                        {
                            // Key was down last update, but not down now, so
                            // it has just been released.
                        }

                        else if (newState2.IsKeyDown(Keys.Space))
                        {
                            // If not down last update, key has just been pressed.
                            if (!oldState2.IsKeyDown(Keys.Space))
                            {
                                Shoot();
                                foreach (Bullet b in bullets)
                                {
                                    b.Update(gameTime, camera);
                                }
                            }
                        }
                        else if (oldState2.IsKeyDown(Keys.Space))
                        {
                            // Key was down last update, but not down now, so
                            // it has just been released.
                        }

                        else if (newState2.IsKeyDown(Keys.B))
                        {
                            // If not down last update, key has just been pressed.
                            if (!oldState2.IsKeyDown(Keys.B))
                            {
                                currentScreen = 6;
                            }
                        }
                        else if (oldState2.IsKeyDown(Keys.B))
                        {
                            // Key was down last update, but not down now, so
                            // it has just been released.
                        }
                        else if (newState2.IsKeyDown(Keys.H))
                        {
                            // If not down last update, key has just been pressed.
                            if (!oldState2.IsKeyDown(Keys.H))
                            {
                                currentScreen = 7;
                            }
                        }
                        else if (oldState2.IsKeyDown(Keys.H))
                        {
                            // Key was down last update, but not down now, so
                            // it has just been released.
                        }
                        // Update saved state.
                        oldState2 = newState2;

                        #endregion

                        #region Update Mouse & Custom Cursor

                        IsMouseVisible = false;
                        curMouse = Mouse.GetState();
                        cursorPos = new Vector2(curMouse.X + camera.centre.X, curMouse.Y + camera.centre.Y);

                        if (previousMouseState.LeftButton == ButtonState.Released
                        && Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            Shoot();
                            foreach (Bullet b in bullets)
                            {
                                b.Update(gameTime, camera);
                            }
                        }

                        cursorRect = new Rectangle((int)cursorPos.X, (int)cursorPos.Y, customCursor.Width, customCursor.Height);
                        //check ship/cursor collision
                        if (cursorRect.Intersects(ship.ShipRect))
                        {
                            cursorPos = ship.ShipPos += ship.ShipDirection * (ship.ShipVelocity) * gameTime.ElapsedGameTime.Milliseconds;
                        }

                        customCursor = Content.Load<Texture2D>("greencrosshair");

                        #endregion

                        #region Update Earth

                        earth.Update(gameTime);

                        #endregion

                        #region Update Ship

                        //ship updates
                       
                        ship.Update(gameTime, camera, backgroundTexture);
                        if (ship.IsMoving == true)
                        {
                            thrusterInstance.Play();
                        }
                        else
                        {
                            thrusterInstance.Stop();
                        }
                        if (ship.ShipAnimation.AnimationImage.Name == "shipExplodeSheet")
                        {
                            if (ship.ShipAnimation.CurrentFrame.X >= ship.ShipAnimation.AnimationImage.Width - ship.ShipAnimation.FrameWidth)
                            {
                                ship.Initialize(new Vector2(2000, 2000), false);
                                ship.LoadContent(Content);
                            }
                        }

                        #endregion

                        #region Update Camera

                        camera.Update(gameTime, this, backgroundTexture);

                        #endregion

                        #region Update Asteroids

                        if (asteroids.Count == 0)
                        {
                            roundNumber += 1;
                            CreateAsteroids();
                        }

                        //iterate through asteroids
                        for (int i = 0; i < asteroids.Count; i++)
                        {
                            wasCollision = false;
                            asteroids[i].Update(gameTime, backgroundTexture, camera);

                            //check end explosions
                            if (asteroids[i].AsteroidAnimation.AnimationImage.Name == "astExplodeMain")
                            {
                                if (asteroids[i].AsteroidAnimation.CurrentFrame.X >= asteroids[i].AsteroidAnimation.AnimationImage.Width - asteroids[i].AsteroidAnimation.FrameWidth)
                                {
                                    wasCollision = true;
                                }
                            }
                            else
                            {
                                if (ship.ShipAnimation.AnimationImage.Name == "shipSpriteSheet")
                                {
                                    if (asteroids[i].AsteroidRect.Intersects(ship.ShipRect))
                                    {
                                        tmp = Crop(asteroids[i].AsteroidAnimation.AnimationImage, asteroids[i].AsteroidAnimation.SourceRect);
                                        Texture2D tmp2 = Crop(ship.ShipAnimation.AnimationImage, ship.ShipAnimation.SourceRect);

                                        if (PixelCollision(asteroids[i].AsteroidRect, tmp, asteroids[i].AsteroidBlockTransform, ship.ShipRect, tmp2, ship.ShipBlockTransform))
                                        {
                                            explosion2Instance.Play();
                                            lives -= 1;
                                            if (lives == 1)
                                            {
                                                mainMusicInstance.Volume = 0.0f;
                                                mainMusic.Dispose();
                                                mainMusicInstance.Dispose();
                                                lastMusicInstance.Play();
                                                lastMusicInstance.Volume = 5.0f;
                                            }
                                            if (lives < 1)
                                            {
                                                lastMusicInstance.Volume = 0.0f;
                                                lastMusic.Dispose();
                                                lastMusicInstance.Dispose();
                                                CurrentScreen = 5;
                                            }
                                            Vector2 tmpShipPos = ship.ShipPos;
                                            ship.Initialize(tmpShipPos, true);
                                            ship.LoadContent(Content);
                                            ship.ShipVelocity = new Vector2(0, 0);
                                            wasCollision = true;
                                        }
                                    }
                                }
                                if (asteroids[i].AsteroidRect.Intersects(cursorRect))
                                {
                                    cursorBlockTransform = Matrix.CreateTranslation(new Vector3(new Vector2(cursorRect.X, cursorRect.Y), 0.0f));
                                    tmp = Crop(asteroids[i].AsteroidAnimation.AnimationImage, asteroids[i].AsteroidAnimation.SourceRect);
                                    if (PixelCollision(asteroids[i].AsteroidRect, tmp, asteroids[i].AsteroidBlockTransform, cursorRect, customCursor, cursorBlockTransform))
                                    {
                                        customCursor = Content.Load<Texture2D>("redcrosshair");
                                    }
                                }
                                if (asteroids[i].AsteroidRect.Intersects(earth.ForceRect))
                                {
                                    //check to see if there is still a force field
                                    if (earth.ForceFieldPoints > 0)
                                    {
                                        //check rect collision for force field
                                        if (asteroids[i].AsteroidRect.Intersects(earth.ForceRect))
                                        {
                                            //check pixel collision for force field
                                            tmp = Crop(asteroids[i].AsteroidAnimation.AnimationImage, asteroids[i].AsteroidAnimation.SourceRect);
                                            if (PixelCollision(asteroids[i].AsteroidRect, tmp, asteroids[i].AsteroidBlockTransform, earth.ForceRect, earth.ForceField, earth.ForceBlockTransform))
                                            {
                                                earth.ForceFieldPoints -= 1;
                                                if (earth.ForceFieldPoints < 1)
                                                {
                                                    earth.ForceField.Dispose();
                                                }
                                                Random random = new Random();
                                                Asteroid tempAsteroid = new Asteroid();

                                                tempAsteroid.Initialize(asteroids[i].AsteroidPos + Vector2.One * asteroids[i].Width / 2, 0);
                                                tempAsteroid.LoadContent(Content);
                                                tempAsteroid.AsteroidVelocity = new Vector2(0, 0);
                                                asteroids.Add(tempAsteroid);
                                                wasCollision = true;
                                            }
                                        }
                                    }
                                    else//no force field so it hits earth
                                    {
                                        //check rect collison for earth
                                        if (asteroids[i].AsteroidRect.Intersects(earth.EarthRect))
                                        {
                                            //check Pixel collision for earth
                                            tmp = Crop(asteroids[i].AsteroidAnimation.AnimationImage, asteroids[i].AsteroidAnimation.SourceRect);
                                            Texture2D tmp2 = Crop(earth.EarthAnimation.AnimationImage, earth.EarthAnimation.SourceRect);
                                            if (PixelCollision(asteroids[i].AsteroidRect, tmp, asteroids[i].AsteroidBlockTransform, earth.EarthRect, tmp2, earth.EarthBlockTransform))
                                            {
                                                earth.HitPoints -= 1;
                                                if (earth.HitPoints < 1)
                                                {
                                                    currentScreen = 5;
                                                }
                                                else
                                                {
                                                    Random random = new Random();
                                                    Asteroid tempAsteroid = new Asteroid();

                                                    tempAsteroid.Initialize(asteroids[i].AsteroidPos + Vector2.One * asteroids[i].Width / 2, 0);
                                                    tempAsteroid.LoadContent(Content);
                                                    tempAsteroid.AsteroidVelocity = new Vector2(0, 0);
                                                    asteroids.Add(tempAsteroid);
                                                    wasCollision = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (wasCollision == true)
                            {
                                asteroids.RemoveAt(i);
                                i--;
                                if (asteroids.Count == 0)
                                {
                                    roundNumber += 1;
                                    CreateAsteroids();
                                }
                            }
                        }

                        #endregion

                        #region Update bullets
                        //update bullets
                        for (int bCounter = 0; bCounter < bullets.Count; bCounter++)
                        {
                            bullets[bCounter].BulletVelocity += ship.ShipVelocity;
                            bullets[bCounter].Update(gameTime, camera);

                            for (int i = 0; i < asteroids.Count; i++)
                            {
                                if (bullets[bCounter].SourceRect.Intersects(asteroids[i].AsteroidRect))
                                {
                                    tmp = Crop(asteroids[i].AsteroidAnimation.AnimationImage, asteroids[i].AsteroidAnimation.SourceRect);
                                    if (PixelCollision(asteroids[i].AsteroidRect, tmp, asteroids[i].AsteroidBlockTransform, bullets[bCounter].SourceRect, bullets[bCounter].BulletTexture, bullets[bCounter].BulletBlockTransform))
                                    {
                                        if (explosion1Instance.State == SoundState.Playing)
                                        {
                                            explosion1Instance.Stop();
                                            explosion1Instance.Play();
                                        }
                                        else
                                        {
                                            explosion1Instance.Play();
                                        }
                                        if (asteroids[i].AsteroidHitPoints == 3)
                                        {
                                            score += 10;
                                            Random random = new Random();
                                            Asteroid tempAsteroid = new Asteroid();

                                            tempAsteroid.Initialize(asteroids[i].AsteroidPos, 2);
                                            tempAsteroid.LoadContent(Content);
                                            tempAsteroid.AsteroidVelocity = new Vector2((float)random.NextDouble() * roundNumber, (float)random.NextDouble() * roundNumber);

                                            asteroids.Add(tempAsteroid);

                                            random = new Random();
                                            tempAsteroid = new Asteroid();

                                            tempAsteroid.Initialize(asteroids[i].AsteroidPos, 2);
                                            tempAsteroid.LoadContent(Content);
                                            tempAsteroid.AsteroidVelocity = new Vector2((float)random.NextDouble() * roundNumber * 3, (float)random.NextDouble() * roundNumber * 3);

                                            asteroids.Add(tempAsteroid);
                                        }
                                        else if (asteroids[i].AsteroidHitPoints == 2)
                                        {
                                            score += 25;
                                            Random random = new Random();
                                            Asteroid tempAsteroid = new Asteroid();

                                            tempAsteroid.Initialize(asteroids[i].AsteroidPos, 1);
                                            tempAsteroid.LoadContent(Content);
                                            tempAsteroid.AsteroidVelocity = new Vector2((float)random.NextDouble() * roundNumber, (float)random.NextDouble() * roundNumber);

                                            asteroids.Add(tempAsteroid);

                                            random = new Random();
                                            tempAsteroid = new Asteroid();

                                            tempAsteroid.Initialize(asteroids[i].AsteroidPos, 1);
                                            tempAsteroid.LoadContent(Content);
                                            tempAsteroid.AsteroidVelocity = new Vector2((float)random.NextDouble() * roundNumber * 3, (float)random.NextDouble() * roundNumber * 3);
                                            asteroids.Add(tempAsteroid);

                                        }
                                        else if (asteroids[i].AsteroidHitPoints == 1)
                                        {
                                            score += 50;
                                            Random random = new Random();
                                            Asteroid tempAsteroid = new Asteroid();

                                            tempAsteroid.Initialize(asteroids[i].AsteroidPos + Vector2.One * asteroids[i].Width / 2, 0);
                                            tempAsteroid.LoadContent(Content);
                                            tempAsteroid.AsteroidVelocity = new Vector2(0, 0);
                                            asteroids.Add(tempAsteroid);
                                        }
                                        asteroids.RemoveAt(i);
                                        i--;
                                        bullets.RemoveAt(bCounter);
                                        bCounter--;

                                        if (asteroids.Count == 0)
                                        {
                                            roundNumber += 1;
                                            CreateAsteroids();
                                        }

                                        break;

                                    }
                                }
                            }

                        }
                        for (int i = 0; i < bullets.Count; i++)
                        {
                            if (!bullets[i].IsVisible)
                            {
                                bullets.RemoveAt(i);
                                i--;
                            }
                        }
                        #endregion

                        forcePowerWidth = earth.ForceFieldPoints * 15;
                        previousMouseState = Mouse.GetState();
                        base.Update(gameTime);
                    }
                    else
                    {
                        mainMusicInstance.Volume = 0.0f;
                    }
                    break;
                case 3:
                    mainMusicInstance.Volume = 0.0f;
                    IsMouseVisible = true;
                    aboutScreen.Update(gameTime, camera);
                    break;
                case 4:
                    Exit();
                    break;
                case 5:
                    mainMusicInstance.Stop();
                    mainMusic.Dispose();
                    IsMouseVisible = false;
                    gameoverScreen.Update(gameTime, camera);
                    break;
                case 6:
                    lastMusicInstance.Stop();
                    lastMusic.Dispose();
                    this.Initialize();
                    break;
                case 7:
                    IsMouseVisible = true;
                    controlScreen.Update(gameTime, camera);
                    break;
            }
            
            base.Update(gameTime);
        }

        private void CreateAsteroids()
        {
            Random random = new Random();
            
            for (int i = 0; i < random.Next(1, 2) * roundNumber; i++)
            {
                Random random2 = new Random();
                int rNum = random2.Next(1, 4);
                Vector2 thePos = new Vector2();

                //left entering asteroid
                Random random3 = new Random();
                if (rNum == 1)
                {
                    thePos = new Vector2(backgroundTexture.Bounds.Left - 100, random3.Next(1, backgroundTexture.Height));
                }
                //right
                else if (rNum == 2)
                {
                    thePos = new Vector2(backgroundTexture.Bounds.Right + 100, random3.Next(1, backgroundTexture.Height));
                }
                //top
                else if (rNum == 3)
                {
                    thePos = new Vector2(random3.Next(1, backgroundTexture.Width), backgroundTexture.Bounds.Top - 100);
                }
                //bottom
                else
                {
                    thePos = new Vector2(random3.Next(1, backgroundTexture.Width), backgroundTexture.Bounds.Bottom + 100);
                }
                Asteroid tempAsteroid = new Asteroid();
                
                tempAsteroid.Initialize(thePos, 3);
                tempAsteroid.LoadContent(Content);
                tempAsteroid.AsteroidVelocity = new Vector2((float)random.NextDouble() * roundNumber, (float)random.NextDouble() * roundNumber);
               
                asteroids.Add(tempAsteroid);
            }

        }

        public void Shoot()
        {
            if (laser1Instance.State == SoundState.Playing)
            {
                laser1Instance.Stop();
                laser1Instance.Play();
            }
            else
            {
                laser1Instance.Play();
            }
            MouseState curMouse = Mouse.GetState();
            Vector2 mouseLoc = new Vector2(curMouse.X + camera.centre.X, curMouse.Y + camera.centre.Y);
            Bullet newBullet = new Bullet(Content.Load<Texture2D>("bullet2"));
            newBullet.BulletEnd = new Vector2(cursorPos.X + customCursor.Width / 2, cursorPos.Y + customCursor.Height / 2);
            newBullet.BulletPos = ship.ShipPos;
            newBullet.IsVisible = true;
            newBullet.BulletRotation = ship.ShipRotation;

            if (bullets.Count < 20)
            {
                bullets.Add(newBullet);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            

            switch (currentScreen)
            {
                case 1:
                    titleScreen.Draw(spriteBatch);
                    break;
                case 2:

                    int miniModX = 640;
                    int miniSpriteModX = 565;
                    int miniSpriteModY = 90;

                    //strings
                    string roundString = "ROUND: " + roundNumber.ToString();
                    string scoreString = "SCORE   " + score.ToString();
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);

                    spriteBatch.Draw(backgroundTexture, backPos, Color.White);
                    earth.Draw(spriteBatch);
                    ship.Draw(spriteBatch);
                    
                    foreach (Asteroid a in asteroids)
                    {
                        a.Draw(spriteBatch);
                    }

                    //draw bullets
                    foreach (Bullet b in bullets)
                    {
                        b.Draw(spriteBatch);
                    }

                    if (crosshairOn == true)
                    {
                        cursorPos.Y -= customCursor.Height / 2;
                        cursorPos.X -= customCursor.Width / 2;
                        spriteBatch.Draw(customCursor, cursorPos, Color.White);
                    }

                    if (hudsVisible != 0)
                    {
                       

                        if (hudsVisible == 1 || hudsVisible == 2)
                        {
                            spriteBatch.Draw(tophud, new Vector2((camera.centre.X + miniModX) - tophud.Width / 2, camera.centre.Y), Color.White * 0.75f);
                            spriteBatch.Draw(miniEarth, new Vector2((camera.centre.X + miniSpriteModX + earth.EarthPos.X / 40), (camera.centre.Y + miniSpriteModY + earth.EarthPos.Y / 40)), Color.White * 0.75f);
                            spriteBatch.Draw(greenDot, new Vector2((camera.centre.X + miniSpriteModX + ship.ShipPos.X / 40), (camera.centre.Y + miniSpriteModY + ship.ShipPos.Y / 40)), Color.White * 0.75f);
                           
                            foreach (Asteroid a in asteroids)
                            {
                                spriteBatch.Draw(redDot, new Vector2((camera.centre.X + miniSpriteModX + a.AsteroidPos.X / 40), (camera.centre.Y + miniSpriteModY + a.AsteroidPos.Y / 40)), Color.White * 0.75f);
                            }

                            //game strings
                            spriteBatch.DrawString(font, scoreString, new Vector2(camera.centre.X + 610, camera.centre.Y + 20), Color.White * 0.75f);
                            spriteBatch.DrawString(font, roundString, new Vector2(camera.centre.X + 490, camera.centre.Y + 20), Color.White * 0.75f);
                        }
                        if (hudsVisible == 2)
                        {
                            int powerModX = 86;
                            int powerModY = 634;
                            spriteBatch.Draw(power, new Rectangle((int)camera.centre.X + powerModX, (int)camera.centre.Y + powerModY, (int)forcePowerWidth, (int)forcePowerHeight), Color.White);
                            spriteBatch.Draw(bottomhud, new Vector2((camera.centre.X + miniModX) - tophud.Width / 2, camera.centre.Y), Color.White * 0.75f);
                            int x = 50;
                            for (int i = 0; i < lives; i++)
                            {
                                spriteBatch.Draw(shipLives, new Vector2((camera.centre.X + 50) + x, (camera.centre.Y + 682)), Color.White * 0.75f);
                                x += 30;
                            }
                        }
                    }

                    if (isPaused == true)
                    { 
                        int modX = 400;
                        int modY = 200;
                        spriteBatch.Draw(pauseTexture, new Vector2((camera.centre.X + modX), (camera.centre.Y + modY)), Color.White);
                    }

                    spriteBatch.End();
                    break;
                case 3:
                    aboutScreen.Draw(spriteBatch);
                    break;
                case 5:
                    gameoverScreen.Draw(spriteBatch);
                    break;
                case 6:
                    break;
                case 7:
                    controlScreen.Draw(spriteBatch);
                    break;
                    
            }

            base.Draw(gameTime);
        }

        public static Texture2D Crop(Texture2D image, Rectangle source)
        {
            Texture2D croppedImage = new Texture2D(image.GraphicsDevice, source.Width, source.Height);
            Color[] imageData = new Color[image.Width * image.Height];
            Color[] cropData = new Color[source.Width * source.Height];

            image.GetData<Color>(imageData);
            int index = 0;

            for (int y = source.Y; y < source.Y + source.Height; y++)
            {
                for (int x = source.X; x < source.X + source.Width; x++)
                {
                    cropData[index] = imageData[y * image.Width + x];
                    index++;
                }
            }

            croppedImage.SetData<Color>(cropData);
            return croppedImage;
        }

        private bool PixelCollision(Rectangle rect1, Texture2D sprite1, Matrix transformA, Rectangle rect2, Texture2D sprite2, Matrix transformB)
        {
            try
            {
                int widthA = sprite1.Width;
                int heightA = sprite1.Height;
                int widthB = sprite2.Width;
                int heightB = sprite2.Height;
                Color[] dataA = new Color[sprite1.Width * sprite1.Height];
                Color[] dataB = new Color[sprite2.Width * sprite2.Height];
                sprite1.GetData<Color>(dataA);
                sprite2.GetData<Color>(dataB);

                Matrix transformAToB = transformA * Matrix.Invert(transformB);

                // For each row of pixels in A
                for (int yA = 0; yA < heightA; yA++)
                {
                    // For each pixel in this row
                    for (int xA = 0; xA < widthA; xA++)
                    {
                        // Calculate this pixel's location in B
                        Vector2 positionInB =
                            Vector2.Transform(new Vector2(xA, yA), transformAToB);

                        // Round to the nearest pixel
                        int xB = (int)Math.Round(positionInB.X);
                        int yB = (int)Math.Round(positionInB.Y);

                        // If the pixel lies within the bounds of B
                        if (0 <= xB && xB < widthB &&
                            0 <= yB && yB < heightB)
                        {
                            // Get the colors of the overlapping pixels
                            Color colorA = dataA[xA + yA * widthA];
                            Color colorB = dataB[xB + yB * widthB];

                            // If both pixels are not completely transparent,
                            if (colorA.A != 0 && colorB.A != 0)
                            {
                                // then an intersection has been found
                                return true;
                            }
                        }
                    }
                }

                // No intersection found
                return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Destructor

        ~Game1()
        {

        }

        #endregion
    }
}
