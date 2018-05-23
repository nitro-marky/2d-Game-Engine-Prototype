using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;
using Game_Prototype.Game_Implementation;
using Game_Prototype.Utilities;

//Renders the road connections between the towns.
namespace Game_Prototype.Game_Logic
{
    class RoadRenderer : IRoadRenderer
    {
        private List<ITownEntity> _townList;
        private SpriteBatch _spriteBatch;
        private Texture2D _roadTexture;
        private Texture2D _town;
        private List<Vector2> _roadVectors;
        private List<Rectangle> _roadRect;
        private List<float> _roadAngles;

        public RoadRenderer()
        {
            _townList = new List<ITownEntity>();
            _roadVectors = new List<Vector2>();
            _roadRect = new List<Rectangle>();
            _roadAngles = new List<float>();
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _roadTexture = ContentService.content.Load<Texture2D>("road");
            _town = ContentService.content.Load<Texture2D>("town");
        }

        public void UpdateEntities(List<IEntity> list)
        {
            _townList.Clear();
            foreach (IEntity entity in list)
            {
                if (entity is ITownEntity)
                {
                    _townList.Add((ITownEntity)entity);
                }
            }
    
        }


        //The draw function checks the distances and draws the roads if the distance conditions are met.
        public void Draw(GameTime gameTime)
        {
            if (_townList.Count > 0)
            {
                for (int i = 0; i < _townList.Count; i++)
                {
                    Vector2 _start = _townList[i].getTownComponent.Position;
                    List<IEntity> _connectedTowns = new List<IEntity>();

                    for (int j = 0; j < _townList.Count; j++)
                    {
                        if (_townList[i] == _townList[j])
                        {
                            break;
                        }
                        else
                        {
                            int _tempX = (int)_townList[i].getTownComponent.Position.X - (int)_townList[j].getTownComponent.Position.X;
                            int _tempY = (int)_townList[i].getTownComponent.Position.Y - (int)_townList[j].getTownComponent.Position.Y;

                            if ((_tempX < 275 && _tempX > -275) && (_tempY < 275 && _tempY > -275))
                            {
                                Vector2 _end = _townList[j].getTownComponent.Position;
                                Vector2 _direction = _end - _start;
                                float _distance;
                                Vector2.Distance(ref _start, ref _end, out _distance);
                                var _angle = (float)Math.Atan2(_direction.Y, _direction.X);

                                int _x = (int)_start.X + (_town.Width / 2);
                                int _y = (int)_start.Y + (_town.Height / 2);
                                Vector2 newStart = new Vector2(_x, _y);
                                Rectangle _rect = new Rectangle(_x, _y, (int)_distance, 1);
                                _roadVectors.Add(newStart);
                                _roadRect.Add(_rect);
                                _roadAngles.Add(_angle);
                            }
                        }
                    }

                }

                for (int m = 0; m < _roadVectors.Count; m++)
                {
                    _spriteBatch.Begin();
                    _spriteBatch.Draw(_roadTexture, _roadVectors[m], _roadRect[m], Color.White, _roadAngles[m], Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                    _spriteBatch.End();

                }
            }
           
        }
    }
}
