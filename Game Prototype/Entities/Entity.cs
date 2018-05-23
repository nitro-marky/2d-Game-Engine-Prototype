using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

//Base entity class which all entities inherit from
namespace Game_Prototype.Entities
{
    abstract class Entity : IEntity
    {

        protected string _uName;
        protected int _UID;
        protected Vector2 _position;
        private bool _idSet = false;
        private bool _nameSet = false;

        public string getUName
        {
            get
            {
                return _uName;
            }
        }

        public void setID()
        {
            if (_idSet == false)
            {
                generateUID();
                _idSet = true;
            }
        }

        public void setName(int num)
        {
            if (_nameSet == false)
            {
                generateUName();
                _uName = _uName + num;
                _nameSet = true;
            }
        }

        public int getID
        {
            get
            {
                return _UID;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            this._position = newPosition;
        }

        public Vector2 getPosition
        {
            get { return this._position; }
        }

        public virtual void Initialise()
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void LoadContent()
        {
        }

        //The id for each entity is based upon their hash code.
        private void generateUID()
        {
            _UID = this.GetHashCode();
        }

        private void generateUName()
        {
            _uName = this.GetType().ToString();
        }
    }
}
