using Microsoft.Xna.Framework;
using ProjetoJogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Managers
{
    public class AnimationManager
    {
        private readonly Dictionary<object, Animation> _anims = new Dictionary<object, Animation>(); // Dicionário para armazenar animações com suas respectivas teclas
        private object _lastKey; // Última tecla usada

        public void AddAnimation(object key, Animation animation)
        {
            _anims.Add(key, animation); // Adiciona a animação ao dicionário, associando-a à sua tecla
            _lastKey ??= key; // Se _lastKey for nulo, atribui a tecla atual
        }

        public void Update(object key)
        {
            if (_anims.TryGetValue(key, out Animation value))
            {
                value.Start(); // Inicia a animação associada à tecla fornecida
                _anims[key].Update(); // Atualiza a animação associada à tecla fornecida
                _lastKey = key; // Atualiza _lastKey com a tecla fornecida
            }
            else
            {
                _anims[_lastKey].Stop(); // Interrompe a animação associada à última tecla usada
                _anims[_lastKey].Reset(); // Reinicia a animação associada à última tecla usada
            }
        }

        public void Draw(Vector2 position)
        {
            _anims[_lastKey].Draw(position); // Desenha a animação associada à última tecla usada na posição especificada
        }
    }
}
