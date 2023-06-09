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
    public static class InputManager { 

        private static MouseState _lastMouseState;
        private static KeyboardState _lastKeyboardState;
    
        private static Vector2 _direction; // Vetor que representa a direção de entrada
        public static Vector2 Direction => _direction; // Propriedade para acessar a direção de entrada
        public static bool Moving => _direction != Vector2.Zero; // Propriedade para verificar se há movimento

   
        public static int selectedOption = 1;
        public static bool keyPressedMenu = false; // verifica se foi clicada alguma tecla no menu

        public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
        public static bool MouseLeftClicked { get; private set; }
        public static bool MouseRightClicked { get; private set; }
        public static bool KeyboardR { get; private set; }
        public static bool KeyboardF1 { get; private set; }
        public static bool KeyboardSpace { get; private set; }



        public static void Update()
        {

            _direction = Vector2.Zero; // Reinicia a direção de entrada
            var keyboardState = Keyboard.GetState(); // Obtém o estado atual do teclado
            var mouseState = Mouse.GetState();// Obtém o estado atual do mouse

            if (keyboardState.GetPressedKeyCount() > 0) // Verifica se alguma tecla está pressionada
            {
                if (GameManager.state == GameManager.GameState.Playing)
                {
                  
                    if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
                    if (keyboardState.IsKeyDown(Keys.A)) _direction.X--; 
                    if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
                    if (keyboardState.IsKeyDown(Keys.D)) _direction.X++;
                    if(_lastKeyboardState.IsKeyUp(Keys.F1) && keyboardState.IsKeyDown(Keys.F1)) KeyboardF1 =! KeyboardF1;

                    if (keyboardState.IsKeyDown(Keys.Escape)) Game1.Instance.Exit();
                }

                if(GameManager.state == GameManager.GameState.Menu)
                {
                   
                    if (keyboardState.IsKeyDown(Keys.Enter)) keyPressedMenu = true; // Enter - confirma pra jogar
                    if (keyboardState.IsKeyDown(Keys.Up)) selectedOption = 1; // 1 - playing
                    if (keyboardState.IsKeyDown(Keys.Down)) selectedOption = 2; // 2 - exit 
                }

            }

            KeyboardR = (_lastKeyboardState.IsKeyUp(Keys.R) && keyboardState.IsKeyDown(Keys.R));
            KeyboardSpace = (_lastKeyboardState.IsKeyUp(Keys.Space) && keyboardState.IsKeyDown(Keys.Space));
            MouseLeftClicked = (mouseState.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released);
            MouseRightClicked = (mouseState.RightButton == ButtonState.Pressed && _lastMouseState.RightButton == ButtonState.Released);
            _lastMouseState = mouseState;
            _lastKeyboardState = keyboardState;
        }
    }
}
