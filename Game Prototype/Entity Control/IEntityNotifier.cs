using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;

namespace Game_Prototype.Entity_Control
{
    //The subject interface for the EntityManager which informs the observers about Entity changes 
    interface IEntityNotifier
    {
        void NotifyEntityObservers();

        void AddEntityObserver(IEntityObserver observer);

        void RemoveEntityObserver(IEntityObserver observer);
    }
}
