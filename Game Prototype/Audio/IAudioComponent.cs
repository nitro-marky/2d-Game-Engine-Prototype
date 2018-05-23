using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

//All entites that implemented the IAudible interface need to contain an IAudioComponent.
namespace Game_Prototype.Audio
{
    interface IAudioComponent
    {
        bool TimeForSound { get; set; }

        void PlayAudio();

        void SoundEffect(SoundEffect sound);

    }
}
