using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Rendering;
using Microsoft.Xna.Framework;
using Game_Prototype.Input;
using Microsoft.Xna.Framework.Graphics;
using Game_Prototype.Entity_Control;
using Game_Prototype.Scene;
using Game_Prototype.Game_Implementation;
using Game_Prototype.Audio;

namespace Game_Prototype
{

    //Engine class holds the managers, it is a singleton class
    class Engine
    {

        private static Engine _engineSingleton = null;
        private IRenderManager _renderer;
        private IAudioManager _audioManager;
        private IInputManager _inputManager;
        private IEntityManager _entityManager;
        private IEntityNotifier _entityObservers;
        private ISceneManager _sceneManager;
        private IGameManager _gameManager;
        public static Random _random;

        private Engine() 
        {
            _random = new Random();
            _renderer = new RenderManager();
            _entityManager = new EntityManager();
            _entityObservers = (IEntityNotifier)_entityManager;
            _inputManager = new InputManager();
            _sceneManager = new SceneManager(_entityManager);
            _gameManager = new GameManager();
            _audioManager = new AudioManager();
        }

        public static Engine getEngine()
        {
            if (_engineSingleton == null)
            {
                _engineSingleton = new Engine();
            }
            return _engineSingleton;
        }

        //The entity observers are set up along with the general input observers.
        public void Initialise()
        {

            _entityObservers.AddEntityObserver((IEntityObserver)_renderer);
            _entityObservers.AddEntityObserver((IEntityObserver)_inputManager);
            _entityObservers.AddEntityObserver((IEntityObserver)_gameManager);
            _entityObservers.AddEntityObserver((IEntityObserver)_audioManager);
            _inputManager.AddGeneralObserver((IGeneralInputObserver)_gameManager);
            _inputManager.AddGeneralObserver((IGeneralInputObserver)StatManager._instance);
            _entityObservers.AddEntityObserver((IEntityObserver)_sceneManager);
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            _renderer.LoadContent(spriteBatch);
            _sceneManager.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            _sceneManager.Update(gameTime);
            _inputManager.Update(gameTime);
            _entityManager.Update(gameTime);
            _gameManager.Update(gameTime);
            _audioManager.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _renderer.Draw(gameTime);
        }

    }
}
