using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Rendering;
using Game_Prototype.Input;
using Microsoft.Xna.Framework;
using Game_Prototype.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Game_Prototype.Audio;
using Microsoft.Xna.Framework.Audio;

/**
 * The entity representing the easy icon in the start menu.
 * It implements interfaces which make it renderable, observant to mouse clicks + hovering and allows audio to be played.
 */
namespace Game_Prototype.Entities.MenuItems
{
    class EasyGUI : GameEntity, IRenderable, IClickObserver, IHoverObserver, IAudible
    {
        private IRenderComponent _renderComponent;
        private IInputComponent _inputComponent;
        private Rectangle _boundingBox;
        private IAudioComponent _audioComponent;
        private SoundEffect _sound;

        public override void LoadContent()
        {
            this._texture = ContentService.content.Load<Texture2D>("easy_menu");
            _sound = ContentService.content.Load<SoundEffect>("clickSound");
        }

        //A bounding box is created in intialise to check for input using collision detection with the mouse position.
        public override void Initialise()
        {
            _renderComponent = new RenderComponent(this);
            _renderComponent.Texture = this._texture;
            _boundingBox = new Rectangle((int)this._position.X, (int)this._position.Y, _renderComponent.Texture.Width, _renderComponent.Texture.Height);
            _inputComponent = new InputComponent(this);
            _audioComponent = new AudioComponent(this);
            _audioComponent.SoundEffect(_sound);
            base.Initialise();
        }

        //The update loop is used to check whether the mouse is hovering over it, if so the texture is changed 
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            if (_inputComponent.Hovering)
            {
                _renderComponent.Texture = ContentService.content.Load<Texture2D>("easy_menu_highlight");
            }
            else if (!_inputComponent.Hovering)
            {
                _renderComponent.Texture = ContentService.content.Load<Texture2D>("easy_menu");
            }
        }

        public IRenderComponent  getRenderComponent
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
                _inputComponent.Clicked = true;
                _audioComponent.TimeForSound = true;
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

        public IAudioComponent getAudioComponent
        {
            get { return _audioComponent; }
        }
    }
}
