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
            player = new Player();

        }

        public void Update()
        {
            //Verifica os inputs
            InputManager.Update();
            CollisionsManager.Update(player._position);

            player.Update();

             //Seta pra camera dar update focando no player
            camera.FollowPlayer(player);

        }

        public void Draw()
        {
            CollisionsManager.Draw();
            player.Draw();

        }
    }
}
