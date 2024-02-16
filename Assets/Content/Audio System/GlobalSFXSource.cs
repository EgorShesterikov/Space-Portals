using UnityEngine;

namespace SpacePortals
{
    [RequireComponent(typeof(AudioSource))]
    public class GlobalSFXSource : MonoBehaviour
    {
        [SerializeField] private AudioClip _sfxUIClick;
        [SerializeField] private AudioClip _sfxUILock;

        private AudioSource _sfxUISource;

        public void Awake() 
            => _sfxUISource = GetComponent<AudioSource>();

        public void PlayClick()
            => _sfxUISource.PlayOneShot(_sfxUIClick);
        public void PlayLock() 
            => _sfxUISource.PlayOneShot(_sfxUILock);
    }
}
