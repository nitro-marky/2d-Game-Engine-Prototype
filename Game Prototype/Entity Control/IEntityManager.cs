using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Entity_Control
{
    //The interface for the Entity Manager
    interface IEntityManager
    {
        void TerminateEntity(int ID);
        void TerminateAllEntities();
        void CreateEntities(String level);
        void Update(GameTime gameTime);
    }
}
