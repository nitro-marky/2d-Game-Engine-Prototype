using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Game_Implementation;
using Game_Prototype.Input;

namespace Game_Prototype.GameAI
{
    interface IInfection
    {
        void update();

       void setTown();

       void setTownList(List<ITownEntity> towns);

       void inputDetected(InputType type, int id);
    }
}
