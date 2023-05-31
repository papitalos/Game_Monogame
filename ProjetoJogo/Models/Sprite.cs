using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models
{
    public class Sprite
    {
        protected Texture2D texture;
        public Vector2 Position { get; protected set; }
        private Vector2 _origin;
        protected Color color;
        protected float rotation;
        
        public Rectangle Rectangle {get{ return new Rectangle((int)Position.X,(int)Position.Y, texture.Width, texture.Height);}}


        public Sprite(Texture2D texture, Vector2 position)
        {
            Position = position;
            this.texture = texture;
            _origin = new(texture.Width / 2, texture.Height / 2);
            color = Color.White;
        }

        public virtual void Draw()
        {
            Globals.SpriteBatch.Draw(texture, Position, null, color, rotation, _origin, 1f, SpriteEffects.None, 0f);

        }



    }
}
