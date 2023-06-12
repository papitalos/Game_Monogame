using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Jogador
{
    public sealed class PlayerData
    {
        public Texture2D Texture;
        public Vector2 Position;
        public float Rotation;
        public float Speed;

        public Weapon Weapon; //Arma Atual
        public Weapon _weapon1; //Arma 1
        public Texture2D _weapon1_tex;


        public bool Dead;
        public int Experience;
        public PlayerData()
        {

            var Texture = Globals.Content.Load<Texture2D>("player");
            _weapon1_tex = Globals.Content.Load<Texture2D>("hands");
            
            this.Texture = Texture;
            Rotation = 0;
            Speed = 180f;
            Position = Globals.GetStartPosition();
        }
    }
}
