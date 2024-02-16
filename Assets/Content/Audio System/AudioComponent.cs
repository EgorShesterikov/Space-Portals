using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpacePortals
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioComponent : MonoBehaviour
    {
        [SerializeField] private List<Sound> _soundsCollection;

        private AudioSource _audioSource;

        public void Awake()
            => _audioSource = GetComponent<AudioSource>();

        public void PlaySound(string nameSound)
        {
            Sound sound = _soundsCollection.Find((sound) => sound.Name == nameSound);

            if (sound != null)
                _audioSource.PlayOneShot(sound.Clip);
            else
                throw new NotImplementedException();
        }

        [Serializable]
        private class Sound
        {
            [SerializeField] private string _name;
            [SerializeField] private AudioClip _clip;

            public string Name => _name;
            public AudioClip Clip => _clip;
        }
    }
}
