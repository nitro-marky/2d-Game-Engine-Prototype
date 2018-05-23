using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Game_Prototype.Entity_Control;
using Game_Prototype.Entities;
using Game_Prototype.Game_Logic;
using Game_Prototype.GameAI;
using Game_Prototype.Input;

//The GameManager is responsible for orchestrating the AI.
namespace Game_Prototype.Game_Implementation
{
    class GameManager : IGameManager, IEntityObserver, IGeneralInputObserver
    {
        private List<IEntity> _entities;
        private List<ITownEntity> _towns;
        private IAIManager _aiManager;

        public GameManager()
        {

            _entities = new List<IEntity>();
            _towns = new List<ITownEntity>();
            _aiManager = new AIManager();
        }

        public void Update(GameTime gameTime)
        {
            _aiManager.update();
            StatManager._instance.Update();
        }

        public void EntityNotified(List<IEntity> entities)
        {
            _aiManager.updateEntities(entities);
        }

        public void Setup()
        {

        }

        public void ReceiveInputNotification(InputType type, int id)
        {
            _aiManager.userInput(type, id);
        }
    }
}
