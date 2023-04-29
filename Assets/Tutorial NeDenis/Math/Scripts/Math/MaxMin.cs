using System;
using TMPro;
using UnityEngine;

namespace Math
{
    public class MaxMin : MonoBehaviour
    {
        public float A, B, C, D, F;
        public TextMeshProUGUI Text;

        private void Start()
        {
            Text.text = $"Max:{Mathf.Max(A, B, C, D, F)} Min{Mathf.Min(A, B, C, D, F)}";
            PrintMax();
            PrintMin();
        }

        public void PrintMax()
        {
            print("MaxValue = " + Mathf.Max(A, B, C, D, F));
        }

        public void PrintMin()
        {
            print("MinValue = " + Mathf.Min(A, B, C, D, F));
        }
    }
}