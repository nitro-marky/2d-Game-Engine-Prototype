using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;
using Game_Prototype.Game_Implementation;
using Microsoft.Xna.Framework;
using Game_Prototype.Input;

namespace Game_Prototype.GameAI
{
    /*
     * The AI Manager contains the ai infection and is responsible for initialising and orchestrating it by passing towns
     * and user input.
     */
    class AIManager : IAIManager
    {
        private IInfection _infectionControl;
        private List<ITownEntity> _towns;

        public AIManager()
        {
            _towns = new List<ITownEntity>();
            _infectionControl = new AIInfection();
        }

        public void updateEntities(List<IEntity> entities)
        {
            _towns.Clear();

            foreach(IEntity entity in entities)
            {
                if (entity is ITownEntity)
                {
                    _towns.Add((ITownEntity)entity);
                }
            }
            
            if (_towns.Count > 0)
            {
                _infectionControl.setTownList(_towns);
                _infectionControl.setTown();
            }
        }

        public void update()
        {
            _infectionControl.update();
        }


        public void userInput(InputType type, int id)
        {
            _infectionControl.inputDetected(type, id);
        }
    }
}
