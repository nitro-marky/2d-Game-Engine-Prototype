using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Prototype.Game_Logic
{
    interface IRoadRenderer
    {
        void LoadContent(SpriteBatch spriteBatch);

        void UpdateEntities(List<IEntity> list);

        void Draw(GameTime gameTime);

    }
}
