using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Managers;
using ProjetoJogo.Models.Rastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models
{
    public class Player : Sprite
    {
        private readonly Trail _trail;
        public Texture2D _texture;
        public Vector2 _position;
        public Vector2 _trailPosition = new (100, 100);
        private readonly float _speed = 180f;


        private readonly AnimationManager anim = new();


        public Player(Texture2D _tex, Vector2 _pos) : base(_tex, _pos)
        {

            _position = _pos;
            _texture = _tex;

            //Carregar texturas
            var playerWalkTexture = Globals.Content.Load<Texture2D>("player_walk");
            var playerIdleTexture = Globals.Content.Load<Texture2D>("player_idle");

            //Animações
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


             //Trail do Player
            _trail = new(Globals.Content.Load<Texture2D>("trail"), _trailPosition);
        }


        private void Walk()
        {
            if (InputManager.Moving)
            {
                _position += Vector2.Normalize(InputManager.Direction) * _speed * Globals.Time;
                _trailPosition = new Vector2(_position.X + 16, _position.Y + 17);
            }
            
        }

        public void Update()
        {
            
            Walk();
            anim.Update(InputManager.Direction);

            _trail.Update(_trailPosition);
        }

        public void Draw()
        {
            _trail.Draw();
            anim.Draw(_position);

            
        }
    }
}
