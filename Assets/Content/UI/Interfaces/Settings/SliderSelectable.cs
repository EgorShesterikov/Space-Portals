﻿using UniRx;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SpacePortals
{
    public class SliderSelectable : Slider
    {
        private bool _isTouching = false;

        public ReactiveCommand PonterUp = new();
        public ReactiveCommand PointerDown = new();
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

            PonterUp.Execute();

            base.OnPointerUp(eventData);
        }
    }
}