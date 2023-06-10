using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Models.Base;
using ProjetoJogo.Models.Jogador;
using ProjetoJogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Enemy
{

    public class Enemy : MovingSprite
    {
        public int HP { get; private set; }

        public Enemy(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            Speed = 100;
            HP = 2;
        }
        /*
        public void TakeDamage(int dmg)
        {
            HP -= dmg;
            if (HP <= 0) ExperienceManager.AddExperience(Position);
        }*/

        public void Update(Player player)
        {
            var toPlayer = player.Position - Position;
            Rotation = (float)Math.Atan2(toPlayer.Y, toPlayer.X);

            if (toPlayer.Length() > 4)
            {
                var dir = Vector2.Normalize(toPlayer);
                Position += dir * Speed * Globals.Time;
            }
        }
    }
}
/*
namespace ProjetoJogo.Models.Enemy
{
    public class Enemy
    {
        private Texture2D enemyTexture;
        private Vector2 enemyPosition;

        public Enemy(Texture2D texture, Vector2 position)
        {
            enemyTexture = texture;
            enemyPosition = position;
        }

        public void Update()
        {
            // Lógica de atualização do inimigo
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, enemyPosition, Color.White);
        }
    }

}
*/