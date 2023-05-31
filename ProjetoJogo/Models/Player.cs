using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models
{
    public class Player
    {
        private Vector2 _position = new(100, 100);
        private readonly float _speed = 180f;


        private readonly AnimationManager anim = new();
        

        public Player()
        {
            var playerWalkTexture = Globals.Content.Load<Texture2D>("player_walk");
            var playerIdleTexture = Globals.Content.Load<Texture2D>("player_idle");

            //Walk
            anim.AddAnimation(Globals.back, new(playerWalkTexture, 4, 4, 0.07f, 1));
            anim.AddAnimation(Globals.foward, new(playerWalkTexture, 4, 4, 0.07f, 2));
            anim.AddAnimation(Globals.down, new(playerWalkTexture, 4, 4, 0.07f, 3));
            anim.AddAnimation(Globals.back_down, new(playerWalkTexture, 4, 4, 0.07f, 3));
            anim.AddAnimation(Globals.foward_down, new(playerWalkTexture, 4, 4, 0.07f, 3));
            anim.AddAnimation(Globals.up, new(playerWalkTexture, 4, 4, 0.07f, 4));
            anim.AddAnimation(Globals.back_up, new(playerWalkTexture, 4, 4, 0.07f, 4));
            anim.AddAnimation(Globals.foward_up, new(playerWalkTexture, 4, 4, 0.07f, 4));

            //Idle
            anim.AddAnimation(Globals.stoped, new(playerIdleTexture, 2, 1, 0.4f, 1));
         
        }


        private void Walk()
        {
            if (InputManager.Moving)
            {
                _position += Vector2.Normalize(InputManager.Direction) * _speed * Globals.TotalSeconds;
            }
            
        }

        public void Update()
        {


            Walk();
            anim.Update(InputManager.Direction);
        }

        public void Draw()
        {
            anim.Draw(_position);
        }
    }
}
