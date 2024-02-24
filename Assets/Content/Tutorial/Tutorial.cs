using DG.Tweening;
using TMPro;
using UnityEngine;

namespace SpacePortals
{
    public class Tutorial : MonoBehaviour
    {
        private const float LIFE_TIME_TUTORIAL = 5;

        [SerializeField] private TextMeshProUGUI _tutorialText;
        [SerializeField] private Transform _targetSpawn;

        private Sequence _sequence;

        public void SpawnTutorial()
        {
            TextMeshProUGUI tutorialText = Instantiate(_tutorialText, _targetSpawn);

            _sequence = DOTween.Sequence();

            _sequence.Append(tutorialText.DOColor(Color.white, 1))
                .AppendInterval(LIFE_TIME_TUTORIAL)
                .Append(tutorialText.DOColor(Color.clear, 1)
                .SetLink(tutorialText.gameObject)
                .OnComplete(() => Destroy(tutorialText.gameObject))
                .SetAutoKill(true));
        }
    }
}