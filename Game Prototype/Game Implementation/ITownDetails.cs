using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Game_Implementation
{
    interface ITownDetails
    {

        bool Vaccinated { get; set; }

        bool Infected { get; set; }

        bool Active { get; set; }

        String TownName { get; set; }

        int Population { get; set; }

        int HealthyPopulation { get; set; }

        int SickPopulation { get; set; }

        void Update(GameTime gameTime);

        Vector2 Position { get; }

        int getID { get; }

        void setPosition(Vector2 pos);
        bool StatusChange { get; set; }

        void addTownToNetwork(ITownEntity town);

        List<ITownEntity> getConnectedTowns {get;}
      
    }
}
