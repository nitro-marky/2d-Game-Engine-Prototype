using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game_Prototype.Utilities;
using System.Timers;

// FactDisplay shows the Infirmary facts on screen.
namespace Game_Prototype.Game_Implementation
{
    class FactDisplay : IFactDisplay
    {
        private SpriteBatch _spriteBatch;
        private bool _startDrawing;
        private List<String> _factList;
        Timer _timer;
        private bool _initialFact;
        private String _currentFact;
        private SpriteFont _font;

        //Timer is created which is used to display a fact for 20 seconds.
        public FactDisplay()
        {
            _timer = new System.Timers.Timer(20000);
        }

        //Entites are given to the FactDisplay by the RenderManager
        public void UpdateEntities(List<IEntity> list)
        {
            foreach (IEntity entity in list)
            {
                if (entity is Background)
                {
                    _startDrawing = true;
                }
            }
        }


        //Font is loaded along with a compiled XML which contains the list of facts to choose from.
        public void LoadContent(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _font = ContentService.content.Load<SpriteFont>("gameFont28");
            _factList = ContentService.content.Load<List<String>>("fact_sheet");
        }

        public void Draw(GameTime gameTime)
        {
            if (_startDrawing)
            {
                if (!_initialFact)
                {
                    _currentFact = ChooseStartFact();
                    _initialFact = true;
                    _timer.Start();
                    _timer.AutoReset = true;
                }

                _spriteBatch.Begin();
                _spriteBatch.DrawString(_font, _currentFact, new Vector2(1500, 690), Color.WhiteSmoke);
                _spriteBatch.End();

                _timer.Elapsed += new ElapsedEventHandler(NextFact);
            }
        }

        //Choose a random fact from the list to display next.
        private void NextFact(object source, ElapsedEventArgs e)
        {
            int max = _factList.Count();

            int index = Engine._random.Next(0, max);

            String _nextFact = _factList[index];

            if (_nextFact == _currentFact)
            {
                index = Engine._random.Next(0, max);
                _nextFact = _factList[index];
            }

            _currentFact = _nextFact;
        }

            private String ChooseStartFact()
            {
                int max = _factList.Count();

                int index = Engine._random.Next(0, max);

                return _factList[index];
            }


    }
}
