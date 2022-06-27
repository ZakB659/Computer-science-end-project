using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Computer_Science_end_project
{
    class Projectile : Charachter
    {
        private Vector2 ForOutOfPlayer;
        private direction direction;
        private Vector2 movement;
       

        public direction Direction { get => direction; set => direction = value; }
        public Vector2 Movement { get => movement; set => movement = value; }

        public Projectile()
        {
            
        }

        public override void loadcontent(ContentManager content,string name)
        {
            _Texture = content.Load<Texture2D>(@name);
        }

        public void update(GameTime gameTime)
        {
            _Location = _Location + movement;
        }

        public void setdirection(Player player)
        {

            switch (player._Direction)
            {
                case direction.North:
                    ForOutOfPlayer.X = 0;
                    ForOutOfPlayer.Y = -100;
                    movement.X = 0;
                    movement.Y = -3;
                    break;
                case direction.East:
                    ForOutOfPlayer.X = 50;
                    ForOutOfPlayer.Y = 0;
                    movement.X = 3;
                    movement.Y = 0;
                    break;
                case direction.South:
                    ForOutOfPlayer.X = 0;
                    ForOutOfPlayer.Y = 100;
                    movement.X = 0;
                    movement.Y = 3;
                    break;
                case direction.West:
                    ForOutOfPlayer.X = -50;
                    ForOutOfPlayer.Y = 0;
                    movement.X = -3;
                    movement.Y = 0;
                    break;
            }
           
            _Location = player._Location + ForOutOfPlayer;
            
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            if((_Location.X < 1920 || _Location.X > 0) && (_Location.Y < 1080 || _Location.Y > 0))
            {
                spriteBatch.Draw(_Texture, _Location, new Rectangle(0, 0, 100, 100), Color.White,0,new Vector2(0,0),3,SpriteEffects.None,0);
            }
            
        }


    }
}
