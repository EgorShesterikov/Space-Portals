using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using YG;

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

        public ReactiveCommand OnClickedSelectButton { get; private set; } = new();

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

            string ballText;
            if (YandexGame.lang == "ru")
            {
                switch(type)
                {
                    case BallTypes.Default:
                        ballText = "��������";
                        break;

                    case BallTypes.Magma:
                        ballText = "�����";
                        break;

                    case BallTypes.Rubber:
                        ballText = "������";
                        break;

                    case BallTypes.Clow:
                        ballText = "�����";
                        break;

                    case BallTypes.Bigger:
                        ballText = "�������";
                        break;

                    case BallTypes.Speedy:
                        ballText = "������";
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                ballText = type.ToString();
            }

            _nameBallText.text = ballText;
            _ballImage.sprite = ball.BallSprite;
        }

        public void DisplayCostInBuyButton(int value)
        {
            string starsText;

            if(YandexGame.lang == "ru")
                starsText = $"������: {value}";
            else
                starsText = $"Stars: {value}";


            _selectButtonText.text = starsText;
        }
        public void DisplaySelectInBuyButton()
        {
            string selectText;

            if (YandexGame.lang == "ru")
                selectText = "�������";
            else
                selectText = "Select";

            _selectButtonText.text = selectText;
        }
    }
}