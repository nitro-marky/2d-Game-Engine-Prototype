using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Input
{
    interface IClickObserver : IInputObserver
    {
        Rectangle getBoundingBox { get; }

        int getID { get; }

        void NotifyClick(InputType type, int ID);
    }
}
