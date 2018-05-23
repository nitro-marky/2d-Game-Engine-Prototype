using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Game_Implementation
{
    interface ITownEntity
    {
        ITownDetails getTownComponent { get; }
    }
}
