using UnityEngine;
using System;

namespace SpacePortals
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicSource : MonoBehaviour
    {
        [SerializeField] private TypesMusic _startMusic = TypesMusic.Default;

        [Space]
        [SerializeField] private AudioClip _defaultMusic;

        private AudioSource _musicSource;

        public void PlayMusic(TypesMusic typeMusic)
        {
            switch (typeMusic)
            {
                case TypesMusic.None:
                    break;

                case TypesMusic.Default:
                    _musicSource.clip = _defaultMusic;
                    break;

                default:
                    throw new ArgumentException(nameof(typeMusic));
            }

            _musicSource.Play();
        }

        private void Awake()
        {
            _musicSource = GetComponent<AudioSource>();

            PlayMusic(_startMusic);
        }
    }
}
