using UnityEngine;

namespace SpacePortals
{
    [RequireComponent(typeof(AudioSource))]
    public class GlobalSFXSource : MonoBehaviour
    {
        [Header("Global UI")]
        [SerializeField] private AudioClip _sfxUIClick;
        [SerializeField] private AudioClip _sfxUILock;

        [Header("Store")]
        [SerializeField] private AudioClip _sfxUIBay;

        [Header("Play")]
        [SerializeField] private AudioClip _startGame;
        [SerializeField] private AudioClip _gameOver;

        private AudioSource _sfxUISource;

        public void Awake() 
            => _sfxUISource = GetComponent<AudioSource>();

        public void PlayClick()
            => _sfxUISource.PlayOneShot(_sfxUIClick);
        public void PlayLock() 
            => _sfxUISource.PlayOneShot(_sfxUILock);

        public void PlayBay()
            => _sfxUISource.PlayOneShot(_sfxUIBay);

        public void PlayStartGame()
            => _sfxUISource.PlayOneShot(_startGame);
        public void PlayGameOver()
            => _sfxUISource.PlayOneShot(_gameOver);
    }
}
