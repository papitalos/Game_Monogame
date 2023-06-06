using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

   
        public static int selectedOption = 1;
        public static bool keyPressedMenu = false; // verifica se nao pertence a nenhuma das opções


        public static void Update()
        {

            _direction = Vector2.Zero; // Reinicia a direção de entrada
            var keyboardState = Keyboard.GetState(); // Obtém o estado atual do teclado

            if (keyboardState.GetPressedKeyCount() > 0) // Verifica se alguma tecla está pressionada
            {
                if (GameManager.state == GameManager.GameState.Playing)
                {
                    Debug.WriteLine("InputKEYSWALKING");
                    if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
                    if (keyboardState.IsKeyDown(Keys.A)) _direction.X--; 
                    if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
                    if (keyboardState.IsKeyDown(Keys.D)) _direction.X++; 
                    
                }

                if(GameManager.state == GameManager.GameState.Menu)
                {
                    Debug.WriteLine("InputKEYSMENU");
                    if (keyboardState.IsKeyDown(Keys.Enter)) keyPressedMenu = true; // Enter - confirma pra jogar
                    if (keyboardState.IsKeyDown(Keys.Up)) selectedOption = 1; // 1 - playing
                    if (keyboardState.IsKeyDown(Keys.Down)) selectedOption = 2; // 2 - exit 
                }
               
            }
        }
    }
}
