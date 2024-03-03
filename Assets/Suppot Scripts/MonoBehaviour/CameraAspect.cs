using UnityEngine;

namespace SpacePortals
{
    public class CameraAspect : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _aspect;

        public void Update()
        {
            float width = (Screen.height * _aspect) / Screen.width;
            float viewPortX = (1 - width) / 2f;

            _camera.rect = new Rect(viewPortX, 0, width, 1);
        }
    }
}
