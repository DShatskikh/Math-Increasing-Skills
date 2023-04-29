using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Math
{
    public class Lerp : MonoBehaviour
    {
        [Range(0, 1)]
        public float Slider;

        public Transform TransformMove;
        public TextMeshProUGUI Text;
        public Slider Slider1;

        private void OnEnable()
        {
            Slider1.onValueChanged.AddListener(UpdateSlider);
        }

        private void Update()
        {
            var lerpedVal = Mathf.Lerp(-2, 2, Slider);
            TransformMove.position = new Vector3(lerpedVal, 0, 0);
            Text.text = $"Min: -2, Max: 2, Slider: {Slider}";
        }

        private void UpdateSlider(float value)
        {
            Slider = value;
        }
    }
}