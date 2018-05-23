using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;
using Game_Prototype.Input;

namespace Game_Prototype.GameAI
{
    interface IAIManager
    {
        void updateEntities(List<IEntity> entities);
        void update();
        void userInput(InputType type, int id);
    
    }

}
