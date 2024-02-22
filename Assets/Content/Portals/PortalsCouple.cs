using DG.Tweening;
using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace SpacePortals
{
    public class PortalsCouple : MonoBehaviour, IDisposable
    {
        [SerializeField] private Portal _firstPortal;
        [SerializeField] private Portal _secondPortal;

        private CompositeDisposable _disposable = new CompositeDisposable();

        public Transform FirstPortalTransform => _firstPortal.transform;
        public Transform SecondPortalTransform => _secondPortal.transform;

        public void Awake()
        {
            _firstPortal.OnTriggerEnter2DAsObservable()
                .Subscribe(collision =>
                {
                    if(collision.TryGetComponent<IEnterInPortals>(out var enterObject))
                    {
                        if(enterObject.YVelocity > 0 && enterObject.IsTransformInPortal == false)
                        {
                            enterObject.ActionInEnter();

                            float originalScale = enterObject.Rigidbody2D.transform.localScale.x;
                            float animDuration = GetTimeTransformObjectInPortal(enterObject, _firstPortal);

                            var sequence = DOTween.Sequence();

                            sequence.Append(enterObject.Rigidbody2D.transform.DOScale(0, animDuration))
                                    .Join(enterObject.Rigidbody2D.transform.DOLocalMove(_firstPortal.transform.position, animDuration)
                                        .OnComplete(() => {
                                            _firstPortal.ShakeAnimPortal();
                                            _secondPortal.ShakeAnimPortal();

                                            if (enterObject != null)
                                            {
                                                enterObject.Rigidbody2D.transform.position = _secondPortal.transform.position;
                                                enterObject.ActionInExit();
                                            }
                                        }))
                                    .Append(enterObject.Rigidbody2D.transform.DOScale(originalScale, animDuration))
                                    .SetLink(enterObject.Rigidbody2D.gameObject);
                        }
                    }
                }).AddTo(_disposable);

            _secondPortal.OnTriggerEnter2DAsObservable()
                .Subscribe(collision =>
                {
                    if (collision.TryGetComponent<IEnterInPortals>(out var enterObject))
                    {
                        if (enterObject.YVelocity < 0 && enterObject.IsTransformInPortal == false)
                        {
                            enterObject.ActionInEnter();

                            float originalScale = enterObject.Rigidbody2D.transform.localScale.x;
                            float animDuration = GetTimeTransformObjectInPortal(enterObject, _secondPortal);

                            var sequence = DOTween.Sequence();

                            sequence.Append(enterObject.Rigidbody2D.transform.DOScale(0, animDuration))
                                    .Join(enterObject.Rigidbody2D.transform.DOLocalMove(_secondPortal.transform.position, animDuration)
                                        .OnComplete(() => {
                                            _firstPortal.ShakeAnimPortal();
                                            _secondPortal.ShakeAnimPortal();

                                            if (enterObject != null)
                                            {
                                                enterObject.Rigidbody2D.transform.position = _firstPortal.transform.position;
                                                enterObject.ActionInExit();
                                            }
                                        }))
                                    .Append(enterObject.Rigidbody2D.transform.DOScale(originalScale, animDuration))
                                    .SetLink(enterObject.Rigidbody2D.gameObject);
                        }
                    }
                }).AddTo(_disposable);
        }

        public void Dispose()
            => _disposable.Dispose();

        private float GetTimeTransformObjectInPortal(IEnterInPortals enterObject, Portal portal)
        {
            float distance = Vector3.Distance(enterObject.Rigidbody2D.transform.position, portal.transform.position);
            return distance / Math.Abs(enterObject.YVelocity);
        }
    }
}