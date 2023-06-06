using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Models;
using ProjetoJogo.Models.Rastro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjetoJogo.Game1;

namespace ProjetoJogo.Managers
{
    public class GameManager
    {

        public Menu menu;
        private Player player;
        public Camera camera;
        public static GameState state;

        public enum GameState
        {
            Menu,
            Playing,
            Quitting
        }

        public void Init()
        {
            //Estado inicial
            state = GameState.Menu;

            menu = new Menu();
            camera = new Camera();
            player = new Player();

        }

        public void Update()
        {
            //Verifica os inputs
            InputManager.Update();
            
            if (state == GameState.Menu)
            {
                menu.Update();
            }
            if (state == GameState.Playing)
            {
                Debug.WriteLine("PlayerUPDATE");
                player.Update();

                //Seta pra camera dar update focando no player
                camera.FollowPlayer(player);
            }

        }

        public void Draw()
        {
            if (state == GameState.Menu)
            {
                menu.Draw();
            }
            if (state == GameState.Playing)
            {
                player.Draw();
            }

        }
    }
}
