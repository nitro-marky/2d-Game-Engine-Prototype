using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Prototype.Entities
{
    abstract class GameEntity : Entity
    {
        protected Texture2D _texture;

        public GameEntity()
            : base()
        {
            

        }

    }
}
