using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;
using Game_Prototype.Game_Implementation;
using Microsoft.Xna.Framework.Input;

//All the levels will be created using this class.
namespace Game_Prototype.Scene
{
    class Level : IScene
    {
        private String _difficulty;
        private bool _nextLevel;
        private IScene _nextScene;
        private List<ITownEntity> _towns;

        //The difficulty parameter would be used to decide which difficulty XML file to load in the entity factory.
        public Level(String difficulty)
        {
            _difficulty = difficulty;
            _nextLevel = false;
            _towns = new List<ITownEntity>();
        }

        public string getSceneType
        {
            get { return _difficulty; }
        }

        public void LoadContent(List<IEntity> entities)
        {
            foreach(IEntity entity in entities)
            {
                if (entity is Town)
                {
                    _towns.Add((ITownEntity)entity);
                }
            }

        }

        public void Update(GameTime gameTime)
        {

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

        public bool nextLevel
        {
            get { return _nextLevel; }
        }
    }
}
