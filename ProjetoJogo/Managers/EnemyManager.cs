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

        private static Vector2 RandomPosition(Vector2 playerPosition, float minRadius, float maxRadius)
        {
            // Gera um ângulo aleatório
            double angle = _random.NextDouble() * Math.PI * 2;

            // Gera um raio aleatório entre minRadius e maxRadius
            double radius = minRadius + (_random.NextDouble() * (maxRadius - minRadius));

            // Calcula a posição do inimigo com base no ângulo e raio
            Vector2 pos = new();
            pos.X = playerPosition.X + (float)(Math.Cos(angle) * radius);
            pos.Y = playerPosition.Y + (float)(Math.Sin(angle) * radius);

            return pos;
        }

        public static void AddEnemy(Player player)
        {
            Enemys.Add(new(_texture, RandomPosition(player.Position, 150f, 450f)));
        }

        public static void Update(Player player)
        {
            _spawnTime -= Globals.Time;
            while (_spawnTime <= 0)
            {
                _spawnTime += _spawnCooldown;
                AddEnemy(player);
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
