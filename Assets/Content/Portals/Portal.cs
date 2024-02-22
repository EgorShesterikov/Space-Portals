using DG.Tweening;
using UnityEngine;

namespace SpacePortals
{
    public class Portal : MonoBehaviour
    {
        private const float ANIM_DURATION = 2f;
        private const float PORTAL_PUNCH_POWER = 0.0035f;

        [SerializeField] private SpriteRenderer _spritePortal;

        private Sequence _sequence;

        public void Start()
        {
            _sequence = DOTween.Sequence();

            _sequence.SetUpdate(true)
                .Append(_spritePortal.transform.DORotate(Vector3.forward * 360 * GetRandomDirectionOfRotation(), ANIM_DURATION, RotateMode.LocalAxisAdd)
                    .SetEase(Ease.Linear))
                .Join(_spritePortal.transform.DOPunchScale(Vector3.one * PORTAL_PUNCH_POWER, ANIM_DURATION, 0, 0)
                    .SetEase(Ease.InOutQuart))
                .SetLoops(-1);
        }

        public void ShakeAnimPortal()
            => _spritePortal.transform.DOShakeScale(0.1f, 0.01f);

        private int GetRandomDirectionOfRotation()
        {
            if (Random.Range(0, 2) == 0)
                return -1;
            else
                return 1;
        }
    }
}