using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Game_Prototype.Utilities;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;

/**
 * The stat display is responsible for rendering the game score information. It gets this data from
 * the static StatManager class.
 */
namespace Game_Prototype.Game_Implementation
{
    class StatDisplay : IStatDisplay
    {
        private List<ITownEntity> _towns;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;

        public StatDisplay()
        {
            _towns = new List<ITownEntity>();
        }

        //Load content is used to load the sprite font.
        public void LoadContent(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _font = ContentService.content.Load<SpriteFont>("gameFont40");
        }

        public void UpdateEntities(List<Entities.IEntity> list)
        {
            _towns.Clear();

            foreach (IEntity entity in list)
            {
                if (entity is ITownEntity)
                {
                    _towns.Add((ITownEntity)entity);
                }
            }
            if (_towns.Count > 0)
            {
                StatManager._instance.setTowns(_towns);
                
            }
        }

        public void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (_towns.Count > 0)
            {
                _spriteBatch.Begin();
                _spriteBatch.DrawString(_font, "Total\nPop: " + StatManager._instance.getPop, new Vector2(10, 100), Color.WhiteSmoke);
                _spriteBatch.DrawString(_font, "Vaccinated:\n" + StatManager._instance.getHealthy, new Vector2(10, 350), Color.WhiteSmoke);
                _spriteBatch.DrawString(_font, "Infected:\n" + StatManager._instance.getSick, new Vector2(10, 550), Color.WhiteSmoke);


                //Checks to see if the game has finished. If so it renders game over and the final score.
                if (StatManager._instance.gameOver)
                {
                    //int score = StatManager._instance.getHealthy - StatManager._instance.getSick;
                    int score = StatManager._instance.getScore;
                    //int score = StatManager._instance.getPop - StatManager._instance.getSick;
                    _spriteBatch.DrawString(_font, "Game Over", new Vector2(10, 750), Color.WhiteSmoke);
                    _spriteBatch.DrawString(_font, "Score:\n" + score, new Vector2(10, 850), Color.WhiteSmoke);
                }

                _spriteBatch.End();
            }
            
            
        }
    }
}
