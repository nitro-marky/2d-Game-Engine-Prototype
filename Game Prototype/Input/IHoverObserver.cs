using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Input
{
    interface IHoverObserver : IInputObserver
    {
        Rectangle getBoundingBox { get; }

        int getID { get; }

        void NotifyHover(bool hovering, int ID);
    }
}
