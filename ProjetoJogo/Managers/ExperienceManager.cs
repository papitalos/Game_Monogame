using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Models.Jogador;
using ProjetoJogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using ProjetoJogo.Models;

namespace ProjetoJogo.Managers
{

    public static class ExperienceManager
    {
        private static Texture2D _texture;
        public static List<Experience> Experience { get; } = new();
        private static SpriteFont _font;
        private static Vector2 _position;
        private static Vector2 _textPosition;
        private static string _playerExp;

        public static void Init(Texture2D tex)
        {
            _texture = tex;
            _font = Globals.Content.Load<SpriteFont>("default");
            _position = new(-8, 40);
        }

        public static void Reset()
        {
            Experience.Clear();
        }

        public static void AddExperience(Vector2 pos)
        {
            Experience.Add(new(_texture, pos));
        }

        public static void Update(Player player,PlayerData playerData)
        {
            foreach (var e in Experience)
            {
                e.Update();

                if ((e.Position - player.Position).Length() < 50)
                {
                    e.Collect();
                    player.GetExperience(1);
                }
            }

            Experience.RemoveAll((e) => e.Lifespan <= 0);

            _playerExp = playerData.Experience.ToString();
            var x = _font.MeasureString(_playerExp).X / 2;
            _textPosition = new(18, 45);
        }

        public static void Draw()
        {
            Globals.SpriteBatchDOIS.Draw(_texture, _position, null, Color.White * 0.75f, 0f, Vector2.Zero, 2f, SpriteEffects.None, 1f);
            Globals.SpriteBatchDOIS.DrawString(_font, _playerExp, _textPosition, Color.White);

            foreach (var e in Experience)
            {
                e.Draw();
            }
        }
    }
}
