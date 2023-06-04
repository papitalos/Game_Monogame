using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Input;
using static ProjetoJogo.Game1;
using System.Diagnostics;

namespace ProjetoJogo.Managers
{
    public class Menu
    {
        private List<string> options;
        private int selectedOption;
        private const float fontSize = 32f;

        public Menu()
        {
            options = new List<string>
        {
            "Start",
            "Quit"
        };

            selectedOption = 0;
        }

        public void Update(GameState gameState)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                // Seleciona a opção anterior
                selectedOption--;
                if (selectedOption < 0)
                    selectedOption = 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                // Seleciona a próxima opção
                selectedOption++;
                if (selectedOption > 1)
                    selectedOption = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Debug.WriteLine("jogando");
                // Inicia o jogo se a opção "Start" estiver selecionada
                if (selectedOption == 0)
                {
                    gameState = GameState.Playing;
                    Debug.WriteLine("jogando");
                }
                else if (selectedOption == 1)
                    gameState = GameState.Quitting;
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font , Texture2D backgroundTexture, Vector2 backgroundPosition, Vector2 backgroundScale)
        {
            spriteBatch.Begin();

            // Desenha a imagem de fundo
            spriteBatch.Draw(backgroundTexture, backgroundPosition, null, Color.White, 0f, Vector2.Zero, backgroundScale, SpriteEffects.None, 0f);

            // Define a escala da fonte
            float scale = fontSize / font.MeasureString("A").Y;

            // Desenha o texto do menu
            Vector2 titlePosition = new Vector2(100, 100);
            Vector2 startOptionPosition = new Vector2(100, 200);
            Vector2 quitOptionPosition = new Vector2(100, 250);

            // Desenha a opção "Start" com a fonte grande
            if (selectedOption == 0)
                spriteBatch.DrawString(font, "Start", startOptionPosition, Color.Yellow, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            else
                spriteBatch.DrawString(font, "Start", startOptionPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            // Desenha a opção "Quit" com a fonte grande
            if (selectedOption == 1)
                spriteBatch.DrawString(font, "Quit", quitOptionPosition, Color.Yellow, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            else
                spriteBatch.DrawString(font, "Quit", quitOptionPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            spriteBatch.End();
        }
    }

}
