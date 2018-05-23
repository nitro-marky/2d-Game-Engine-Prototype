using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game_Prototype.Utilities;

//Displays the town information when the town is right clicked.
namespace Game_Prototype.Game_Implementation
{
    class TownDisplayManager : ITownDisplay
    {
        private SpriteBatch _spriteBatch;
        private List<ITownEntity> _towns;
        private SpriteFont _font;
        private SpriteFont _font60;
        private SpriteFont _font40;

        public TownDisplayManager()
        {
            _towns = new List<ITownEntity>();   
        }

        public void UpdateEntities(List<IEntity> list)
        {
            _towns.Clear();
            foreach (IEntity entity in list)
            {
                if (entity is ITownEntity)
                {
                    _towns.Add((ITownEntity)entity);
                }
            }
        }


        public void LoadContent(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _font = ContentService.content.Load<SpriteFont>("gameFont");
            _font60 = ContentService.content.Load<SpriteFont>("gameFont60");
            _font40 = ContentService.content.Load<SpriteFont>("gameFont40");
        }


        //If the town is right clicked it is set to active, that is checked here and the town information is displayed accordingly.
        public void Draw(GameTime gameTime)
        {
            if (_towns.Count > 0)
            {
                for (int i = 0; i < _towns.Count; i++)
                {
                    if (_towns[i].getTownComponent.Active)
                    {
                        _spriteBatch.Begin();

                        if (_towns[i].getTownComponent.TownName.Length <= 8)
                        {

                            _spriteBatch.DrawString(_font, _towns[i].getTownComponent.TownName, new Vector2(1500, 80), Color.WhiteSmoke);
                        }
                        else if (_towns[i].getTownComponent.TownName.Length > 8 && _towns[i].getTownComponent.TownName.Length < 12)
                        {
                            _spriteBatch.DrawString(_font60, _towns[i].getTownComponent.TownName, new Vector2(1500, 90), Color.WhiteSmoke);
                        }
                        else
                        {
                            _spriteBatch.DrawString(_font40, _towns[i].getTownComponent.TownName, new Vector2(1500, 100), Color.WhiteSmoke);
                        }

                        _spriteBatch.DrawString(_font40, "Population: " + _towns[i].getTownComponent.Population, new Vector2(1500, 250), Color.WhiteSmoke);
                        _spriteBatch.DrawString(_font40, "Vaccinated: " + _towns[i].getTownComponent.HealthyPopulation, new Vector2(1500, 350), Color.WhiteSmoke);
                        _spriteBatch.DrawString(_font40, "Sick: " + _towns[i].getTownComponent.SickPopulation, new Vector2(1500, 450), Color.WhiteSmoke);
                        _spriteBatch.End();
                    }
                }
            }
      

        }
    }
}
