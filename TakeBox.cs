using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace WastedEarth
{
    class TakeBox : BasicModel
    {
        Matrix rotation = Matrix.Identity;
        Matrix scale = Matrix.CreateScale(50.0f);
        Boolean finished;
        Vector3 Pos;
        public BoundingSphere b;
        Vector3 diff = new Vector3(200,200,200);
        public int food;

        Matrix translation;

        public void LoseFood()
        {
            food--;
            if (food == 0)
                finished = true;
        }


        public Boolean getFinished()
        {
            return finished;
        }

        //Matrix transform = Matrix.Transform();
        public TakeBox(Model m, Vector3 pos)
            : base(m)
        {
            finished = false;
            Pos = pos;
            b = new  BoundingSphere(pos, 300);
            food = 100;
        }

        public override void Update()
        {
                this.translation = Matrix.CreateTranslation(Pos);
        }

        public void NewPos(Vector3 pos)
        {
               finished = false;
               Pos = pos;
               food = 100;
               b = new BoundingSphere(pos, 300);
        }


        public override Matrix GetWorld()
        {
            return scale * world * rotation * translation ;
        }
    }
}