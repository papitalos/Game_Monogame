using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjetoJogo.Managers;
using ProjetoJogo.Models;

namespace ProjetoJogo
{
    public class Game1 : Game
    {
        public static Game1 Instance { get; private set; }
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatchUM;
        public SpriteBatch _spriteBatchDOIS;
        private GameManager _gameManager;
   

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Instance = this;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

           

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

            _spriteBatchUM = new SpriteBatch(GraphicsDevice);
            _spriteBatchDOIS = new SpriteBatch(GraphicsDevice);

            Globals.SpriteBatchUM = _spriteBatchUM;
            Globals.SpriteBatchDOIS = _spriteBatchDOIS;
        }

      

        protected override void Update(GameTime gameTime)
        {

         
             if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            // TODO: Add your update logic here

            Globals.Update(gameTime);

            _gameManager.Update();
                    

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
      
            GraphicsDevice.Clear(Color.Lerp(Color.MediumPurple, Color.Black, 0.75f));

            // TODO: Add your drawing code here
            _spriteBatchUM.Begin(transformMatrix: _gameManager.camera.Transform);
            _spriteBatchDOIS.Begin();

            _gameManager.Draw();

            _spriteBatchDOIS.End();
            _spriteBatchUM.End();
                
           

            

            base.Draw(gameTime);
        }

      
    }
}