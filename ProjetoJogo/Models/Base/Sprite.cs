using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Base
{
    public class Sprite
    {
        protected Texture2D texture;
        public Vector2 Position { get; protected set; }
        public float Rotation { get; protected set; }
        public float RotationSpeed { get; protected set; }

        public Vector2 Origin;
        protected Color color;
        public bool isAnimated { get; protected set; }
        public bool isRot { get; protected set; }
      
        public readonly AnimationManager _anims = new();

        public Rectangle _Rectangle;
        public Texture2D _RectangleTexture;
        public bool ShowRectangle { get; set; }

        public Sprite(Texture2D texture, Vector2 position, float rotation)
        {
            RotationSpeed = 10f;
            Position = position;
            Rotation = rotation;
            this.texture = texture;
            Origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
            color = Color.White;
          
        }
        public void UpdateInfo()
        {

            UpdateRectangle();
            if(isRot)UpdateRotation(); //so se o objeto tiver q ter a propriedade de rotacionar ao redor da origem
            SetRectangleTexture();
        }

        public void UpdateRectangle()
        {
            Vector2 topLeft = Position - Origin;

            _Rectangle = new((int)topLeft.X, (int)topLeft.Y, texture.Width, texture.Height);
            
        }
        public void UpdateRotation()
        {
            Rotation += (float)(RotationSpeed * Globals.gameTime.ElapsedGameTime.TotalSeconds);

            if ( Rotation < 0 ) {
                Rotation = MathHelper.TwoPi - Math.Abs(Rotation);
            }
            else if (Rotation > MathHelper.TwoPi ) 
            {
                Rotation = Rotation - MathHelper.TwoPi;
            }
        }
        public void SetRectangleTexture()
        {
            var colours = new List<Color>();

            for (int y = 0; y < _Rectangle.Height; y++)
            {
                for (int x = 0; x < _Rectangle.Width; x++)
                {
                    if (y == 0 || // On the top
                        x == 0 || // On the left
                        y == _Rectangle.Height - 1 || // on the bottom
                        x == _Rectangle.Width - 1) // on the right
                    {
                        colours.Add(new Color(255, 255, 255, 255)); // white
                    }
                    else
                    {
                        colours.Add(new Color(0, 0, 0, 0)); // transparent 
                    }
                }
            }
           
            _RectangleTexture = new Texture2D(Game1.Instance.GraphicsDevice, _Rectangle.Width, _Rectangle.Height);
            _RectangleTexture.SetData<Color>(colours.ToArray());
        }
        public virtual void Draw()
        {
            if (!isAnimated)
            {
                Globals.SpriteBatchUM.Draw(texture, Position, null, color, Rotation, Origin, 1f, SpriteEffects.None, 0f);
            }

            //DEBUG
            if (InputManager.KeyboardF1 && !ShowRectangle)
            {
                if (_RectangleTexture != null)
                    Globals.SpriteBatchUM.Draw(_RectangleTexture, _Rectangle, Color.Red);
            }
         
        }


    }
}
