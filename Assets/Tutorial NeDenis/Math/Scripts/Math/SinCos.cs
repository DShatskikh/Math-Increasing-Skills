using System;
using MrAutofire;
using UnityEngine;
using UnityEngine.UI;

namespace Math
{
    public class SinCos : MonoBehaviour
    {
        public float Speed;
        public float Radius;
        public Transform TransformMove;

        public Slider RadiusSlader;
        public Slider SpeedSlader;

        private float _sizeLine;

        private void OnEnable()
        {
            RadiusSlader.onValueChanged.AddListener(UpdateRadius);
            SpeedSlader.onValueChanged.AddListener(UpdateSpeed);
        }

        private void OnDisable()
        {
            RadiusSlader.onValueChanged.RemoveListener(UpdateRadius);
            SpeedSlader.onValueChanged.RemoveListener(UpdateSpeed);
        }

        private void Start()
        {
            RadiusSlader.value = 0.5f;
            SpeedSlader.value = 0.2f;
        }

        private void Update()
        {
            _sizeLine += Time.deltaTime * Speed;

            var x = Mathf.Sin(_sizeLine) * Radius;
            var y = Mathf.Cos(_sizeLine) * Radius;

            TransformMove.position = TransformMove.position.SetX(x).SetY(y);
        }

        private void UpdateRadius(float value)
        {
            Radius = Mathf.Lerp(0, 2.746659f, value);
        }
        
        private void UpdateSpeed(float value)
        {
            Speed = Mathf.Lerp(0, 10, value);
        }
    }
}