using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Weapons
{
    public sealed class BulletData
    {
       
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Lifespan { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        
    }
}
