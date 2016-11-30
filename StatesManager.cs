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
    /// This is the main type for your game
    /// </summary>
    public class StatesManager 
    {
        //0 exit
        //1 Menu
        //2 Game
        public static int state;

        public StatesManager()
        {
            state = 1;
        }

        public void ChangeState(int newstate)
        {
            state = newstate;
        }

    }
}
