using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace SpacePortals
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class WindowsBase : MonoBehaviour
    {
        private const float SHAKE_BUTTON_DURATION = 0.25f;
        private const float SHAKE_BUTTON_STENGHT = 0.15f;

        private const float OPEN_CLOSE_DURATION = 0.5f;
        private const float OPEN_CLOSE_POSITION_X = 500f;
        private Vector3 OPEN_CLOSE_ROTATION = new Vector3(0, 0, 45);

        protected CanvasGroup _canvasGroup;
        protected RectTransform _rectTransform;

        protected Sequence _sequence;

        public virtual void Open() 
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();

            _sequence.SetUpdate(true)
                .PrependCallback(() =>
                {
                    _canvasGroup.blocksRaycasts = false;
                    _canvasGroup.alpha = 0;

                    _rectTransform.anchoredPosition = new Vector3(-OPEN_CLOSE_POSITION_X, 0, 0);
                    transform.rotation = Quaternion.Euler(OPEN_CLOSE_ROTATION * -1);
                    transform.localScale = Vector3.zero;

                    gameObject.SetActive(true);
                })
                .Append(_canvasGroup.DOFade(1, OPEN_CLOSE_DURATION).SetEase(Ease.InCirc))
                .Join(transform.DOScale(1, OPEN_CLOSE_DURATION).SetEase(Ease.InCirc))
                .Join(transform.DORotate(OPEN_CLOSE_ROTATION, OPEN_CLOSE_DURATION, RotateMode.LocalAxisAdd).SetEase(Ease.InCirc))
                .Join(transform.DOLocalMoveX(0, OPEN_CLOSE_DURATION).SetEase(Ease.InCirc))
                .AppendCallback(() => _canvasGroup.blocksRaycasts = true);
        }
        public virtual void Close() 
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();

            _sequence.SetUpdate(true)
                .PrependCallback(() =>
                {
                    _canvasGroup.blocksRaycasts = false;
                    _canvasGroup.alpha = 1;

                    _rectTransform.anchoredPosition = Vector3.zero;
                    transform.rotation = Quaternion.identity;
                    transform.localScale = Vector3.one;

                    gameObject.SetActive(true);
                })
                .Append(_canvasGroup.DOFade(0, OPEN_CLOSE_DURATION).SetEase(Ease.InCirc))
                .Join(transform.DOScale(0, OPEN_CLOSE_DURATION).SetEase(Ease.InCirc))
                .Join(transform.DORotate(OPEN_CLOSE_ROTATION * -1, OPEN_CLOSE_DURATION, RotateMode.LocalAxisAdd).SetEase(Ease.InCirc))
                .Join(transform.DOLocalMoveX(OPEN_CLOSE_POSITION_X, OPEN_CLOSE_DURATION).SetEase(Ease.InCirc))
                .AppendCallback(() => gameObject.SetActive(false));
        }

        protected void ShakeAnimButton(Button obj)
        {
            obj.transform
                    .DOShakeScale(SHAKE_BUTTON_DURATION, SHAKE_BUTTON_STENGHT)
                    .SetUpdate(true)
                    .OnComplete(() => { obj.transform.DOScale(Vector3.one, SHAKE_BUTTON_DURATION); });
        }

        private void OnValidate()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _rectTransform = GetComponent<RectTransform>();
        }
    }
}
