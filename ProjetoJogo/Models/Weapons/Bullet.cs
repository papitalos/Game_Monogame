using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Managers;
using ProjetoJogo.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Weapons
{
    public class Bullet : MovingSprite
    {
        public Vector2 Direction { get; set; }
        public float Lifespan { get; private set; }
        public int Damage { get;  }

        public Bullet(Texture2D tex, BulletData data) : base(tex, data.Position, data.Rotation)
        {
            Speed = data.Speed;
            Rotation = data.Rotation;

       
            Direction = Direction = new((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));

            Lifespan = data.Lifespan;
            Damage = data.Damage;
        }

        public void Destroy()
        {
            Lifespan = 0;
        }

        public void Update()
        {
            UpdateInfo();
            Position += Direction * Speed * Globals.Time;
            Lifespan -= Globals.Time;
        }
    }
}
