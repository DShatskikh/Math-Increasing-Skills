using System;
using MrAutofire;
using TMPro;
using UnityEngine;

namespace Math
{
    public class FloorRoundCeil : MonoBehaviour
    {
        public float A;
        public bool IsCeilMove=>gameObject.activeSelf;
        public GameObject ObjectMove;

        public TextMeshProUGUI Text;

        private void OnEnable()
        {
            Text.text = $"A={A}\nFloor={Mathf.Floor(A)}\nRound={Mathf.Round(A)}\nCeil={Mathf.Ceil(A)}";
            PrintFloor();
            PrintRound();
            PrintCeil();
        }

        private void Update()
        {
            if (IsCeilMove)
            {
                var position = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
                ObjectMove.transform.position = position.SetX(MathF.Round(position.x)).SetY(MathF.Round(position.y)).SetZ(0);
            }
        }

        public void PrintFloor()
        {
            print("Floor = " + Mathf.Floor(A));
        }

        public void PrintRound()
        {
            print("Round = " + Mathf.Round(A));
        }

        public void PrintCeil()
        {
            print("Ceil = " + Mathf.Ceil(A));
        }
    }
}