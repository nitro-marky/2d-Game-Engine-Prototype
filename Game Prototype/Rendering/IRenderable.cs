using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Prototype.Rendering
{
    interface IRenderable
    {
        IRenderComponent getRenderComponent { get; }
    }
}
