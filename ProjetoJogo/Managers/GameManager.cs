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

        public void Init()
        {
            player = new Player();
         
        }

        public void Update()
        {
            InputManager.Update();
           
            player.Update();
        }

        public void Draw()
        {

           player.Draw();
           
        }
    }
}
