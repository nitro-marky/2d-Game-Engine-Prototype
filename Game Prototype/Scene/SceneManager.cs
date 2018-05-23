using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entity_Control;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Scene
{
    class SceneManager : ISceneManager, IEntityObserver
    {
        private IEntityManager _entityManager;
        private List<IEntity> _entities;
        private IScene _currentScene;

        public SceneManager(IEntityManager manager)
        {
            _entities = new List<IEntity>();
            _entityManager = manager;
            _currentScene = new StartMenu();
        }

        //The creation of the entities is performed here using the scenes name as the level identifier.
        public void LoadContent()
        {
            _entityManager.CreateEntities(_currentScene.getSceneType);
            _currentScene.LoadContent(_entities);
        }

        //The entities are removed from the scene by the entity manager
        public void UnloadContent()
        {
            for (int i = 0; i < _entities.Count; i++)
            {
                _entityManager.TerminateEntity(_entities[i].getID);
            }
          
        }

        //The check to see if the next scene is due happens in the update. The current scene update method is also called here.
        public void Update(GameTime gameTime)
        {
            _currentScene.Update(gameTime);
            if (_currentScene.nextLevel)
            {
                UnloadContent();
                _currentScene = _currentScene.nextScene();
                LoadContent();
            }
        }

        public void EntityNotified(List<IEntity> list)
        {
            //_entities.Clear();
            _entities = list;
        }
    }
}
