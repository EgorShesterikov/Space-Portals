using System;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;

namespace SpacePortals
{
    public class AudioSystem
    {
        private const float AUDIO_VOLUME_MULTIPLICATOR = 20f;

        private const string AUDIO_MUSIC_VOLUME_PARAM = "MusicVol";
        private const string AUDIO_SFX_VOLUME_PARAM = "SFXVol";
        private const string AUDIO_PATH_FOLDER = "Audio";
        private const string AUDIO_PATH_NAME = "AudioMixer";

        private AudioMixer _audioMixer;

        public AudioSystem()
            => Load();

        public void ChangeAudioMixerVolumeMusic(float volume)
            => _audioMixer.SetFloat(AUDIO_MUSIC_VOLUME_PARAM, VolumeToDecibels(volume));

        public void ChangeAudioMixerVolumeSFX(float volume)
            => _audioMixer.SetFloat(AUDIO_SFX_VOLUME_PARAM, VolumeToDecibels(volume));

        private void Load()
            => _audioMixer = Resources.Load<AudioMixer>(Path.Combine(AUDIO_PATH_FOLDER, AUDIO_PATH_NAME));

        private float VolumeToDecibels(float volume)
            => (float)(Math.Log10(volume) * AUDIO_VOLUME_MULTIPLICATOR);
    }
}
