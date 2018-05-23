using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;

namespace Game_Prototype.Entity_Control
{
    //Interface for classes that need to be informed about entity changes.
    interface IEntityObserver
    {
        void EntityNotified(List<IEntity> list);
    }
}
