using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Entity_Control
{
    class EntityManager : IEntityNotifier, IEntityManager
    {
        private List<IEntity> _entityList;
        private List<IEntityObserver> _observers;
        private IEntityFactory _entityFactory;
        private List<IEntity> _currentEntities;

        public EntityManager()
        {
            _entityList = new List<IEntity>();
            _observers = new List<IEntityObserver>();
            _currentEntities = new List<IEntity>();
            _entityFactory = new EntityFactory();
        }

        public void Update(GameTime gameTime)
        {
            for (int j = 0; j < _currentEntities.Count; j++)
            {
                _currentEntities[j].Update(gameTime);
            }

        }


        //Sends the current list of entities to the classes that have subscribed to the updates.
        public void NotifyEntityObservers()
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                _observers[i].EntityNotified(_entityList);
            }
        }

        //Requests the entities from the EntityFactory using a string as a level identifier. The entities then load content and are initialised.
        //Once created the observers are informed.
        public void CreateEntities(String level)
        {
            _currentEntities.Clear();
            _entityList.Clear();
            _entityList = _entityFactory.makeEntities(level);
            foreach (IEntity entity in _entityList)
            {
                entity.LoadContent();
                entity.Initialise();
                _currentEntities.Add(entity);
            }
            NotifyEntityObservers();
        }


        //Uses the entity id to check the list in order for it be removed. The observers are notified about the change.
        public void TerminateEntity(int ID)
        {
            for (int i = 0; i < _entityList.Count; i++)
            {
                if (_entityList[i].getID == ID)
                {
                    _entityList[i] = null;
                    _entityList.RemoveAt(i);
                    NotifyEntityObservers();
                }               
            }
        }

        public void TerminateAllEntities()
        {
            _entityList.Clear();
            NotifyEntityObservers();
        }


        //Observers can be added and removed from the list.
        public void AddEntityObserver(IEntityObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveEntityObserver(IEntityObserver observer)
        {
            _observers.Remove(observer);
        }
    }
}
