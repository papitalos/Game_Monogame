using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Managers
{
    public static class CollisionsManager
    {
        public static Texture2D _rectangleTexture;
        public static Vector2 _position;
        public static bool ShowRectangle { get; set; }

        public static void Update(Vector2 position)
        {
            _position = position;
        }
        public static void Draw()
        {
            if (ShowRectangle)
            {
                if(_rectangleTexture != null) 
                {
                    Globals.SpriteBatch.Draw(_rectangleTexture, _position, Color.Green);

                }
            }
        }

    }
}
