using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoJogo.Models.Jogador;

namespace ProjetoJogo
{
    public static class Globals
    {
        public static float Time { get; set; }
        public static GameTime gameTime;
        public static ContentManager Content { get; set; }
      
        public static SpriteBatch SpriteBatchUM { get; set; } //player
        public static SpriteBatch SpriteBatchDOIS { get; set; } //resto

        public static int ScreenHeight;
        public static int ScreenWidth;

        public static Point Bounds { get; set; }

        //Inicializa direções usadas no codigo
        public static Vector2 stoped = new Vector2(0, 0); //parado
        public static Vector2 foward = new Vector2(-1, 0); //frente
        public static Vector2 back = new Vector2(1, 0); //tras
        public static Vector2 down = new Vector2(0, 1); //baixo
        public static Vector2 up = new Vector2(0, -1); //baixo
        public static Vector2 foward_up = new Vector2(-1, -1); //frente-cima
        public static Vector2 foward_down = new Vector2(1, 1); //frente-baixo
        public static Vector2 back_down = new Vector2(-1, 1); //tras-baixo
        public static Vector2 back_up = new Vector2(1, -1); //tras-cima   



        // Atualiza o valor da propriedade TotalSeconds com base no tempo decorrido desde o último frame
 
        public static Vector2 GetStartPosition()
        {
            return new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2);
        }
        public static void Update(GameTime gt)
        {
            Time = (float)gt.ElapsedGameTime.TotalSeconds;
            gameTime = gt;
        }
    }
}
