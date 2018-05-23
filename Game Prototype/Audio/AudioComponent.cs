using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Game_Prototype.Entities;

/**
 * The audio component stores the sound that needs to be played for the parent entity.
 * Whether a sound needs to be played or not is controlled by a bool which is detected within audio manager.
 */
namespace Game_Prototype.Audio
{
    class AudioComponent : IAudioComponent
    {
        private SoundEffect _sound;
        private IEntity _parent;
        private bool _playSound;

        public AudioComponent(IEntity parent)
        {
            _parent = parent;
        }

        public bool TimeForSound
        { get { return _playSound; } set { _playSound = value; } }

        public void PlayAudio()
        {
            if (_sound != null)
            {
                _sound.Play();
            }
        }

        public void SoundEffect(SoundEffect sound)
        {
            _sound = sound;
        }
    }
}
