using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Rendering
{
    interface IRenderComponent
    {
        Texture2D Texture { get; set; }

        Vector2 getPosition { get; }

    }
}
