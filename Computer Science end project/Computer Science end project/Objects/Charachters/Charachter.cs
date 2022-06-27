﻿using System;
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
    public enum direction
    {
        None,
        North,
        East,
        South,
        West,

    }

    class Charachter
    {
        private Vector2 Location;
        private Texture2D Texture;
        private int size;
        private int health;
        private int MovementSpeed;

        public Texture2D _Texture { get => Texture; set => Texture = value; }
        public int _Size { get => size; set => size = value; }
        public Vector2 _Location { get => Location; set => Location = value; }
        public int Health { get => health; set => health = value; }
        public int _MovementSpeed { get => MovementSpeed; set => MovementSpeed = value; }

        public virtual void loadcontent(ContentManager content,string name)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
