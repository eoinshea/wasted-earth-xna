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
    public class GameManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteFont font;
        SpriteBatch spriteBatch;


        List<BasicModel> spheres = new List<BasicModel>();
        List<TakeBox> take_boxes = new List<TakeBox>();
        List<GiveBox> give_boxes = new List<GiveBox>();

        Vector3 box_pos;
        Vector3[] give_pos = new Vector3[6];
        Vector3[] take_pos = new Vector3[4];
        int give_num,take_num;

        int food_current;
        int food_total;



        public GameManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // nigeria,ireland,venezuela,america,india,australia,safrica;
            //give_pos
            //nigeria
            give_pos[1] = new Vector3(100, 100, 1050);
            //venezuela
            give_pos[2] = new Vector3(1040, 100, 150);

            give_pos[3] = new Vector3(100, 100, 1050);

            give_pos[4] = new Vector3(100, 100, 1050);

            give_pos[0] = new Vector3(1040, 100, 150);

            //ireland
            take_pos[0] = new Vector3(-100, 750, 800);
            //euro
            take_pos[1] = new Vector3(400, 650, 800);
            //aus
            take_pos[2] = new Vector3(600, -650, -650);

            take_pos[3] = new Vector3(-1000, 450, 150);

            food_total = 0;
            food_current = 0;
            
            base.Initialize();
            
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            spheres.Add(new Earth(
                Game.Content.Load<Model>(@"models\earth")));

            spheres.Add(new Skysphere(
                Game.Content.Load<Model>(@"models\sky-sphere2")));

            take_boxes.Add(new TakeBox(
                Game.Content.Load<Model>(@"models\box"), take_pos[3]));

            give_boxes.Add(new GiveBox(
            Game.Content.Load<Model>(@"models\box"), give_pos[0]));

            font = Game.Content.Load<SpriteFont>("myFont");
          
            
            base.LoadContent();
            
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // Loop through all models and call Update
            for (int i = 0; i < spheres.Count; ++i)
            {
                spheres[i].Update();

            }
            Random random1 = new Random();
            Random random2 = new Random();

            int give_num = random1.Next(4);
            int take_num = random2.Next(3);

            for (int i = 0; i < take_boxes.Count; ++i)
            {
                take_boxes[i].Update();
                if (take_boxes[i].getFinished() == true)
                {
                    take_boxes[i].NewPos(take_pos[take_num]);
                }

            }

            for (int i = 0; i < give_boxes.Count; ++i)
            {
                give_boxes[i].Update();
                if (give_boxes[i].getFinished() == true)
                {
                    give_boxes[i].NewPos(give_pos[give_num]);
                }

            }


            CastRay();



            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            
            foreach (BasicModel bm in spheres)
            {
                bm.Draw(((Game1)Game).camera);
            }

            foreach (TakeBox tb in take_boxes)
            {
                tb.Draw(((Game1)Game).camera);
            }

            foreach (GiveBox gb in give_boxes)
            {
                gb.Draw(((Game1)Game).camera);
            }


            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.SaveState);

            DrawText();

            spriteBatch.End();

           
            
            base.Draw(gameTime);
        }

        private void DrawText()
        {
            spriteBatch.DrawString(font, "Current Food: " + food_current.ToString() +"/100" , new Vector2(20, 45), Color.White);
            spriteBatch.DrawString(font, "Total Food Given: " +food_total.ToString() , new Vector2(20, 75), Color.White);

            if (food_total > 200 && food_total < 400)
            {
                spriteBatch.DrawString(font, "HURRY !! " , new Vector2(650, 45), Color.Red);
                spriteBatch.DrawString(font, "PEOPLE ARE DYING !! ", new Vector2(600, 75), Color.Red);
            }
        }




                public void CastRay()
        {
            Ray rayRay = new Ray(Vector3.Zero, Vector3.Normalize(Camera.cam_pos));


            //if (food_current == 101) food_current = 100;

            foreach (TakeBox m in take_boxes)
            {
                if (food_current < 100  )
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.O))
                    {
                        if (rayRay.Intersects(m.b) != null)
                        {
                            m.LoseFood();
                            food_current++;
                        }
                    }
                }
            }

            foreach (GiveBox m in give_boxes)
            {
                if (food_current > 0 && food_current  <101 )
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.P))
                    {
                        if (rayRay.Intersects(m.b) != null)
                        {
                            m.GetFood();
                            food_current--;
                            food_total++;
                        }
                    }
                }
            }

            }
        }
    }
