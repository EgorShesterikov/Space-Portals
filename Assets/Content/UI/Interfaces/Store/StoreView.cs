using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SpacePortals
{
    public class StoreView : WindowsBase, IDisposable
    {
        [SerializeField] private TextMeshProUGUI _nameBallText;
        [SerializeField] private Image _ballImage;
        [SerializeField] private Button _selectButton;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public ReactiveCommand OnClickedSelectButton = new();

        public TextMeshProUGUI NameBallText => _nameBallText;
        public Image BallImage => _ballImage;

        public void Awake()
        {
            _selectButton.OnClickAsObservable().Subscribe(_ =>
            {
                ShakeAnimButton(_selectButton);
                OnClickedSelectButton.Execute();
            }).AddTo(_disposables);
        }

        public void Dispose()
            => _disposables.Dispose();
    }
}