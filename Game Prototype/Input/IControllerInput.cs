using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Input
{
    interface IControllerInput
    {
        void UpdateObservers(List<IInputObserver> observers);

        void NotifyObservers(InputType type, int ID);

        void UpdateGeneralObservers(IGeneralInputObserver observer);

        void Update(GameTime gameTime);

    }
}
