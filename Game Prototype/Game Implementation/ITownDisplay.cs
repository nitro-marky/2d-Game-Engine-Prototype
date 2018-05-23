using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Game_Implementation
{
    interface ITownDisplay
    {

        void UpdateEntities(List<IEntity> list);

        void LoadContent(SpriteBatch spriteBatch);

        void Draw(GameTime gameTime);
    }
}
