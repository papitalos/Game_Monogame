using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Managers;
using ProjetoJogo.Models.Jogador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Base
{
    public class AnimatedSprite : Sprite
    { 

        public AnimatedSprite(Texture2D texture, Vector2 pos, float rotation) : base(texture, pos, rotation)
        {
            isAnimated = true;
            
        }

      

    }
}
