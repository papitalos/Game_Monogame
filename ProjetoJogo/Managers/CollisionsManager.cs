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

   

        public static void setRectangleTexture(GraphicsDevice graphics, Texture2D texture)
        {
            var colours = new List<Color>();

            for (int y = 0; y < texture.Height; y++)
            {
                for (int x = 0; x < texture.Width; x++)
                {
                    if (x == 0 || y == 0 || x == texture.Width - 1 || y == texture.Height - 1)
                    {
                        colours.Add(new Color(255, 255, 255, 255));
                    }
                    else
                    {
                        colours.Add(new Color(0, 0, 0, 0));
                    }
                }
            }

            _rectangleTexture = new Texture2D(graphics, texture.Width, texture.Height);
            _rectangleTexture.SetData<Color>(colours.ToArray());

        }

        public static void Draw(Texture2D texture)
        {
            if (ShowRectangle)
            {
                if(_rectangleTexture != null) 
                {
                    setRectangleTexture(Game1.Instance.GraphicsDevice, texture);
                    Globals.SpriteBatch.Draw(_rectangleTexture, _position, Color.Green);

                }
            }
        }

    }
}
