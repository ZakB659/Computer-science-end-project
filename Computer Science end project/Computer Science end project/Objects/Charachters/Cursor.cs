using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.IO;

namespace Computer_Science_end_project
{
    class Cursor : Charachter
    {
        private int windowWidth;
        private int windowHeight;
        private Vector2 mouseMoves;

        public int WindowWidth { get => windowWidth; set => windowWidth = value; }
        public int WindowHeight { get => windowHeight; set => windowHeight = value; }

        public Cursor()
        {
            windowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            windowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _Location = new Vector2(windowWidth/ 2, windowHeight / 2);
            _Size = 20;
        }

        public override void loadcontent(ContentManager content, string name)
        {
            _Texture = content.Load<Texture2D>(@"Mushroom Cursor");
        }

        public void update(GameTime gameTime,ref Game1.GameState gameState)
        {
            MouseState MS = Mouse.GetState();

            mouseMoves.X = MS.X;
            mouseMoves.Y = MS.Y;

            _Location =  mouseMoves;

            if(MS.LeftButton == ButtonState.Pressed)
            {
                if(Math.Abs(windowWidth / 2 - _Location.X) <100 && Math.Abs(3 * WindowHeight / 8 - _Location.Y) < 50)
                {
                    gameState = Game1.GameState.Game;
                }
                    
            }
        }

        public void Draw(SpriteBatch spriteBatch,SpriteFont GameFont)
        {       

            MouseState MS = Mouse.GetState();

            mouseMoves.X = MS.X;
            mouseMoves.Y = MS.Y;

            

            if (Math.Abs((windowWidth/2) - mouseMoves.X) < 100 && Math.Abs(3 * WindowHeight / 8 - mouseMoves.Y) < 50)
            {
                spriteBatch.DrawString(GameFont, "Play", new Vector2(windowWidth / 2 - (windowWidth / 250), 3*WindowHeight /8), Color.Yellow,0,new Vector2(0,0),(float)1.2,SpriteEffects.None,0);
                spriteBatch.DrawString(GameFont, "LeaderBoards", new Vector2(7 * windowWidth / 15, 5*(WindowHeight / 8)), Color.Red);
            }
            else
            {
                if (Math.Abs(7 * windowWidth / 15 - mouseMoves.X) < 150 && Math.Abs(5 * (WindowHeight / 8) - mouseMoves.Y) < 50)
                {
                    spriteBatch.DrawString(GameFont, "Play", new Vector2(windowWidth / 2, 3*WindowHeight / 8), Color.Red);
                    spriteBatch.DrawString(GameFont, "LeaderBoards", new Vector2( 7*windowWidth / 15-(windowWidth/100), 5 * (WindowHeight / 8)), Color.Yellow, 0, new Vector2(0, 0), (float)1.2, SpriteEffects.None, 0);
                }
                else
                {
                    spriteBatch.DrawString(GameFont, "Play", new Vector2(windowWidth / 2, 3 * WindowHeight / 8), Color.Red);
                    spriteBatch.DrawString(GameFont, "LeaderBoards", new Vector2(7 * windowWidth / 15, 5 * (WindowHeight / 8)), Color.Red);
                }
                
            }

            spriteBatch.Draw(_Texture, _Location, new Rectangle(0, 0, 100, 100), Color.White, 0, new Vector2(0, 0), 5, SpriteEffects.None, 0);
        }
    }
}
