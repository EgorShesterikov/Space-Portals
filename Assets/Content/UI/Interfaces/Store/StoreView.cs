using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SpacePortals
{
    public class StoreView : WindowsBase, IDisposable
    {
        [SerializeField] private TextMeshProUGUI _nameBallText;
        [SerializeField] private TextMeshProUGUI _selectButtonText;
        [SerializeField] private Image _ballImage;
        [SerializeField] private Button _selectButton;

        private CompositeDisposable _disposables = new CompositeDisposable();

        private BallFactoryConfig _config;

        [Inject]
        public void Constructor(BallFactoryConfig config)
            => _config = config;

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

        public void DisplaySkinAndNameBall(BallTypes type)
        {
            Ball ball = _config.FindTypeBall(type);

            _nameBallText.text = type.ToString();
            _ballImage.sprite = ball.BallSprite;
        }

        public void DisplayCostInBuyButton(int value)
            => _selectButtonText.text = $"Stars: {value}";

        public void DisplaySelectInBuyButton()
            => _selectButtonText.text = "Select";
    }
}