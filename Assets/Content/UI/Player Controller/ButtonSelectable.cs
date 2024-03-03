using UniRx;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SpacePortals
{
    public class ButtonSelectable : Button
    {
        private bool _isTouching = false;

        public ReactiveCommand PointerUp { get; private set; } = new();
        public ReactiveCommand PointerDown { get; private set; } = new();
        public bool IsTouching => _isTouching;

        public override void OnPointerDown(PointerEventData eventData)
        {
            _isTouching = true;

            PointerDown.Execute();

            base.OnPointerDown(eventData);
        }
        public override void OnPointerUp(PointerEventData eventData)
        {
            _isTouching = false;

            PointerUp.Execute();

            base.OnPointerUp(eventData);
        }
    }
}
