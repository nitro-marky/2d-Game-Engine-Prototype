using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Game_Implementation
{
    interface IGameManager
    {
        void Update(GameTime gameTime);

        void Setup();
    }
}
