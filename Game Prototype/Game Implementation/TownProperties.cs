using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Utilities;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Game_Implementation
{
    //This provides the town entities with the name, population and position.
    class TownProperties : ITownUtility
    {
        private static List<String> _townNames = new List<String>();
        private static List<Vector2> _takenPositions = new List<Vector2>();
        private static bool _isInitialised;
        private ITownEntity _parent;
        private int _minPop = 20;
        private int _maxPop = 2000;
        private Vector2 _position;
        private static int _quadCheck = 1;

        public TownProperties(IEntity parent)
        {
            if (parent is ITownEntity)
            {
                _parent = (ITownEntity)parent;
            }

        }


        public static void initialiseNames()
        {
            _townNames = ContentService.content.Load<List<String>>("town_names");
        }

        public String getName
        {
            get {return returnName();}
        }

        public int getPopulation
        {
            get { return Engine._random.Next(_minPop, _maxPop); }
        }

        //Uses a static method so only one name list and getter process is used by all town entities.
        private static String returnName()
        {
            if (_townNames.Count < 4)
            {
                initialiseNames();
                _isInitialised = true;
            }

            int max = _townNames.Count();

            int index = Engine._random.Next(_townNames.Count);

            String name = _townNames[index];
            _townNames.RemoveAt(index);
            return name;
        }


        public Vector2 getPosition
        {
            get { return GeneratePosition(); }
        }


        //Returns the vector for the town, it divides the plays space into quads, each time a town requests a position it is given one in 
        //a certain quad. This helps to control how the towns are placed in a randon fashion.
        private Vector2 GeneratePosition()
        {
            Vector2 _tempVector = Vector2.Zero;
            if (_quadCheck == 1)
            {
                 _tempVector = new Vector2(Engine._random.Next(412, 812), Engine._random.Next(165, 565));
            }
            else if (_quadCheck == 2)
            {
                _tempVector = new Vector2(Engine._random.Next(812, 1212), Engine._random.Next(165, 565));
            }
            else if (_quadCheck == 3)
            {
                _tempVector = new Vector2(Engine._random.Next(412, 812), Engine._random.Next(565, 965));
            }
            else if (_quadCheck == 4)
            {
                _tempVector = new Vector2(Engine._random.Next(812, 1212), Engine._random.Next(565, 965));
            }

           bool _badVector = CheckVectors(_tempVector);

           while(_badVector == true)
           {
               if (_quadCheck == 1)
               {
                   _tempVector = new Vector2(Engine._random.Next(412, 812), Engine._random.Next(165, 565));
               }
               else if (_quadCheck == 2)
               {
                   _tempVector = new Vector2(Engine._random.Next(812, 1212), Engine._random.Next(165, 565));
               }
               else if (_quadCheck == 3)
               {
                   _tempVector = new Vector2(Engine._random.Next(412, 812), Engine._random.Next(565, 950));
               }
               else if (_quadCheck == 4)
               {
                   _tempVector = new Vector2(Engine._random.Next(812, 1212), Engine._random.Next(565, 950));
               }
               _badVector = CheckVectors(_tempVector);
           }

            _takenPositions.Add(_tempVector);
            _quadCheck++;
            if (_quadCheck > 4)
            {
                _quadCheck = 1;
            }
            return _tempVector;

        }

        private bool CheckVectors(Vector2 tempVector)
        {
            for (int i = 0; i < _takenPositions.Count; i++)
            {
                if (tempVector != _takenPositions[i])
                {
                    int _tempX = (int)tempVector.X - (int)_takenPositions[i].X;
                    int _tempY = (int)tempVector.Y - (int)_takenPositions[i].Y;

                    if ((_tempX < 90 && _tempX > -80) && (_tempY < 80 && _tempY > -80))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
