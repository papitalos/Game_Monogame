using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Managers
{
    public static class BulletManager
    {
        private static Texture2D _texture;
        public static List<Bullet> Bullets { get; } = new();
        
        public static void Init(Texture2D tex)
        {
            _texture = tex;
        }

        public static void Reset()
        {
            Bullets.Clear();
        }

        public static void AddBullet(BulletData data)
        {
            Bullets.Add(new(_texture, data));
        }

        public static void Update()
        {
            foreach (var p in Bullets)
            {
                p.Update();
               
            }
            Bullets.RemoveAll((p) => p.Lifespan <= 0);
        }

        public static void Draw()
        {
            foreach (var p in Bullets)
            {
                p.Draw();
            }
        }
    }
}
