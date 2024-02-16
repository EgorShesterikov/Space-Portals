using UnityEngine;
using TMPro;

namespace SpacePortals
{
    public class TimeIndicationView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeText;

        public TextMeshProUGUI TimeText => _timeText;
    }
}
