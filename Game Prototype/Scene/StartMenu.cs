using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;
using Game_Prototype.Input;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Scene
{
    class StartMenu : IScene
    {
        private String _sceneType = "start menu";
        private List<IEntity> _entities;
        private bool _nextLevel;
        private List<IClickObserver> _guiClickElements;
        private List<IHoverObserver> _guiHoverElements;
        private IScene _nextScene;

        public StartMenu()
        {
            _entities = new List<IEntity>();
            _guiClickElements = new List<IClickObserver>();
            _guiHoverElements = new List<IHoverObserver>();
            _nextLevel = false;
        }

        public void Initialise()
        {

        }

        //The loaded entities are checked to see if they contain input interfaces.
        public void LoadContent(List<IEntity> entities)
        {
            _entities = entities;

            foreach (IEntity entity in _entities)
            {
                
                if (entity is IClickObserver)
                {
                    _guiClickElements.Add((IClickObserver)entity);
                }
                if (entity is IHoverObserver)
                {
                    _guiHoverElements.Add((IHoverObserver)entity);
                }
            }
        }

        //For the prototype only the easy level is active.
        public void Update(GameTime gameTime)
        {
            if (_guiClickElements[0].getInputComponent.Clicked)
            {
                _nextScene = new Level("easy");
                _nextLevel = true;
            }
        }

        public IScene nextScene()
        {
            if (_nextLevel == false)
            {
                return null;
            }
            else
            {
                return _nextScene;
            }
        }

        public string getSceneType
        {
            get { return _sceneType; }
        }

        public bool nextLevel
        {
            get { return _nextLevel; }
        }

    }
}
