using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Managers;
using ProjetoJogo.Models.Base;
using ProjetoJogo.Models.Jogador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Weapons
{
    public abstract class Weapon : Sprite
    {
        protected float cooldown;
        protected float cooldownLeft;
        protected int maxAmmo;
        public int Ammo { get; protected set; }
        protected float reloadTime;
        public bool Reloading { get; protected set; }

        float _rotation;

        protected Weapon(Texture2D texture, Vector2 position, float rotation) : base (texture, position, rotation)
        {
            _rotation = rotation;
            cooldownLeft = 0f;
            Reloading = false;
        }
        protected abstract void CreateBullet(Player player);

        public virtual void Reload()
        {
            if (Reloading || Ammo == maxAmmo) return;
            cooldownLeft = reloadTime;
            Reloading = true;
            Ammo = maxAmmo;

        }
        public virtual void Fire(Player player)
        {
            if (cooldownLeft > 0 || Reloading) return;

            Ammo--;
            if (Ammo > 0)
            {
                cooldownLeft = cooldown;
            }
            else
            {
                Reload();
            }

            CreateBullet(player);
        }

        public virtual void Update(Vector2 pos)
        {
            UpdateInfo();

            // Calcular a posição ajustada da arma em relação ao mouse usando a matriz de transformação da câmera
            Matrix inverseTransform = Matrix.Invert(Camera.Transform);
            Vector2 mousePosition = Vector2.Transform(InputManager.MousePosition, inverseTransform);


            Rotation = (float)Math.Atan2(mousePosition.Y - Position.Y, mousePosition.X - Position.X);
            Position = new Vector2(pos.X + 16f, pos.Y +  18f);


            if (cooldownLeft > 0)
            {
                cooldownLeft -= Globals.Time;
            }
            else if (Reloading)
            {
                Reloading = false;
            }
        }

    }
}
