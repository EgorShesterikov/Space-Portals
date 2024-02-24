using DG.Tweening;
using TMPro;
using UnityEngine;

namespace SpacePortals
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tutorialText;
        [SerializeField] private Transform _targetSpawn;

        private Sequence _sequence;

        public void SpawnTutorial()
        {
            TextMeshProUGUI tutorialText = Instantiate(_tutorialText, _targetSpawn);

            _sequence = DOTween.Sequence();

            _sequence.Append(tutorialText.DOColor(Color.white, 1))
                .AppendInterval(5)
                .Append(tutorialText.DOColor(Color.clear, 1)
                .SetLink(tutorialText.gameObject)
                .OnComplete(() => Destroy(tutorialText.gameObject))
                .SetAutoKill(true));
        }
    }
}