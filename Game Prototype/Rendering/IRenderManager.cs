using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Rendering
{
    interface IRenderManager
    {
        void LoadContent(SpriteBatch spriteBatch);

        void Draw(GameTime gameTime);
    }
}
