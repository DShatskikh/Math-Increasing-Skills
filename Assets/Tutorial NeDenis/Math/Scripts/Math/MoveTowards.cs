using System;
using MrAutofire;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Math
{
    public class MoveTowards : MonoBehaviour
    {
        [Range(0, 1)]
        public float Slider;

        public float Speed;
        public Transform TransformMove;
        public TextMeshProUGUI Text;
        public Slider Slider1;

        private void OnEnable()
        {
            Slider1.onValueChanged.AddListener(UpdateSlider);
        }

        private void OnDisable()
        {
            Slider1.onValueChanged.RemoveListener(UpdateSlider);
        }

        private void Update()
        {
            var xCoord = Mathf.MoveTowards(TransformMove.position.x, (Slider - 0.5f) * 4f, Time.deltaTime * Speed);
            TransformMove.position = TransformMove.position.SetX(xCoord);
            Text.text = $"Min: -2, Max: 2, Slider: {Slider}";
        }
        
        private void UpdateSlider(float value)
        {
            Slider = value;
        }
    }
}