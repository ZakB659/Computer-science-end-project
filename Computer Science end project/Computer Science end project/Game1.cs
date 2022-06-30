using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Collections.Generic;

namespace Computer_Science_end_project
{
    public class Game1 : Game
    {
        Enemies Theenemies;
        Player thePlayer;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Background BackgroundInMenu;
        Background ThebackgroundInGame;
        Projectiles TheProjectiles;
        GameState gameState;
        Cursor TheCursor;

        RoomState roomState;
       
        
        SpriteFont GameFont;
        int floor = 10;



        public enum GameState
        {
            Menu,
            Game,
            Gameover,
            Leaderboards,
        }
        public enum RoomState
        {
            Empty,
            Combat,
            Shop,
            Cinematic,
        }


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";           

            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;   // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;   // set this value to the desired height of your window
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            
            roomState = RoomState.Combat;
            gameState = GameState.Menu;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ThebackgroundInGame = new Background();
            BackgroundInMenu = new Background();
            thePlayer = new Player();
            TheProjectiles = new Projectiles();
            TheCursor = new Cursor();
            Theenemies = new Enemies();
            
            base.Initialize();
            
    }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = new SpriteBatch(GraphicsDevice);

            ThebackgroundInGame.LoadContent(Content, "Background");
            thePlayer.loadcontent(Content,"Mushroom Man");
            BackgroundInMenu.LoadContent(Content, "BackgroundForMenu");
            TheCursor.loadcontent(Content,"Mushroom Cursor");

            GameFont = Content.Load<SpriteFont>(@"MyFont");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            thePlayer.Update(gameTime,TheProjectiles, Content, thePlayer);

            TheCursor.update(gameTime, ref gameState);

            foreach(Projectile projectile in TheProjectiles._Projectiles)
            {
                projectile.update(gameTime);
            }

            TheProjectiles._Projectiles = TheProjectiles._Projectiles.Where(x => !x.Isremoved).ToList();
            
            if(roomState == RoomState.Combat)
            {

                Theenemies.addenemy(floor,Content,gameTime);
                
            }

            foreach(Enemy enemy in Theenemies._Enemies)
            {
                enemy.update(gameTime, thePlayer);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            // TODO: Add your drawing code here
            if (gameState == GameState.Menu)
            {
                BackgroundInMenu.Draw(spriteBatch);

                TheCursor.Draw(spriteBatch, GameFont);
            }
            else
            {
                if (gameState == GameState.Game)
                {
                    ThebackgroundInGame.Draw(spriteBatch);
                    
                   foreach(Projectile projectile in TheProjectiles._Projectiles)
                   {
                        projectile.Draw(spriteBatch);
                   }

                    if(roomState == RoomState.Combat)
                    {
                        foreach(Enemy enemy in Theenemies._Enemies)
                        {
                            enemy.Draw(spriteBatch);
                        }
                    }

                    thePlayer.Draw(spriteBatch);
                }
                else
                {

                }
            }



            spriteBatch.End();
        }
    }
}

