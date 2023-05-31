using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models
{
    public class Camera
    {
        public Matrix Transform { get; set; }

        public void Follow(Sprite target)
        {
            var offset = Matrix.CreateTranslation(Globals.ScreenWidth / 2, Globals.ScreenHeight / 2, 0);

            var position = Matrix.CreateTranslation(-target.Position.X-(target.Rectangle.Width / 2), -target.Position.Y - (target.Rectangle.Height / 2), 0) * offset; 

            position = position * offset;

        }

        
    }
}
