using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Game_Prototype.Entity_Control;
using Game_Prototype.Entities;

namespace Game_Prototype.Input
{
    //Checks mouse input for entities that can be interacted with
    class MouseInput : IControllerInput
    {
        private List<IClickObserver> _clickObservers;
        private List<IGeneralInputObserver> _generalObservers;
        private List<IHoverObserver> _hoverObserver;
        private List<IInputObserver> _observers;
        private MouseState _previousState;
        private MouseState _currentState;


        public MouseInput()
        {
            _clickObservers = new List<IClickObserver>();
            _hoverObserver = new List<IHoverObserver>();
            _generalObservers = new List<IGeneralInputObserver>();
            _observers = new List<IInputObserver>();
        }


        //Is given input entities by the input manager, they are then checked who can be clicked and who is hoverable
        public void UpdateObservers(List<IInputObserver> observers)
        {
            _observers.Clear();
            _clickObservers.Clear();
            _hoverObserver.Clear();

            foreach (IInputObserver observer in observers)
            {
                if (observer is IClickObserver)
                {
                    _clickObservers.Add((IClickObserver)observer);
                }
                if (observer is IHoverObserver)
                {
                    _hoverObserver.Add((IHoverObserver)observer);
                }
            }
        }

        //Updates observers that are not interacted with directly but are affected by input such as the AI.
        public void UpdateGeneralObservers(IGeneralInputObserver observer)
        {
            if (!_generalObservers.Contains(observer))
            {
                _generalObservers.Add(observer);
            }
        }

        public void Update(GameTime gameTime)
        {
            _previousState = _currentState;
            _currentState = Mouse.GetState();
            ClickCheck();
            HoverCheck();        
        }

        //Through the IClickObserver interface the entity's position and bounding box can be accessed, these are then checked against mouse
        //click positions. If a click has been detected the click observers are sent a message which contains a string identifier and the ID
        //of the entity that has been clicked.
        private void ClickCheck()
        {
            if (_previousState.LeftButton == ButtonState.Released && _currentState.LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < _clickObservers.Count; i++)
                {
                    if (_clickObservers[i].getBoundingBox.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                    {
                        NotifyObservers(InputType.left_click, _clickObservers[i].getID);
                        NotifyGeneralObservers(InputType.left_click, _clickObservers[i].getID);
                    }
                }
            }

            
            if (_previousState.RightButton == ButtonState.Released && _currentState.RightButton == ButtonState.Pressed)
            {
                foreach (IClickObserver obs in _clickObservers)
                {
                    if (obs.getBoundingBox.Contains(Mouse.GetState().Position.X, Mouse.GetState().Position.Y))
                    {
                        NotifyObservers(InputType.right_click, obs.getID);
                        NotifyGeneralObservers(InputType.right_click, obs.getID);
                    }
                }
            }
        }

        //Using similar checks as above, the entity bounding box is used to see if the mouse is over that position.
        private void HoverCheck()
        {
            foreach (IHoverObserver observer in _hoverObserver)
            {
                if (observer.getBoundingBox.Contains(_currentState.Position.X, _currentState.Position.Y))
                {
                    NotifyHover(true, observer.getID);
                }
                else
                {
                    NotifyHover(false, observer.getID);
                }
            }
        }


        //The notify methods to tell input observers about input occurances.
        public void NotifyHover(bool hover, int ID)
        {
            foreach (IHoverObserver observer in _hoverObserver)
            {
                observer.NotifyHover(hover, ID);
            }
        }


        public void NotifyObservers(InputType type, int ID)
        {
            foreach (IClickObserver observer in _clickObservers)
            {
                observer.NotifyClick(type, ID);
            }
        }

        public void NotifyGeneralObservers(InputType type, int id)
        {
            foreach (IGeneralInputObserver observer in _generalObservers)
            {
                observer.ReceiveInputNotification(type, id);
            }
        }
    }

}
