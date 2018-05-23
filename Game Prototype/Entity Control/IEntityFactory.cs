using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;

namespace Game_Prototype.Entity_Control
{
    interface IEntityFactory
    {
        List<IEntity> makeEntities(String level);
    }
}
