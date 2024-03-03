using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpacePortals
{
    public class ResultMenuView : WindowsBase, IDisposable
    {
        [SerializeField] private Button _backMainMenuButton;

        [Space]
        [SerializeField] private TextMeshProUGUI _currentTimeText;
        [SerializeField] private TextMeshProUGUI _collectedStarsText;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public ReactiveCommand OnClickedBackMainMenuButton { get; private set; } = new();

        public TextMeshProUGUI CurrentTimeText => _currentTimeText;
        public TextMeshProUGUI CollectedStarsText => _collectedStarsText;

        public void Awake()
        {
            _backMainMenuButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    ShakeAnimButton(_backMainMenuButton);
                    OnClickedBackMainMenuButton.Execute();
                }).AddTo(_disposables);
        }

        public void Dispose()
            => _disposables.Dispose();
    }
}