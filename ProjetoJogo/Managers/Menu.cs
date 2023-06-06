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
using System.Threading.Tasks.Dataflow;

namespace ProjetoJogo.Managers
{
    public class Menu
    {
        public bool once = false;
        public Texture2D _backgroundTexture;
        Vector2 _backgroundPosition;
        Vector2 _backgroundScale = new Vector2(0.9f, 0.6f);
        SpriteFont font;
        private int selectedOption;
        private const float fontSize = 32f;

        public Menu()
        {
            this._backgroundTexture = Globals.Content.Load<Texture2D>("mushroom");

            _backgroundPosition = new(100, 100);
            font = Globals.Content.Load<SpriteFont>("default");

            selectedOption = 0;
        }

        public void Update()
        {
            if (InputManager.keyPressedMenu)
            {
                switch (InputManager.selectedOption)
                {
              
                    case 1://Jogar
                        GameManager.state = GameManager.GameState.Playing;
                        Debug.WriteLine("Iniciando game");
                                            
                        break;
                    case 2://Sair
                        GameManager.state = GameManager.GameState.Quitting;
                        Debug.WriteLine("Saindo game");
                        Instance.Exit();

                        break;
                }
            }
                
        }
       
        public void Draw()
        {
            if (!once)
            {
                once = true;
                ScaleTexture(_backgroundTexture);
            }
            
            // Define a escala da fonte
            float scale = fontSize / font.MeasureString("A").Y;

            // Desenha o texto do menu
            Vector2 titlePosition = new Vector2(100, 100);
            Vector2 startOptionPosition = new Vector2(100, 200);
            Vector2 quitOptionPosition = new Vector2(100, 250);

            Debug.WriteLine("desenhando MENU");
            // Desenha a opção "Start" com a fonte grande
            if (InputManager.selectedOption == 1)
                Globals.SpriteBatch.DrawString(font, "Start", startOptionPosition, Color.Yellow, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            else
                Globals.SpriteBatch.DrawString(font, "Start", startOptionPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            // Desenha a opção "Quit" com a fonte grande
            if (InputManager.selectedOption == 2)
                Globals.SpriteBatch.DrawString(font, "Quit", quitOptionPosition, Color.Yellow, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            else
                Globals.SpriteBatch.DrawString(font, "Quit", quitOptionPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

        }
        private void ScaleTexture(Texture2D source)
        {

            int newWidth = (int)(source.Width* _backgroundScale.X);
            int newHeight = (int)(source.Height * _backgroundScale.Y);
            

            RenderTarget2D result = new RenderTarget2D(Instance.GraphicsDevice, newWidth, newHeight);
            Instance.GraphicsDevice.SetRenderTarget(result);
            Instance.GraphicsDevice.Clear(Color.Transparent);


            Globals.SpriteBatch.Draw(source, new Rectangle(0, 0, newWidth, newHeight), Color.White);

            Instance.GraphicsDevice.SetRenderTarget(null);
            
           
        }
    }

}
