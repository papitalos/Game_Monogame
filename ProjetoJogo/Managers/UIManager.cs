using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Models.Jogador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Managers
{
    public static class UIManager
    {
        private static Texture2D _bulletTexture;

        public static void Init(Texture2D tex)
        {
            _bulletTexture = tex;
        }

        public static void Draw(PlayerData player)
        {
            Color c = player.Weapon.Reloading ? Color.Red : Color.White;

            for (int i = 0; i < player.Weapon.Ammo; i++)
            {
                Vector2 pos = new(i * _bulletTexture.Width * 1f,0);
                Globals.SpriteBatchDOIS.Draw(_bulletTexture, pos, null, c * 0.75f, 0, Vector2.Zero, 1.2f, SpriteEffects.None, 1);
            }
        }
    }
}
