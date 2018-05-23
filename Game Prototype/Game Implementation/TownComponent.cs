using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;

//Town entities contain a TownComponent which stores all of the town specific information.
namespace Game_Prototype.Game_Implementation
{
    class TownComponent : ITownDetails
    {
        private IEntity _parent;
        private int _population;
        private int _sickPopulation;
        private int _healthyPopulation;
        private bool _vaccinated;
        private bool _infected;
        private bool _isActive;
        private String _townName;
        private bool _initialState;
        private bool _isChanged;
        private Vector2 _position;
        private List<ITownEntity> _connectedTowns;

        public TownComponent(IEntity parent)
        {
            _parent = parent;
            _connectedTowns = new List<ITownEntity>();
            _position = _parent.getPosition;
        }

        //The update loop changes the numbers of sick/vaccinated 
        public void Update(GameTime gameTime)
        {
            if (!_initialState)
            {
                if (_vaccinated)
                {
                    double _seventyPercent = 0.70 * _population;
                    double _ninetyPercent = 0.90 * _population;

                    _sickPopulation = _population - Engine._random.Next((int)_seventyPercent, (int)_ninetyPercent);
                    _healthyPopulation = _population - _sickPopulation;

                    _initialState = true;
                }
                else if (_infected)
                {

                    double _fivePercent = 0.05 * _population;
                    double _tenPercent = 0.10 * _population;

                    _sickPopulation = _population - Engine._random.Next((int)_fivePercent, (int)_tenPercent);
                    _healthyPopulation = _population - _sickPopulation;
                    

                    _initialState = true;
                }
            }
        }

        public bool Vaccinated
        {
            get{ return _vaccinated;}
            set{ _vaccinated = value;}
        }

        public bool Infected
        {
            get{ return _infected;}
            set{_infected = value;}
        }

        public bool Active
        {
            get{return _isActive;}
            set{_isActive = value;}
        }

        public string TownName
        {
            get { return _townName; }
            set { _townName = value; }
        }

        public int Population
        {
            get { return _population; }
            set { _population = value; }
        }

        public int HealthyPopulation
        {
            get { return _healthyPopulation; }
            set { _healthyPopulation = value; }
        }

        public int SickPopulation
        {
            get { return _sickPopulation; }
            set { _sickPopulation = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
        }

        public void setPosition(Vector2 pos)
        {
            _position = pos;
        }

        public int getID 
        {
            get { return _parent.getID; } 
        }

        public bool StatusChange
        {
            get { return _isChanged; }
            set { _isChanged = value; }
        }

        //Used by AI to create the infection network.
        public void addTownToNetwork(ITownEntity town)
        {
            if (!_connectedTowns.Contains(town))
            {
                _connectedTowns.Add(town);
            }
        }

        public List<ITownEntity> getConnectedTowns
        {
            get { return _connectedTowns; }
        }
    }
}
