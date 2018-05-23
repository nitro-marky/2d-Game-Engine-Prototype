using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Game_Prototype.Entity_Control;
using Game_Prototype.Entities;

namespace Game_Prototype.Input
{
    class InputManager : IInputManager, IEntityObserver
    {
        private List<IInputObserver> _observers;
        private List<IGeneralInputObserver> _generalObserver;
        private IControllerInput _mouseInput;
        private List<IEntity> _rawEntities;

        public InputManager()
        {
            _observers = new List<IInputObserver>();
            _generalObserver = new List<IGeneralInputObserver>();
            _mouseInput = new MouseInput();
            _rawEntities = new List<IEntity>();
        }


        public void Update(GameTime gameTime)
        {
            _mouseInput.Update(gameTime);     
        }

        public void AddGeneralObserver(IGeneralInputObserver observer)
        {
            _generalObserver.Add(observer);
        }

        public void RemoveGeneralObserver(IGeneralInputObserver observer)
        {
            _generalObserver.Remove(observer);
        }

        public void AddObserver(IInputObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IInputObserver observer)
        {
            _observers.Remove(observer);
        }

        //Receives the entities, checks for input observers and passes these to the mouse input class.
        public void EntityNotified(List<IEntity> list)
        {
            _observers.Clear();

            foreach (IEntity entity in list)
            {
                if (entity is IInputObserver)
                {
                    if (!_observers.Contains((IInputObserver)entity))
                    {
                        _observers.Add((IInputObserver)entity);
                    }
                }
            }
            _mouseInput.UpdateObservers(_observers);

            foreach (IGeneralInputObserver obs in _generalObserver)
            {
                _mouseInput.UpdateGeneralObservers(obs);
            }
        }

    }

    
    public enum InputType
    {
        left_click, right_click
    }
}
