using System;
using System.Collections;
using MrAutofire;
using UnityEngine;

namespace Undertale.Monsters.Frogit
{
    public class Attack1 : Attack
    {
        public Transform _seed;
        
        public override void Enter()
        {
            base.Enter();
            
        }

        private void Update()
        {
            _seed.transform.position =
                _seed.transform.position.SetX(Mathf.Sign(Time.deltaTime)).SetY(Mathf.Cos(Time.deltaTime));
        }
    }
}