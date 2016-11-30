using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace WastedEarth
{
    class Skysphere : BasicModel
    {
        Matrix rotation = Matrix.Identity * Matrix.CreateRotationX(MathHelper.Pi /2);
        Matrix scale = Matrix.CreateScale(-2000.0f);

        public Skysphere(Model m)
            : base(m)
        {
        }

        public override void Update()
        {
            //rotation *= Matrix.CreateRotationY(MathHelper.Pi / 1000);
        }

        public override Matrix GetWorld()
        {
            return scale * world * rotation;
        }
    }
}