using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Input;
using Game_Prototype.Rendering;
using Microsoft.Xna.Framework;
using Game_Prototype.Utilities;
using Microsoft.Xna.Framework.Graphics;

/**
 * The entity representing the easy icon in the start menu.
 * It implements interfaces which make it renderable, observant to mouse clicks + hovering and allows audio to be played.
 */
namespace Game_Prototype.Entities.MenuItems
{
    class MediumGUI : GameEntity, IHoverObserver, IClickObserver, IRenderable
    {
        private IRenderComponent _renderComponent;
        private IInputComponent _inputComponent;
        private Rectangle _boundingBox;


        //A bounding box is created in intialise to check for input using collision detection with the mouse position.
        public override void Initialise()
        {
            _renderComponent = new RenderComponent(this);
            _renderComponent.Texture = ContentService.content.Load<Texture2D>("moderate_menu");
            _boundingBox = new Rectangle((int)this._position.X, (int)this._position.Y, _renderComponent.Texture.Width, _renderComponent.Texture.Height);
            _inputComponent = new InputComponent(this);

            base.Initialise();
        }

        //The update loop is used to check whether the mouse is hovering over it, if so the texture is changed 
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (_inputComponent.Hovering)
            {
                _renderComponent.Texture = ContentService.content.Load<Texture2D>("moderate_menu_highlight");
            }
            else if (!_inputComponent.Hovering)
            {
                _renderComponent.Texture = ContentService.content.Load<Texture2D>("moderate_menu");
            }

        }

        public IRenderComponent getRenderComponent
        {
            get { return _renderComponent; }
        }

        public Rectangle getBoundingBox
        {
            get { return _boundingBox; }
        }

        public void NotifyClick(InputType type, int ID)
        {
            if (this._UID == ID)
            {
                Console.WriteLine("Clicked Medium");
                _inputComponent.Clicked = true;
            }
        }

        public IInputComponent getInputComponent
        {
            get { return _inputComponent; }
        }


        public void NotifyHover(bool hovering, int ID)
        {
            if (this._UID == ID)
            {
                _inputComponent.Hovering = hovering;
            }
        }


    }
}
