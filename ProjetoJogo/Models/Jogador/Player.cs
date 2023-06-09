using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjetoJogo.Managers;
using ProjetoJogo.Models.Base;
using ProjetoJogo.Models.Rastro;
using ProjetoJogo.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Jogador
{
    public class Player : AnimatedSprite
    {
        private readonly PlayerData data;
        private readonly Trail trail;
        public Vector2 _trailPosition = new(100, 100);
        public float Speed;


       

        public Player(PlayerData data) : base(data.Texture, data.Position, data.Rotation)
        {
            isRot = false;

            Speed = data.Speed;
            this.data = data;

           
            //Animações
            //Walk
            _anims.AddAnimation(Globals.back, new(data.Texture, 4, 5, 0.07f, 2));
            _anims.AddAnimation(Globals.foward, new(data.Texture, 4, 5, 0.07f, 3));
            
            _anims.AddAnimation(Globals.down, new (data.Texture, 4, 5, 0.07f, 4));
            _anims.AddAnimation(Globals.back_down, new(data.Texture, 4, 5, 0.07f, 4));
            _anims.AddAnimation(Globals.foward_down, new(data.Texture, 4, 5, 0.07f, 4));
            _anims.AddAnimation(Globals.up, new(data.Texture, 4, 5, 0.07f, 5));
            _anims.AddAnimation(Globals.back_up, new(data.Texture, 4, 5, 0.07f, 5));
            _anims.AddAnimation(Globals.foward_up, new(data.Texture, 4, 5, 0.07f, 5));

            //Idle
            _anims.AddAnimation(Globals.stoped, new(data.Texture, 4, 5, 0.4f, 1));
            

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
        private void Walk()
        {
            if (InputManager.Moving)
            {

                Position += Vector2.Normalize(InputManager.Direction) * Speed * Globals.Time;
                _trailPosition = new Vector2(Position.X + 16, Position.Y + 17);
            }

        }

        public void Update()
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

            
        }

        public new void Draw()
        {
            data.Weapon.Draw();
            _anims.Draw(Position);
            trail.Draw();
        }

    }
}
