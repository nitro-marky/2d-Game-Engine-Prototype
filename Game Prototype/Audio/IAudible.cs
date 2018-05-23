using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Prototype.Audio
{
    interface IAudible
    {
        IAudioComponent getAudioComponent { get; }
    }
}
