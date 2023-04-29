using System;
using MrAutofire;
using UnityEngine;

namespace Math
{
    public class PingPong : MonoBehaviour
    {
        public float Speed;
        public float EndPositionX;
        public Transform TransformMove;

        private float _startPositionX;

        private void Start()
        {
            _startPositionX = -EndPositionX/2;
            TransformMove.transform.position = TransformMove.transform.position.SetX(-EndPositionX/2);
        }

        private void Update()
        {
            var xCoord = Mathf.PingPong(Time.time * Speed, EndPositionX);
            TransformMove.position = TransformMove.position.SetX(xCoord + _startPositionX);
        }
    }
}