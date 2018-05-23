using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Game_Prototype.Entity_Control;

namespace Game_Prototype.Scene
{
    interface ISceneManager
    {

        void LoadContent();

        void UnloadContent();

        void Update(GameTime gameTime);

    }
}
