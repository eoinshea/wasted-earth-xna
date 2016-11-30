using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace WastedEarth
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Camera : Microsoft.Xna.Framework.GameComponent
    {
        //Camera matrices
        public Matrix view { get; protected set; }
        public Matrix projection { get; protected set; }

        //for rotating from MS website
        Vector3 cameraReference = new Vector3(0, 0, 1);
        public static Vector3 cam_pos;

        // Camera vectors
        //public Vector3 cameraPosition { get; protected set; }
        Vector3 cameraDirection;
        Vector3 cameraUp;
        Vector3 cameraPosition;

        //Speed of the camera
        float speed = 3;
        float anglex = (float)(Math.PI / 2);
        float angley = (float)(Math.PI / 2);
        Vector3 target = new Vector3(0, 0, 0);


        Matrix rotationMatrixX, rotationMatrixY;


        public Camera(Game game, Vector3 pos, Vector3 target, Vector3 up)
            : base(game)
        {
            // Build camera view matrix
            cameraPosition = new Vector3(0, 0, 3000);
            cameraUp = up;
            CreateLookAt();

            projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                (float)Game.Window.ClientBounds.Width /
                (float)Game.Window.ClientBounds.Height,
                1, 1000000);

            rotationMatrixX = Matrix.CreateRotationX(anglex);
            rotationMatrixY = Matrix.CreateRotationY(angley);


//#if !DEBUG
//            graphics.IsFullScreen = true;
//#endif
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {

            //rotate camera
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                cameraPosition = Vector3.Transform(cameraPosition, Matrix.CreateRotationY(-0.01f));

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                cameraPosition = Vector3.Transform(cameraPosition, Matrix.CreateRotationY(0.01f));

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                cameraPosition = Vector3.Transform(cameraPosition, Matrix.CreateRotationX(-0.01f));

            if (Keyboard.GetState().IsKeyDown(Keys.S))
                cameraPosition = Vector3.Transform(cameraPosition, Matrix.CreateRotationX(0.01f));

            //CastBulletRay();

            cam_pos = cameraPosition;

            CreateLookAt();

            base.Update(gameTime);
        }

        private void CreateLookAt()
        {

            view = Matrix.CreateLookAt(cameraPosition, target, Vector3.Up);
        }


        // This would be located in the player class 

    }
}
//cameraPosition + cameraDirection