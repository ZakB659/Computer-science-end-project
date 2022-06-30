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
        private int shootingspeed;
        private double timetowait;
        public double Timewaited;

        public Vector2 _Movement { get => Movement; set => Movement = value; }
        public direction _Direction { get => Direction; set => Direction = value; }
        public int Shootingspeed { get => shootingspeed; set => shootingspeed = value; }
        public double Timetowait { get => timetowait; set => timetowait = value; }

        public Player()
        {
            windowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            windowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Direction = direction.None;
            _Location = new Vector2(windowWidth / 2, windowHeight / 2);
            _MovementSpeed = 2;
            Health = 10;
            Timetowait = 30;
            Timewaited = 30;
            shootingspeed = 1;
            movingroom = false;
        }

        public void Update(GameTime time, Projectiles projectiles, ContentManager content, Player Theplayer)
        {
            KeyboardState ks = Keyboard.GetState();
            inputs = ks.GetPressedKeys();
            MouseState mouseState = Mouse.GetState();

            if (movingroom == true)
            {
                MoveroomAnimation();
            }
            else
            {
                if (ks.IsKeyDown(Keys.W))
                {
                    Movement.Y = _MovementSpeed * (Movement.Y - 1);
                    _Direction = direction.North;
                    movinganimationX = 3;
                }
                if (ks.IsKeyDown(Keys.A))
                {
                    Movement.X = _MovementSpeed * (Movement.X - 1);
                    _Direction = direction.West;
                    movinganimationX = 1;
                }
                if (ks.IsKeyDown(Keys.D))
                {
                    Movement.X = _MovementSpeed * (Movement.X + 1);
                    _Direction = direction.East;
                    movinganimationX = 2;
                }
                if (ks.IsKeyDown(Keys.S))
                {
                    _Direction = direction.South;
                    Movement.Y = _MovementSpeed * (Movement.Y + 1);
                    movinganimationX = 0;
                }
               
                
                if (ks.IsKeyDown(Keys.D)&&ks.IsKeyDown(Keys.A)) { Movement.X = 0;  movinganimationX = 0; _Direction = direction.None; }
                if (ks.IsKeyDown(Keys.W) && ks.IsKeyDown(Keys.S)) { Movement.Y = 0;  movinganimationX = 0; _Direction = direction.None; }

                if (ks.IsKeyDown(Keys.Space))
                {
                    Timewaited++;

                    if (Timewaited > Timetowait / shootingspeed)
                    {
                        bool stationary = false;
                        if (Movement == new Vector2(0,0))
                        {
                            stationary = true;
                        }

                        projectiles.addprojectiles(content, Theplayer,_Movement,stationary);

                        Timewaited = 0;
                    }
                }


                _Location = _Location + Movement;


                if (Math.Abs(windowWidth / 2 - _Location.X) < 150 && Math.Abs(0 - _Location.Y) < 30)
                {
                    MoveroomAnimation();
                }

                if (Math.Abs(windowWidth / 2 - _Location.X) < 100 && Math.Abs(windowHeight - _Location.Y) < 10)
                {

                    MoveroomAnimation();
                }

                if (Math.Abs(0 - _Location.X) < 30 && Math.Abs(windowHeight / 2 - _Location.Y) < 150)
                {
                    MoveroomAnimation();
                }

                if (Math.Abs(windowWidth - _Location.X) < 30 && Math.Abs(windowHeight / 2 - _Location.Y) < 150)
                {
                    MoveroomAnimation();
                }


                Movement.X = 0;
                Movement.Y = 0;
            }
        }

        public void MoveroomAnimation()
        {
            switch (Direction)
            {
                case direction.North:
                    Movement.Y = _MovementSpeed * (Movement.Y - 1);
                    _Location = _Location + Movement;
                    if (Math.Abs(windowWidth / 2 - _Location.X) < 150 && Math.Abs(0 - _Location.Y) < 10)
                    {
                        Roomchange.Y = windowHeight;
                        _Location = _Location + Roomchange;
                    }
                    movingroom = true;
                    break;
                case direction.West:
                    Movement.X = _MovementSpeed * (Movement.X - 1);
                    _Location = _Location + Movement;
                    if (Math.Abs(0 - _Location.X) < 10 && Math.Abs(windowHeight / 2 - _Location.Y) < 100)
                    {
                        Roomchange.X = windowWidth;
                        _Location = _Location + Roomchange;
                    }
                    movingroom = true;
                    break;
                case direction.South:
                    Movement.Y = _MovementSpeed * (Movement.Y + 1);
                    _Location = _Location + Movement;
                    if (Math.Abs(windowWidth / 2 - _Location.X) < 150 && Math.Abs(windowHeight - _Location.Y) < 10)
                    {
                        Roomchange.Y = -windowHeight;
                        _Location = _Location + Roomchange;
                    }
                    movingroom = true;
                    break;
                case direction.East:
                    Movement.X = _MovementSpeed * (Movement.X + 1);
                    _Location = _Location + Movement;
                    if (Math.Abs(windowWidth - _Location.X) < 10 && Math.Abs(windowHeight / 2 - _Location.Y) < 100)
                    {
                        Roomchange.X = -windowWidth;
                        _Location = _Location + Roomchange;
                    }
                    movingroom = true;
                    break;
            }
            Movement.X = 0;
            Movement.Y = 0;

            if ((Math.Abs(windowWidth / 2 - _Location.X) < windowWidth / 5 && Math.Abs(0 - _Location.Y) < windowHeight / 10) || (Math.Abs(0 - _Location.X) < windowWidth / 10 && Math.Abs(windowHeight / 2 - _Location.Y) < windowHeight / 7) || (Math.Abs(windowWidth / 2 - _Location.X) < windowWidth / 6 && Math.Abs(windowHeight - _Location.Y) < windowHeight / 10) || (Math.Abs(windowWidth - _Location.X) < windowWidth / 6 && Math.Abs(windowHeight / 2 - _Location.Y) < windowHeight / 5))
            {
                movingroom = false;
            }
        }

        public override void loadcontent(ContentManager content, string name)
        {
            _Texture = content.Load<Texture2D>(@name);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_Texture, _Location, new Rectangle(32 * movinganimationX, 32 * movinganimationY, 32, 32), Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
        }


    }
}
