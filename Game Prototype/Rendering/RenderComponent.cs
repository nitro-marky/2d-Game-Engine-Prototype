using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;

namespace Game_Prototype.Rendering
{
    //The render component provides the render manager with the texture and position of the entity.

    class RenderComponent : IRenderComponent
    {
        private Texture2D _texture;
        private IEntity _parent;

        public RenderComponent(IEntity parent)
        {
            _parent = parent;
        }


        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        public Vector2 getPosition
        {
            get { return _parent.getPosition; }
        }
    }
}
