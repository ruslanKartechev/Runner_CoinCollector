﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonGame.Sound;
namespace CommonGame.Sound
{
    public class MySoundPlayer : MonoBehaviour, ISoundEffect
    {
        public SoundNames _sound;
        public SoundFXChannelSO _soundChannel;

        public void PlayEffectOnce()
        {
            _soundChannel.RaiseEventPlay(_sound.ToString());
        }

        public void StartEffect()
        {
            _soundChannel.RaiseEventStartLoop(_sound.ToString());
        }

        public void StopEffect()
        {
            _soundChannel.RaiseEventStopLoop(_sound.ToString());
        }
    }
}