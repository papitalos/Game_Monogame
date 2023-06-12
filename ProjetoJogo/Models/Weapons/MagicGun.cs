using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using ProjetoJogo.Managers;
using ProjetoJogo.Models.Jogador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace ProjetoJogo.Models.Weapons
{
    public class MagicGun : Weapon
    {
        private static ContentManager contentManager;
        private SoundEffect som;

        public static void Initialize(ContentManager cm)
        {

            contentManager = cm;
        }

        public MagicGun(Texture2D texture, Vector2 position, float rot) : base(texture, position, rot)
        {
            cooldown = 0.1f;
            maxAmmo = 13;
            Ammo = maxAmmo;
            reloadTime = 2f;
        }

        protected override void CreateBullet(Player player)
        {
            BulletData bData = new()
            {
                Position = new Vector2(player.Position.X + 15f, player.Position.Y + 18f),
                Rotation = Rotation,
                Lifespan = 0.8f,
                Speed = 500,
                Damage = 1
            };
            if (som == null & contentManager != null)
            {
                som = contentManager.Load<SoundEffect>("GunSFX");
                som.Play();
            }

            BulletManager.AddBullet(bData);
        }
    }
}
