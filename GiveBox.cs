using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace WastedEarth
{
    class GiveBox : BasicModel
    {
        Matrix rotation = Matrix.Identity;
        Matrix scale = Matrix.CreateScale(50.0f);
        Vector3 Pos;
        public BoundingSphere b;
        Vector3 diff = new Vector3(200, 200, 200);
        int food;
        Boolean finished;

        Matrix translation;

        public void Finish()
        {
            finished = true;
        }

        public Boolean getFinished()
        {
            return finished;
        }

        public void GetFood()
        {
            food++;
            if (food == 100)
                Finish();
        }

        //Matrix transform = Matrix.Transform();
        public GiveBox(Model m, Vector3 pos)
            : base(m)
        {
            finished = false;
            Pos = pos;
            b = new BoundingSphere(pos, 300);
            food = 0;
        }

        public override void Update()
        {            
                this.translation = Matrix.CreateTranslation(Pos);
          }

        public void NewPos(Vector3 pos)
        {
            Pos = pos;
            food = 0;
            b = new BoundingSphere(pos, 300);
            finished = false;
        }

        public override Matrix GetWorld()
        {
            return scale * world * rotation * translation;
        }
    }
}