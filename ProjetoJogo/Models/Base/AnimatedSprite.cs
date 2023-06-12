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
    public class AnimatedSprite
    {

        //Data
        protected Texture2D Texture;
        protected Texture2D collision;  

        protected Color color;
        public Vector2 Position { get; protected set; }
        public Vector2 Origin { get; protected set; }
        public float Rotation { get; protected set; }
        public float RotationSpeed { get; protected set; }
        public float Scale { get; set; }

        //Animation manager
        public readonly AnimationManager _anims = new();

        //Rectangle e rotações
        public Rectangle _Rectangle;
        public Texture2D _RectangleTexture;
        public bool ShowRectangle { get; set; }
        public bool isRot { get; protected set; }

        public AnimatedSprite(Texture2D texture, Vector2 pos, float rotation)
        {
            Position = pos;
            Rotation = rotation;
            Texture = texture;
            collision = Globals.Content.Load<Texture2D>("square");
            
        }

        public virtual void Draw()
        {

            _anims.Draw(Position);

            //DEBUG
            if (InputManager.KeyboardF1 && !ShowRectangle)
            {
                if (_RectangleTexture != null)
                    Globals.SpriteBatchUM.Draw(_RectangleTexture, _Rectangle, Color.Red);
            }

        }


        //Update das informações de retangulo e rotação
        public void UpdateInfo()
        {

            UpdateRectangle();
            if (isRot) UpdateRotation(); //so se o objeto tiver q ter a propriedade de rotacionar ao redor da origem
            SetRectangleTexture();
        }
        public void UpdateRectangle()
        {
            Vector2 topLeft = Position - Origin;

            _Rectangle = new((int)topLeft.X, (int)topLeft.Y, collision.Width, collision.Height);

        }
        public void UpdateRotation()
        {
            Rotation += (float)(RotationSpeed * Globals.gameTime.ElapsedGameTime.TotalSeconds);

            if (Rotation < 0)
            {
                Rotation = MathHelper.TwoPi - Math.Abs(Rotation);
            }
            else if (Rotation > MathHelper.TwoPi)
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
    }
}
