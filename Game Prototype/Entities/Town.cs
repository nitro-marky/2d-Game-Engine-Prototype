using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Rendering;
using Game_Prototype.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Game_Prototype.Input;
using Microsoft.Xna.Framework;
using Game_Prototype.Game_Implementation;
using Game_Prototype.Audio;
using Microsoft.Xna.Framework.Audio;

/**
 *  The Town entity is what the user will interact with the most.  
 */
namespace Game_Prototype.Entities
{
    class Town : GameEntity, IRenderable, IClickObserver, ITownEntity, IAudible
    {
        //Components needed for rendering and input management
        private IRenderComponent _renderComponent;
        private IInputComponent _inputComponent;
        private IAudioComponent _audioComponent;
        
        private ITownUtility _townUtility;
        private ITownDetails _townComponent;

        //Fields needed for rendering and input collision detection.
        private Rectangle _boundingBox;
        private Texture2D _vaccinatedTex;
        private Texture2D _infectedTex;

        private SoundEffect _sound;


        public Town()
        {

        }

        //Loads the textures and sounds.
        public override void LoadContent()
        {
            this._texture = ContentService.content.Load<Texture2D>("town");
            _vaccinatedTex = ContentService.content.Load<Texture2D>("blue_town");
            _infectedTex = ContentService.content.Load<Texture2D>("red_town");
            _sound = ContentService.content.Load<SoundEffect>("clickSound");
        }

        //Sets up the components as well as the starting position of the town.
        public override void Initialise()
        {
            _renderComponent = new RenderComponent(this);
            _renderComponent.Texture = this._texture;
            _inputComponent = new InputComponent(this);
            _townComponent = new TownComponent(this);
            _townUtility = new TownProperties(this);
            _audioComponent = new AudioComponent(this);
            _audioComponent.SoundEffect(_sound);
            
            _townComponent.TownName = _townUtility.getName;
            _townComponent.Population = _townUtility.getPopulation;
            this.setPosition(_townUtility.getPosition);
            _townComponent.setPosition(this.getPosition);
            _boundingBox = new Rectangle((int)this._position.X, (int)this._position.Y, _renderComponent.Texture.Width, _renderComponent.Texture.Height);
            base.Initialise();
        }

        public IRenderComponent getRenderComponent
        {
            get { return _renderComponent; }
        }

        public Rectangle getBoundingBox
        {
            get { return _boundingBox; }
        }

        public ITownDetails getTownComponent
        {
            get { return _townComponent; }
        }

        //The majority of the entity logic is carried out on input rather than through constant polling in the update.
        public void NotifyClick(InputType type, int ID)
        {
            //Ensures that if another town is right clicked this town won't be visible in the town display.
            if (type == InputType.right_click && this._UID != ID)
            {
                _townComponent.Active = false;
            }

            
            //If this entity was clicked (based on the ID) the input type is checked
            if (this._UID == ID)
            {
                //On a left click the town is vaccinated, the sound bool is set and the turn counter is increased in StatManager.
                if (type == InputType.left_click)
                {
                    if (_townComponent.Vaccinated == false && _townComponent.Infected == false)
                    {
                        _townComponent.Vaccinated = true;
                        _townComponent.StatusChange = true;
                        _townComponent.Infected = false;
                        _audioComponent.TimeForSound = true;
                        StatManager._instance.counter++;
                    }
                }//On a right click the town is set to active which will display it's properties on screen.
                else if (type == InputType.right_click)
                {
                    _townComponent.Active = true;
                }


                if (_inputComponent.Clicked == true)
                {
                    _inputComponent.Clicked = false;
                }
                else if (_inputComponent.Clicked == false)
                {
                    _inputComponent.Clicked = true;
                }
            }
        }

        //All that is checked in the update is it's vaccinated or infected status as this determines which texture to use.
        public override void Update(GameTime gameTime)
        {
            if (_townComponent.Vaccinated)
            {
                _renderComponent.Texture = _vaccinatedTex;
            }
            else if (_townComponent.Infected)
            {
                _renderComponent.Texture = _infectedTex;
            }

            _townComponent.Update(gameTime);
            base.Update(gameTime);
        }

        public IInputComponent getInputComponent
        {
            get { return _inputComponent; }
        }

        public IAudioComponent getAudioComponent
        {
            get { return _audioComponent; }
        }
    }
}
