using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Prototype.Entity_Control;
using Game_Prototype.Entities;
using Microsoft.Xna.Framework;

/**
 * The audio manager is responsible for controlling when entites should play their soundeffects. The audio manager is
 * an entity observer and searches through the list for IAudible entities i.e. entities with sounds.
 */
namespace Game_Prototype.Audio
{
    class AudioManager : IAudioManager, IEntityObserver
    {
        private List<IAudible> _audibleEntities;

        public AudioManager()
        {
            _audibleEntities = new List<IAudible>();
        }

        public void EntityNotified(List<IEntity> list)
        {

            _audibleEntities.Clear();
            
            foreach (IEntity entity in list)
            {
               
                if (entity is IAudible)
                {
                    _audibleEntities.Add((IAudible)entity);
                }
            }
        }

        //The update loop is used to check whether the entities sound bool is true and then calls the PlayAudio function from the
        //IAudioComponent interface.
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < _audibleEntities.Count; i++)
            {
                if (_audibleEntities[i].getAudioComponent.TimeForSound)
                {
                    _audibleEntities[i].getAudioComponent.PlayAudio();
                    _audibleEntities[i].getAudioComponent.TimeForSound = false;
                }
            }
        }
    }
}
