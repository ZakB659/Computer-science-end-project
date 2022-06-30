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
    class Projectiles
    {
        List<Projectile> projectiles = new List<Projectile>();

        public Projectiles()
        {

        }

        public List<Projectile> _Projectiles { get => projectiles; set => projectiles = value; }

        public void addprojectiles(ContentManager content, Player Theplayer, Vector2 Movement,bool stationary)
        {
            if(stationary == true)
            {
                Movement = new Vector2(1*Theplayer._MovementSpeed, 0);
            }
            Projectile newprojectile = new Projectile(Theplayer, Movement);
            newprojectile.loadcontent(content, "Fireball");
            _Projectiles.Add(newprojectile);

        }
    }
}
