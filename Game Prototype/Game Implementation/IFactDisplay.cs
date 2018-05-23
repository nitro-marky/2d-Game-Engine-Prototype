using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework.Graphics;

//Interface used by the FactDisplay.
namespace Game_Prototype.Game_Implementation
{
    interface IFactDisplay
    {
        void LoadContent(SpriteBatch spriteBatch);

        void UpdateEntities(List<IEntity> list);

        void Draw(GameTime gameTime);
    }
}
