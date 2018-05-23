using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Game_Implementation
{
    interface ITownUtility
    {
        String getName { get; }

        int getPopulation { get; }

        Vector2 getPosition { get; }
    }
}
