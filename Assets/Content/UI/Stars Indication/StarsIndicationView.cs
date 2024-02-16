using UnityEngine;
using TMPro;

namespace SpacePortals
{
    public class StarsIndicationView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _starsCountText;

        public TextMeshProUGUI StarsCountText => _starsCountText;
    }
}