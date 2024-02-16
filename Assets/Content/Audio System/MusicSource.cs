using UnityEngine;
using System;

namespace SpacePortals
{
    [RequireComponent(typeof(AudioSource))]
    public partial class MusicSource : MonoBehaviour
    {
        [SerializeField] private TypesMusic _startMusic = TypesMusic.Default;

        [Space]
        [SerializeField] private AudioClip _defaultMusic;
        [SerializeField] private AudioClip _playMusic;
        [SerializeField] private AudioClip _resultMusic;

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

                case TypesMusic.Play:
                    _musicSource.clip = _playMusic;
                    break;

                case TypesMusic.Result:
                    _musicSource.clip = _resultMusic;
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
