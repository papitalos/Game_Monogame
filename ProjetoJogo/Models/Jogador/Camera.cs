using Microsoft.Xna.Framework;
using ProjetoJogo.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Jogador
{
    public static class Camera
    {
        public static Matrix Transform { get; private set; }

        public static void Follow(Player target)
        {
            var offset = Matrix.CreateTranslation(Globals.ScreenWidth / 2, Globals.ScreenHeight / 2, 0);

            var position = Matrix.CreateTranslation(-target.Position.X - target._Rectangle.Width / 2, -target.Position.Y - target._Rectangle.Height / 2, 0);

            Transform = position * offset;

        }

       


    }
}
