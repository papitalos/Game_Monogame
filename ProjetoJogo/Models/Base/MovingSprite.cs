using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Base
{
    public class MovingSprite : Sprite
    {
        public int Speed { get; set; }


        public MovingSprite(Texture2D tex, Vector2 pos, float rot) : base(tex, pos, rot)
        {
            Speed = 300;
            isAnimated = false;
        }
    }
}
