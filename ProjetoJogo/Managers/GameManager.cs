using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Models.Jogador;
using ProjetoJogo.Models.Rastro;
using ProjetoJogo.Models.UI;
using ProjetoJogo.Models.Weapons;
using ProjetoJogo.Managers;
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
        public PlayerData playerData;
        public Player player;


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


         

            var bullet_tex = Globals.Content.Load<Texture2D>("bullet");
            ExperienceManager.Init(Globals.Content.Load<Texture2D>("exp"));

            BulletManager.Init(bullet_tex);
            UIManager.Init(bullet_tex);

            
            menu = new Menu();
            playerData = new PlayerData();
            player = new Player(playerData);

            EnemyManager.Init();


        }
        public void Restart()
        {
            BulletManager.Reset();
            EnemyManager.Reset();
            ExperienceManager.Reset();
            player.Reset();
        }
        public void Update()
        {
            if (playerData.Dead) Restart();
            //Verifica os inputs
            InputManager.Update();
            
            if (state == GameState.Menu)
            {
                menu.Update();
            }
            if (state == GameState.Playing)
            {
                player.Update(EnemyManager.Enemys);
                Camera.Follow(player);
                ExperienceManager.Update(player,playerData);
                EnemyManager.Update(player);
                BulletManager.Update(EnemyManager.Enemys);
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
                ExperienceManager.Draw();
                BulletManager.Draw();
                player.Show();
                player.Draw();
                EnemyManager.Draw();
                UIManager.Draw(playerData);

            }

        }
    }
}
