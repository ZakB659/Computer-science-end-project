using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project_end
{
    class Projectile : Charachter
    {
        private int windowWidth;
        private int windowHeight;       
        private direction direction;
        private Vector2 movement;
        private bool isremoved;
        private Keys[] inputs = new Keys[100];


        public direction Direction { get => direction; set => direction = value; }
        public Vector2 Movement { get => movement; set => movement = value; }
        public bool Isremoved { get => isremoved; set => isremoved = value; }

        public Projectile(Player player, Vector2 Movement)
        {
            windowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            windowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _Location = player._Location;
            movement = Movement;
        }

        public override void loadcontent(ContentManager content, string name)
        {
            _Texture = content.Load<Texture2D>(@name);
        }

        public void update(GameTime gameTime)
        {
            _Location = _Location + movement*5;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            if ((_Location.X < windowWidth && _Location.X > 0) && (_Location.Y < windowHeight && _Location.Y > 0))
            {
                spriteBatch.Draw(_Texture, _Location, new Rectangle(0, 0, 100, 100), Color.White, 0, new Vector2(0, 0), 3, SpriteEffects.None, 0);
            }
            else
            {
                Isremoved = true;
            }

        }


    }
}
