using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models
{
    public class FixedSprite
    {
        protected Texture2D texture;
        public Vector2 Position { get; protected set; }
        private Vector2 _origin;
        protected Color color;
        protected float rotation;

        public FixedSprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            Position = position;
            _origin = new(texture.Width / 2, texture.Height / 2);
            color = Color.White;
        }

        public virtual void Draw()
        {
            Globals.SpriteBatch.Draw(texture, Position, null, color, rotation, _origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
