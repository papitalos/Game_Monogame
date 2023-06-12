using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Models.Jogador;
using ProjetoJogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ProjetoJogo.Models.Inimigos;

namespace ProjetoJogo.Managers
{

    public static class EnemyManager
    {
        public static List<Enemy> Enemys { get; } = new();
        private static Texture2D _texture;
        private static float _spawnCooldown;
        private static float _spawnTime;
        private static Random _random;
        private static int _padding;

        public static void Init()
        {
            _texture = Globals.Content.Load<Texture2D>("enemy");
            _spawnCooldown = 1.2f;
            _spawnTime = _spawnCooldown;
            _random = new();
            _padding = _texture.Width / 2;
        }

        public static void Reset()
        {
            Enemys.Clear();
            _spawnTime = _spawnCooldown;
        }

        private static Vector2 RandomPosition()
        {
            float w = Globals.Bounds.X;
            float h = Globals.Bounds.Y;
            Vector2 pos = new();

            if (_random.NextDouble() < w / (w + h))
            {
                pos.X = (int)(_random.NextDouble() * w);
                pos.Y = (int)(_random.NextDouble() < 0.5 ? -_padding : h + _padding);
            }
            else
            {
                pos.Y = (int)(_random.NextDouble() * h);
                pos.X = (int)(_random.NextDouble() < 0.5 ? -_padding : w + _padding);
            }

            return pos;
        }

        public static void AddZombie()
        {
            Enemys.Add(new(_texture, RandomPosition()));
        }

        public static void Update(Player player)
        {
            _spawnTime -= Globals.Time;
            while (_spawnTime <= 0)
            {
                _spawnTime += _spawnCooldown;
                AddZombie();
            }

            foreach (var z in Enemys)
            {
                z.Update(player);
            }
            Enemys.RemoveAll((z) => z.HP <= 0);
        }

        public static void Draw()
        {
            foreach (var z in Enemys)
            {
                z.Show();
                z.Draw();
            }
        }
    }
}
