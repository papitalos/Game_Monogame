using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjetoJogo.Managers;
using ProjetoJogo.Models.Base;
using ProjetoJogo.Models.Inimigos;
using ProjetoJogo.Models.Rastro;
using ProjetoJogo.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoJogo.Models.Jogador
{
    public class Player : AnimatedSprite
    {
        private readonly PlayerData data;
        private readonly Trail trail;
        public Vector2 _trailPosition = new(100, 100);
        public float Speed;

        int frameX, frameY;

        public Player(PlayerData data) : base(data.Texture, data.Position, data.Rotation)
        {
            isRot = false;
            ShowRectangle = true;

            Speed = data.Speed;
            this.data = data;

            //Tamanho do Spritesheet
            frameX = 4;
            frameY = 5;


            //Animations
            //Walk
            _anims.AddAnimation(Globals.back, new(data.Texture, frameX, frameY, 0.07f, 2));
            _anims.AddAnimation(Globals.foward, new(data.Texture, frameX, frameY, 0.07f, 3));
            _anims.AddAnimation(Globals.down, new(data.Texture, frameX, frameY, 0.07f, 4));
            _anims.AddAnimation(Globals.back_down, new(data.Texture, frameX, frameY, 0.07f, 4));
            _anims.AddAnimation(Globals.foward_down, new(data.Texture, frameX, frameY, 0.07f, 4));
            _anims.AddAnimation(Globals.up, new(data.Texture, frameX, frameY, 0.07f, 5));
            _anims.AddAnimation(Globals.back_up, new(data.Texture, frameX, frameY, 0.07f, 5));
            _anims.AddAnimation(Globals.foward_up, new(data.Texture, frameX, frameY, 0.07f, 5));
            //Idle
            _anims.AddAnimation(Globals.stoped, new(data.Texture, frameX, frameY, 0.3f, 1));

            //Trail do Player
            trail = new(Globals.Content.Load<Texture2D>("trail"), _trailPosition);
            
            Reset();
        }

        public void Reset()
        {
            data._weapon1 = new MagicGun(data._weapon1_tex,Origin, 0);
            
            data.Dead = false;
            data.Weapon = data._weapon1;
            data.Position = Globals.GetStartPosition();
           
        }
        public void GetExperience(int exp)
        {
            data.Experience += exp;
        }
        private void Walk()
        {
            if (InputManager.Moving)
            {

                Position += Vector2.Normalize(InputManager.Direction) * Speed * Globals.Time;
                _trailPosition = new Vector2(Position.X + 16, Position.Y + 17);
            }

        }
        private void CheckDeath(List<Enemy> enemys)
        {
            foreach (var z in enemys)
            {
                if (z.HP <= 0) continue;
                if ((Position - z.Position).Length() < 50)
                {
                    data.Dead = true;
                    break;
                }
            }
        }
        public void Update(List<Enemy> enemys)
        {
            UpdateInfo();

            //Movimento e Trail
            Walk();
            _anims.Update(InputManager.Direction);
            trail.Update(_trailPosition);

            //Armas
            data.Weapon.Update(Position);

            if (InputManager.MouseLeftClicked)
            {
                data.Weapon.Fire(this);
            }
            if (InputManager.KeyboardR)
            {
                data.Weapon.Reload();
            }

            
            CheckDeath(enemys);
        }

        public void Show()
        {
            data.Weapon.Draw();
            trail.Draw();
        }

    }
}
