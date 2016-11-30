using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace WastedEarth
{
    class Earth : BasicModel
    {
        Matrix rotation = Matrix.Identity ;
        Matrix scale = Matrix.CreateScale(1000.0f);
        public Earth(Model m)
            : base(m)
        {
        }

        public override void Update()
        {
           //rotation *= Matrix.CreateRotationZ(MathHelper.Pi / 1800);
        }

        public override Matrix GetWorld()
        {
            return scale * world * rotation;
        }
    }
}