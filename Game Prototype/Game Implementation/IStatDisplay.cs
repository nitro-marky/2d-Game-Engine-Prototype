using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Game_Implementation
{
    interface IStatDisplay
    {

        void LoadContent(SpriteBatch spriteBatch);

        void UpdateEntities(List<IEntity> list);

        void Draw(GameTime gameTime);

    }
}
