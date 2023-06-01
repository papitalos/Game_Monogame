using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Models;
using ProjetoJogo.Models.Rastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Managers
{
    public class GameManager
    {


        private Player player;
        public Camera camera;

   
        public void Init()
        {
           
            camera = new Camera();
            player = new Player(Globals.Content.Load<Texture2D>("player_idle"), Globals.startPoint);



        }

        public void Update()
        {
            //Verifica os inputs
            InputManager.Update();
           
            player.Update();

             //Seta pra camera dar update focando no player
            camera.Follow(player);

        }

        public void Draw()
        {
            
            player.Draw();

        }
    }
}
