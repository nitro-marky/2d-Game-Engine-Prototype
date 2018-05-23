using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Prototype.Input
{
    interface IInputObserver
    {
        IInputComponent getInputComponent { get; }

    }
}
