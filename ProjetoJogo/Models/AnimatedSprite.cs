using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models
{
    public class AnimatedSprite
    {
        private readonly Texture2D _texture; // Textura que contém os frames da animação
        private readonly List<Rectangle> _sourceRectangles = new(); // Lista de retângulos que representam as regiões dos frames na textura
        private readonly int _frames; // Quantidade total de frames na animação
        private int _frame; // Índice do frame atual
        private readonly float _frameTime; // Tempo de exibição de cada frame
        private float _frameTimeLeft; // Tempo restante para exibir o próximo frame
        private bool _active = true; // Indica se a animação está ativa

        public int frameWidth;
        public int frameHeight;

        public AnimatedSprite(Texture2D texture, int framesX, int framesY, float frameTime, int row = 1)
        {
            _texture = texture;
            _frameTime = frameTime;
            _frameTimeLeft = _frameTime;
            _frames = framesX;

            frameWidth = _texture.Width / framesX;
            frameHeight = _texture.Height / framesY;

            // Calcula os retângulos de origem para cada frame da animação
            for (int i = 0; i < _frames; i++)
            {
                _sourceRectangles.Add(new Rectangle(i * frameWidth, (row - 1) * frameHeight, frameWidth, frameHeight));
            }
        }

        public void Stop()
        {
            _active = false; // Para a animação
        }

        public void Start()
        {
            _active = true; // Inicia a animação
        }

        public void Reset()
        {
            _frame = 0; // Reinicia o índice do frame
            _frameTimeLeft = _frameTime; // Reinicia o tempo restante para exibir o próximo frame
        }

        public void Update()
        {
            if (!_active) return; // Se a animação não estiver ativa, retorna sem fazer nada

            _frameTimeLeft -= Globals.Time; // Reduz o tempo restante

            if (_frameTimeLeft <= 0)
            {
                _frameTimeLeft += _frameTime; // Reinicia o tempo restante com o valor do frameTime
                _frame = (_frame + 1) % _frames; // Avança para o próximo frame, considerando o número total de frames
            }
        }

        public void Draw(Vector2 pos)
        {
            // Desenha o frame atual na posição especificada
            Globals.SpriteBatch.Draw(_texture, pos, _sourceRectangles[_frame], Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
        }
    }
}
