using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Game_Prototype.Entity_Control;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;
using Game_Prototype.Game_Implementation;
using Game_Prototype.Game_Logic;

namespace Game_Prototype.Rendering
{
    //The RenderManager performs all of the rendering in the game
    class RenderManager : IRenderManager, IEntityObserver
    {
        private List<IRenderable> _entitiesToRender;
        private List<IEntity> _rawEntities;
        private ITownDisplay _townDisplay;
        private SpriteBatch _spriteBatch;
        private IFactDisplay _factDisplay;
        private IRoadRenderer _roadRender;
        private IStatDisplay _statDisplay;

        public RenderManager()
        {
            _entitiesToRender = new List<IRenderable>();
            _rawEntities = new List<IEntity>();
            _townDisplay = new TownDisplayManager();
            _factDisplay = new FactDisplay();
            _roadRender = new RoadRenderer();
            _statDisplay = new StatDisplay();
        }


        public void LoadContent(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _statDisplay.LoadContent(spriteBatch);
            _townDisplay.LoadContent(spriteBatch);
            _factDisplay.LoadContent(spriteBatch);
            _roadRender.LoadContent(spriteBatch);
        }

        //It receives the entity as it is an observer, the entities are checked to see if they are renderable
        public void EntityNotified(List<IEntity> list)
        {
            _entitiesToRender.Clear();

            _rawEntities = list;

            _townDisplay.UpdateEntities(list);
            _factDisplay.UpdateEntities(list);
            _roadRender.UpdateEntities(list);
            _statDisplay.UpdateEntities(list);

            foreach (IEntity entity in list)
            {
                if (entity is IRenderable)
                {
                    _entitiesToRender.Add((IRenderable)entity);
                }
            }
        }

        //The IRenderable interface enables the render manager to get the texture and position of the entity so they can be drawn.
        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            if (_entitiesToRender != null)
            {
                for (int i = 0; i < _entitiesToRender.Count; i++)
                {
                    Texture2D _tex = _entitiesToRender[i].getRenderComponent.Texture;
                    Vector2 _pos = _entitiesToRender[i].getRenderComponent.getPosition;
                    _spriteBatch.Draw(_tex, new Rectangle((int)_pos.X, (int)_pos.Y, _tex.Width, _tex.Height), Color.White);
                   
                }
            }
            _spriteBatch.End();

            _townDisplay.Draw(gameTime);
            _factDisplay.Draw(gameTime);
            _roadRender.Draw(gameTime);
            _statDisplay.Draw(gameTime);
        }
    }
}
