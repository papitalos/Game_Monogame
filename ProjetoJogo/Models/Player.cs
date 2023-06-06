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
    public class Player
    {
        public Texture2D RectangleTexture; // para debug
        public Texture2D _texture;
        public Vector2 _position;

        public int rectangleWidth, rectangleHeight;
        public Rectangle Rectangle { get { return new Rectangle((int)_position.X, (int)_position.Y, rectangleWidth, rectangleHeight); } }

        private readonly Trail trail;
        public Vector2 _trailPosition = new (100, 100);

        private readonly float _speed = 180f;


        private readonly AnimationManager anim = new();


        public Player()
        {
            RectangleTexture = Globals.Content.Load<Texture2D>("square");
            
            //Carregar texturas  de animação (s/idle)
            var playerWalkTexture = Globals.Content.Load<Texture2D>("player_walk");
            var playerIdleTexture = Globals.Content.Load<Texture2D>("player_idle");
            

            rectangleWidth = playerIdleTexture.Width;
            rectangleWidth = playerIdleTexture.Height;

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
            anim.AddAnimation(Globals.stoped, new(playerIdleTexture, 2,1, 0.4f, 1));


             //Trail do Player
            trail = new(Globals.Content.Load<Texture2D>("trail"), _trailPosition);
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
            trail.Update(_trailPosition);


        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(RectangleTexture, _position, Color.Green);
            trail.Draw();
            anim.Draw(_position);

            CollisionsManager.Draw(_texture);
  
        }
    }
}
