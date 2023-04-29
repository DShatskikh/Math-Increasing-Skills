using System;
using TMPro;
using UnityEngine;

namespace Math
{
    public class Approximately : MonoBehaviour
    {
        public float A;
        public float B;

        public TextMeshProUGUI _text;

        private void OnEnable()
        {
            PrintApproximately();
        }

        public void PrintApproximately()
        {
            _text.text = $"Approximately\nA({A}) and B({B})\n{Mathf.Approximately(A, B)}";
            print("Approximately A B = " + Mathf.Approximately(A, B));
        }
    }
}
