using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Rastro
{
 
    public class TrailStrategyTime : TrailStrategy
    {
        private const float TIME = 0.2f;// Tempo necessário entre adições de partes ao rastro
        private float _time;// Tempo decorrido desde a última adição de parte ao rastro
        private Vector2 _lastPosition;// Última posição em que uma parte foi adicionada ao rastro

        public TrailStrategyTime(Vector2 position)
        {
            _lastPosition = position;// Inicializa a última posição com a posição fornecida
        }

        public override bool Ready(Vector2 position)
        {
            _time -= Globals.Time;// Atualiza o tempo decorrido

            // Verifica se a posição atual é igual à última posição em que uma parte foi adicionada
            if (position == _lastPosition)
                return false;

            // Verifica se o tempo decorrido é menor que 0, indicando que é hora de adicionar uma nova parte ao rastro
            if (_time < 0)
            {
                _time = TIME;// Reinicia o tempo decorrido
                _lastPosition = position;// Atualiza a última posição com a posição atual
                return true;// Retorna true para indicar que o rastro está pronto para adicionar uma nova parte
            }

            return false;
        }
    }
}
