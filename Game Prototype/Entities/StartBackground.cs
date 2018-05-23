using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Rendering;
using Game_Prototype.Utilities;
using Microsoft.Xna.Framework.Graphics;

//Entity representing the start menu background, it only needs to implement the IRenderable interface.
namespace Game_Prototype.Entities
{
    class StartBackground : GameEntity, IRenderable
    {
        private IRenderComponent _renderComponent;

        public override void LoadContent()
        {
            this._texture = ContentService.content.Load<Texture2D>("startBackground");
        }

        public override void Initialise()
        {
            _renderComponent = new RenderComponent(this);
            _renderComponent.Texture = this._texture;
        }

        public IRenderComponent getRenderComponent
        {
            get { return _renderComponent; }
        }
    }
}
