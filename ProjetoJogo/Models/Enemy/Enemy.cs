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

namespace ProjetoJogo.Models.Enemy
{
    public class Enemy : AnimatedSprite
    {
        public int HP { get; private set; }
        public int Speed { get; private set; }
        private Vector2 _direction;

        int frameX, frameY;
        public Enemy(Texture2D tex, Vector2 pos) : base(tex, pos, 0)
        {
            Speed = 100;
            HP = 2;

            //Tamanho do Spritesheet
            frameX = 4; 
            frameY = 5;

            //Animations
            //Walk
            _anims.AddAnimation(Globals.back, new(tex, frameX, frameY, 0.07f, 2));
            _anims.AddAnimation(Globals.foward, new(tex, frameX, frameY, 0.07f, 3));
            _anims.AddAnimation(Globals.down, new(tex, frameX, frameY, 0.07f, 4));
            _anims.AddAnimation(Globals.back_down, new(tex, frameX, frameY, 0.07f, 4));
            _anims.AddAnimation(Globals.foward_down, new(tex, frameX, frameY, 0.07f, 4));
            _anims.AddAnimation(Globals.up, new(tex, frameX, frameY, 0.07f, 5));
            _anims.AddAnimation(Globals.back_up, new(tex, frameX, frameY, 0.07f, 5));
            _anims.AddAnimation(Globals.foward_up, new(tex, frameX, frameY, 0.07f, 5));
            //Idle
            _anims.AddAnimation(Globals.stoped, new(tex, frameX, frameY, 0.3f, 1)); 
        }   

        public void TakeDamage(int dmg)
        {
            HP -= dmg;
        }

        public void Update(Player player)
        {
            UpdateInfo();

            _direction = Vector2.Zero; // Reinicia a direção de entrada


            var toPlayer = player.Position - Position;

            //Verifica a direção que o inimigo esta andando
            if (toPlayer.X > 0) _direction.X++;
            if (toPlayer.X < 0) _direction.X--;
            if (toPlayer.Y > 0) _direction.Y++;
            if (toPlayer.Y < 0) _direction.Y--;

            Rotation = (float)Math.Atan2(toPlayer.Y, toPlayer.X);


            _anims.Update(_direction);
            if (toPlayer.Length() > 4)
            {
                var dir = Vector2.Normalize(toPlayer);
                Position += dir * Speed * Globals.Time;
            }
        }

        public new void Draw()
        {
            _anims.Draw(Position);
            //DEBUG
            if (InputManager.KeyboardF1 && !ShowRectangle)
            {
                if (_RectangleTexture != null)
                    Globals.SpriteBatchUM.Draw(_RectangleTexture, _Rectangle, Color.Red);
            }
        }

    }
}
