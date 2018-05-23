using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Game_Implementation;
using Game_Prototype.Input;
using Microsoft.Xna.Framework;

namespace Game_Prototype.GameAI
{
    /*
     * The AIInfection class contains the main AI logic which checks and decides which town to infect.
     */
    class AIInfection : IInfection
    {
        private ITownEntity _startTown;
        private List<ITownEntity> _towns;
        private List<ITownEntity> _updatedTowns;
        private List<ITownEntity> _infectedTowns;
        private List<ITownEntity> _currentState;
        private List<ITownEntity> _prevState;
        private bool _started = false;
        private int _prevCount = 0;

        private Random random = new Random();

        public AIInfection()
        {
            _towns = new List<ITownEntity>();
            _updatedTowns = new List<ITownEntity>();
            _currentState = new List<ITownEntity>();
            _prevState = new List<ITownEntity>();
            _infectedTowns = new List<ITownEntity>();
        }

        public void update()
        {
            //Sets the game status to over when there are no more towns for the AI to infect.           
            if (_started == true)
            {
                if (checkForTowns().Count == 0)
                {
                    StatManager._instance.setGameOver(true);
                }
            }
        }

        public void setTownList(List<ITownEntity> towns)
        {
            _towns = towns;
            createNetwork();
            _updatedTowns = towns;
        }

        public void setTown()
        {
            List<ITownEntity> temp = _updatedTowns;

            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].getTownComponent.getConnectedTowns.Count < 3)
                {
                    temp.RemoveAt(i);
                }
            }

            int index = Engine._random.Next(0, temp.Count);
            _startTown = temp[index];
            _startTown.getTownComponent.Infected = true;
            _startTown.getTownComponent.Active = true;
            _infectedTowns.Add(_startTown);
        }

        //Checks that user input is town related and calls the infectTown function.
        public void inputDetected(InputType type, int id)
        {
            if (type == InputType.left_click)
            {
                if (StatManager._instance.counter == _prevCount + 1)
                {
                    infectTown();
                    _started = true;
                    _prevCount = StatManager._instance.counter;
                }
            }
        }

        /*
         * The createNetwork function is responsible for telling each town who it's neighbours are which is later used 
         * decide which town to infect.
         */
        private void createNetwork()
        {
            for (int i = 0; i < _towns.Count; i++)
            {
                Vector2 start = _towns[i].getTownComponent.Position;

                for (int j = 0; j < _towns.Count; j++)
                {
                    if (_towns[i].getTownComponent.getID == _towns[j].getTownComponent.getID)
                    {
                        
                    }
                    else
                    {
                        int _tempX = (int)_towns[i].getTownComponent.Position.X - (int)_towns[j].getTownComponent.Position.X;
                        int _tempY = (int)_towns[i].getTownComponent.Position.Y - (int)_towns[j].getTownComponent.Position.Y;

                        if ((_tempX < 275 && _tempX > -275) && (_tempY < 275 && _tempY > -275))
                        {
                            _towns[i].getTownComponent.addTownToNetwork(_towns[j]);
                            _towns[j].getTownComponent.addTownToNetwork(_towns[i]);      
                        }
                    }
                }

                //Uncomment to see a list of the towns and their connections.
                //printTownConnections(i);
            }
        }

        //Utility method to check town connections
        private void printTownConnections(int i)
        {
            List<String> _names = new List<string>();
            List<ITownEntity> towns = _towns[i].getTownComponent.getConnectedTowns;
            Console.Write("Town: " + _towns[i].getTownComponent.TownName + ", Connected To: ");
            foreach (ITownEntity town in towns)
            {
                Console.Write(town.getTownComponent.TownName + ", ");
                _names.Add(town.getTownComponent.TownName);
            }
            Console.WriteLine("");
        }

        /*
         * Iterates through the current list of infected towns and retrieves all of the connected towns. These connections are then 
         * checked to see if they are already infected or vaccinated. If they are not they are added to a list of available towns which
         * is then returned.
         */
        private List<ITownEntity> checkForTowns()
        {
            List<ITownEntity> _availableTowns = new List<ITownEntity>();

            foreach (ITownEntity town in _infectedTowns)
            {
                List<ITownEntity> _connected = town.getTownComponent.getConnectedTowns;

                if (_connected.Count > 0)
                {
                    foreach (ITownEntity conTown in _connected)
                    {
                        if (!conTown.getTownComponent.Infected && !conTown.getTownComponent.Vaccinated)
                        {
                            if (!_availableTowns.Contains(conTown))
                            {
                                _availableTowns.Add(conTown);
                            }
                        }
                    }
                }
            }

            return _availableTowns;
        }

        /*
         * Main AI algorithm. After each player turn all of the towns connected to an infected town are collected. 
         * These are iterated through to find only the towns that available to infect.
         */
        public void infectTown()
        {
            List<ITownEntity> _availableTowns = checkForTowns();

            if (_availableTowns.Count == 1)
            {
                int index = random.Next(_availableTowns.Count);
                _availableTowns[index].getTownComponent.Infected = true;
                _infectedTowns.Add(_availableTowns[index]);
            }
            else if (_availableTowns.Count > 1)
            {
                int infectNum = random.Next(0, 10);
                if (infectNum > 5)
                {
                    int index1 = random.Next(_availableTowns.Count);
                    int index2 = random.Next(_availableTowns.Count);

                    while (index1 == index2)
                    {
                        index2 = random.Next(_availableTowns.Count);
                    }
                     _availableTowns[index1].getTownComponent.Infected = true;
                     _infectedTowns.Add(_availableTowns[index1]);

                     _availableTowns[index2].getTownComponent.Infected = true;
                     _infectedTowns.Add(_availableTowns[index2]);
                }
                else
                {
                    int index = random.Next(_availableTowns.Count);

                    _availableTowns[index].getTownComponent.Infected = true;
                    _infectedTowns.Add(_availableTowns[index]);
                }
            }

            
        }

    }
}
