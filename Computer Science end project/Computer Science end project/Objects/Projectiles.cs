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
    class Projectiles
    {
        List<Projectile> projectiles = new List<Projectile>();

        public Projectiles()
        {

        }

        public List<Projectile> _Projectiles { get => projectiles; set => projectiles = value; }

        public void addprojectiles(Projectile projectile)
        {
            _Projectiles.Add(projectile);
        }

        public void removeprojectiles()
        {

        }
    }
}
