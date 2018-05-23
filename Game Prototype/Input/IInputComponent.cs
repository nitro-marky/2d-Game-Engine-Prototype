using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Prototype.Input
{
    interface IInputComponent
    {
        bool Clicked { get; set; }

        bool Hovering { get; set; }

        bool RightClicked { get; set; }
    }
}
