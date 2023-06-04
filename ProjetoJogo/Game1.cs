using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjetoJogo.Managers;
using ProjetoJogo.Models;

namespace ProjetoJogo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;
        public Texture2D backgroundTexture;
        private GameState gameState;
        private Menu menu;
        private SpriteFont font;
        private Vector2 backgroundPosition = Vector2.Zero;
        private Vector2 backgroundScale = new Vector2(0.9f); // Ajuste a escala desejada aqui

        public enum GameState
        {
            Menu,
            Playing,
            Quitting
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            Globals.GraphicsDeviceManager = _graphics;

            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;

            Globals.ScreenHeight = _graphics.PreferredBackBufferHeight;
            Globals.ScreenWidth = _graphics.PreferredBackBufferWidth;

            _graphics.ApplyChanges();
           
            Globals.Content = Content;

            _gameManager = new();
            _gameManager.Init();

          

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTexture = Content.Load<Texture2D>("mushroom");
            font = Content.Load<SpriteFont>("default");
            // TODO: use this.Content to load your game content here

            // Ajuste a escala da imagem de fundo
            backgroundTexture = ScaleTexture(backgroundTexture, backgroundScale);

            gameState = GameState.Menu;
            menu = new Menu();
            Globals.SpriteBatch = _spriteBatch;
        }

        private Texture2D ScaleTexture(Texture2D source, Vector2 scale)
        {
            int newWidth = (int)(source.Width * scale.X);
            int newHeight = (int)(source.Height * 0.6);

            RenderTarget2D result = new RenderTarget2D(GraphicsDevice, newWidth, newHeight);
            GraphicsDevice.SetRenderTarget(result);
            GraphicsDevice.Clear(Color.Transparent);

            _spriteBatch.Begin();
            _spriteBatch.Draw(source, new Rectangle(0, 0, newWidth, newHeight), Color.White);
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);

            return result as Texture2D;
        }

        protected override void Update(GameTime gameTime)
        {

            switch (gameState)
            {
                case GameState.Menu:
                    menu.Update(gameState);
                    break;

                case GameState.Playing:
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                        Exit();

                    // TODO: Add your update logic here

                    Globals.Update(gameTime);

                    _gameManager.Update();
                    break;

                case GameState.Quitting:
                    Exit();
                    break;
            }

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            switch (gameState)
            {
                case GameState.Menu:
                    menu.Draw(_spriteBatch, font, backgroundTexture, backgroundPosition, backgroundScale);
                    break;

                case GameState.Playing:
                    GraphicsDevice.Clear(Color.Lerp(Color.MediumPurple, Color.Black, 0.75f));

                    // TODO: Add your drawing code here
                    _spriteBatch.Begin(transformMatrix: _gameManager.camera.Transform);
                    _gameManager.Draw();
                    _spriteBatch.End();
                    break;
            }

            

            base.Draw(gameTime);
        }
    }
}