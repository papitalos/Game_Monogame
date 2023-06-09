using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjetoJogo.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Rastro
{
    public class TrailPart : Sprite
    {
        public float Lifespan { get; private set; }
        public float rotation;
        private readonly float _lifespanMax;

        public TrailPart(Texture2D texture, Vector2 position,float rotation, float lifespan) : base(texture, position, rotation)
        {
            isRot = false;

            _lifespanMax = lifespan;
            Lifespan = lifespan;
            this.rotation = rotation;
        }

        public void Update()
        {
            UpdateInfo();
            
            Lifespan -= Globals.Time;
            color = Color.White * (Lifespan / _lifespanMax);
        }
    }
}
