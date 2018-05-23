using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Input
{
    interface IInputManager
    {
        void Update(GameTime gameTime);

        void AddObserver(IInputObserver observer);

        void RemoveObserver(IInputObserver observer);

        void AddGeneralObserver(IGeneralInputObserver observer);

        void RemoveGeneralObserver(IGeneralInputObserver observer);
    }
}
