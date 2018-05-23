using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Input;

namespace Game_Prototype.Game_Implementation
{
    //Contains the game score information, employs the singleton pattern
    class StatManager : IGeneralInputObserver
    {
        public static StatManager _instance = new StatManager();
        private List<ITownEntity> _towns;
        private int _totalPop;
        private int _totalHealthy;
        private int _totalSick;
        private bool _gameOver;
        private int _counter;

        private StatManager()
        {
            _totalPop = 0;
            _counter = 0;
            _gameOver = false;
            _towns = new List<ITownEntity>();
        }

        public static StatManager instance()
        {
            if (_instance == null)
            {
                _instance = new StatManager();
            }
            return _instance;
        }

        //Receives the town entities and calculates the total map population.
        public void setTowns(List<ITownEntity> towns)
        {
            _towns.Clear();
            _towns = towns;
            for (int i = 0; i < _towns.Count; i++)
            {
                _totalPop += _towns[i].getTownComponent.Population;
            }
        }

        //As long as the game isn't over the stats will be updated.
        public void Update()
        {
            if (!gameOver)
            {
                updateStats();
            }
        }

        public int getHealthy
        {
            get { return _totalHealthy; }
        }

        public int getScore
        {
            get { return _totalPop - _totalSick; }
        }

        public int getSick
        {
            get { return _totalSick; }
        }

        public int getPop
        {
            get { return _totalPop; }
        }

        public bool gameOver
        {
            get { return _gameOver; }
        }

        public void setGameOver(bool gameOver)
        {
            _gameOver = gameOver;
        }

        public void ReceiveInputNotification(InputType type, int id)
        {
            
        }

        //The counter is used by the AI to determine if it needs to take it's turn. The counter is incremented when a town is infected.
        public int counter
        {
            get { return _counter; }
            set { _counter = value; }
        }

        //Calculates the current score state during play.
        public void updateStats()
        {

            if (_towns.Count > 0)
            {
                _totalHealthy = 0;
                _totalSick = 0;
                    for (int i = 0; i < _towns.Count; i++)
                    { 
                            _totalSick += _towns[i].getTownComponent.SickPopulation;
                            _totalHealthy += _towns[i].getTownComponent.HealthyPopulation;
                       
                    }
            }
        }
    }
}
