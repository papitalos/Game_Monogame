using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Managers
{
    public static class InputManager
    {
        private static Vector2 _direction; // Vetor que representa a direção de entrada
        public static Vector2 Direction => _direction; // Propriedade para acessar a direção de entrada

        public static bool Moving => _direction != Vector2.Zero; // Propriedade para verificar se há movimento




        public static void Update()
        {

            _direction = Vector2.Zero; // Reinicia a direção de entrada
            var keyboardState = Keyboard.GetState(); // Obtém o estado atual do teclado

            if (keyboardState.GetPressedKeyCount() > 0) // Verifica se alguma tecla está pressionada
            {
                if (keyboardState.IsKeyDown(Keys.A)) _direction.X--; // Define a direção para esquerda
                if (keyboardState.IsKeyDown(Keys.D)) _direction.X++; // Define a direção para direita
                if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
                if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
            }
        }
    }
}
