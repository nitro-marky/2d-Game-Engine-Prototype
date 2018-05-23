using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;
using Game_Prototype.Utilities;

namespace Game_Prototype.Entity_Control
{
    class EntityFactory : IEntityFactory
    {

        private List<String> _levelEntities;
        private List<IEntity> _entityList;
        private List<Vector2> _startPositions;


        public EntityFactory()
        {
            _entityList = new List<IEntity>();
            _levelEntities = new List<String>();
            _startPositions = new List<Vector2>();
        }


        //The level identifier is used to load the correct level xml file which contains the list of entities for that scene.
        //Due to technical issues the starting Vector list is loaded seperately rather than in the same file.
        public List<IEntity> makeEntities(String level)
        {
            _entityList.Clear();
            //_levelEntities.Clear();
           // _startPositions.Clear();
            switch (level)
            {
                case "start menu":
                    _levelEntities = ContentService.content.Load<List<String>>("startMenu");
                    _startPositions = ContentService.content.Load<List<Vector2>>("startMenu_positions");
                    break;
                case "easy":
                    _levelEntities = ContentService.content.Load<List<String>>("easy_level");
                    _startPositions = ContentService.content.Load<List<Vector2>>("easy_level_positions");
                    break;
                case "medium":
                    //Create new level XML
                    break;
                case "hard":
                    //Create new level XML
                    break;
            }

            return createEntities();
        }

        //The entity list contains the directory namespace which are cast as a Type. The generic Type is then instantiated without the new
        //keyword by the Activator.CreateInstance function. The positions, ID's and names are all set during the creation.
        private List<IEntity> createEntities()
        {
            _entityList.Clear();

            for (int i = 0; i < _levelEntities.Count; i++)
            {
                Type newEntity = Type.GetType(_levelEntities[i]);
                _entityList.Add((IEntity)Activator.CreateInstance(newEntity));
                _entityList[i].setPosition(_startPositions[i]);
                _entityList[i].setID();
                _entityList[i].setName(i);
            }

            return _entityList;
        }
    }
}
