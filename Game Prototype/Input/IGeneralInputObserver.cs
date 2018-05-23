using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Prototype.Input
{
    interface IGeneralInputObserver
    {
        
        void ReceiveInputNotification(InputType type, int id);

    }
}
