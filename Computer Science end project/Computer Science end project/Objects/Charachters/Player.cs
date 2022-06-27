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
    class Player : Charachter
    {
        private int windowWidth;
        private int windowHeight;
        private Vector2 Movement;
        private Vector2 Roomchange;
        private Keys[] inputs = new Keys[100];
        private direction Direction;
        private bool movingroom;
        public int movinganimationX;
        public int movinganimationY;

        public Vector2 Movement1 { get => Movement; set => Movement = value; }
        public direction _Direction { get => Direction; set => Direction = value; }

        public Player()
        {
            windowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            windowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Direction = direction.None;
            _Location = new Vector2(windowWidth/2, windowHeight/2);
            _MovementSpeed = 2;
            Health = 10;
            movingroom = false;
        }

        public void Update(GameTime time, Projectiles projectiles, ContentManager content, Player Theplayer)
        {
            KeyboardState ks = Keyboard.GetState();
            inputs = ks.GetPressedKeys();
            MouseState mouseState = Mouse.GetState();

            if(movingroom == true)
            {
                MoveroomAnimation();
            }
            else
            {
                foreach (Keys key in inputs)
                {
                    if (key == Keys.Space)
                    {
                        Projectile newprojectile = new Projectile();
                        newprojectile.loadcontent(content, "Fireball");
                        newprojectile.setdirection(Theplayer);
                        projectiles.addprojectiles(newprojectile);
                    }
                    if (key == Keys.W)
                    {
                        Movement.X = Movement.X + 0;
                        Movement.Y = _MovementSpeed * (Movement.Y - 1);
                        _Direction = direction.North;
                        movinganimationY = 1;
                        movinganimationX = 0;
                    }
                    if (key == Keys.A)
                    {
                        Movement.X = _MovementSpeed * (Movement.X - 1);
                        Movement.Y = Movement.Y + 0;
                        _Direction = direction.West;
                        movinganimationY = 0;
                        movinganimationX = 1;
                    }
                    if (key == Keys.D)
                    {
                        Movement.X = _MovementSpeed * (Movement.X + 1);
                        Movement.Y = Movement.Y + 0;
                        _Direction = direction.East;
                        movinganimationY = 0;
                        movinganimationX = 2;
                    }
                    if (key == Keys.S)
                    {
                        _Direction = direction.South;
                        Movement.X = Movement.X + 0;
                        Movement.Y = _MovementSpeed * (Movement.Y + 1);
                        movinganimationY = 0;
                        movinganimationX = 0;
                    }

                    Roomchange.Y = 0;
                    Roomchange.X = 0;

                    _Location = _Location + Movement;
                    Movement.X = 0;
                    Movement.Y = 0;

                    if (Math.Abs(windowWidth/2 - _Location.X) < 150 && Math.Abs(0 - _Location.Y) < 30)
                    {
                        MoveroomAnimation();
                    }

                    if (Math.Abs(windowWidth/2 - _Location.X) < 100 && Math.Abs(windowHeight - _Location.Y) < 10)
                    {
                        
                        MoveroomAnimation();
                    }

                    if (Math.Abs(0 - _Location.X) < 30 && Math.Abs(windowHeight/2 - _Location.Y) < 150)
                    {
                        MoveroomAnimation();
                    }

                    if (Math.Abs(windowWidth - _Location.X) < 30 && Math.Abs(windowHeight/2 - _Location.Y) < 150)
                    {
                        MoveroomAnimation();
                    }

                }
            }           
        }

        public void MoveroomAnimation()
        {
            switch (Direction)
            {
                case direction.North:                   
                    Movement.Y = _MovementSpeed * (Movement.Y - 1);
                    _Location = _Location + Movement;
                    if (Math.Abs(windowWidth/2 - _Location.X) < 150 && Math.Abs(0 - _Location.Y) < 10)
                    {
                        Roomchange.Y = windowHeight;
                        _Location = _Location + Roomchange;
                    }
                    movingroom = true;
                    break;
                case direction.West:
                    Movement.X = _MovementSpeed * (Movement.X - 1);                   
                    _Location = _Location + Movement;
                    if (Math.Abs(0 - _Location.X) < 10 && Math.Abs(windowHeight/2 - _Location.Y) < 100)
                    {
                        Roomchange.X= windowWidth;
                        _Location = _Location + Roomchange;
                    }
                    movingroom = true;
                    break;
                case direction.South:                   
                    Movement.Y = _MovementSpeed * (Movement.Y + 1);
                    _Location = _Location + Movement;
                    if (Math.Abs(windowWidth/2 - _Location.X) < 150 && Math.Abs(windowHeight - _Location.Y) < 10)
                    {
                        Roomchange.Y = -windowHeight;
                        _Location = _Location + Roomchange;
                    }
                    movingroom = true;
                    break;
                case direction.East:                    
                    Movement.X = _MovementSpeed * (Movement.X + 1);
                    _Location = _Location + Movement;
                    if (Math.Abs(windowWidth - _Location.X) < 10 && Math.Abs(windowHeight/2 - _Location.Y) < 100)
                    {
                        Roomchange.X = -windowWidth;
                        _Location = _Location + Roomchange;
                    }
                    movingroom = true;
                    break;                   
            }
            Movement.X = 0;
            Movement.Y = 0;

            if ((Math.Abs(windowWidth / 2 - _Location.X) < windowWidth/5 && Math.Abs(0 - _Location.Y) < windowHeight/10) || (Math.Abs(0 - _Location.X) < windowWidth / 10 && Math.Abs(windowHeight / 2 - _Location.Y) < windowHeight/7) || (Math.Abs(windowWidth / 2 - _Location.X) < windowWidth/6 && Math.Abs(windowHeight - _Location.Y) < windowHeight/10) || (Math.Abs(windowWidth - _Location.X) < windowWidth/6 && Math.Abs(windowHeight / 2 - _Location.Y) < windowHeight / 5))
            {
                movingroom = false;
            }
        }

        public override void loadcontent(ContentManager content,string name)
        {
            _Texture = content.Load<Texture2D>(@name);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {            
            spriteBatch.Draw(_Texture, _Location,new Rectangle(32*movinganimationX,32*movinganimationY,32,32), Color.White,0,new Vector2(0,0),2,SpriteEffects.None,0);
        }       


    }
}
