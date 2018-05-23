using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Entities
{
    interface IEntity
    {
        void setID();

        void setName(int num);

        int getID { get; }

        string getUName { get; }

        void setPosition(Vector2 newPosition);

        Vector2 getPosition { get; }

        void Initialise();

        void Update(GameTime gameTime);

        void LoadContent();

    }
}
