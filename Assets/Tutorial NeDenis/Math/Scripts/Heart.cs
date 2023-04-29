using System;
using MrAutofire;
using UnityEngine;

namespace Math
{
    public class Heart : MonoBehaviour
    {
        public event Action<float> OnTakeDamage;
        public event Action<float> OnTreatment;

        public float Speed;

        private void Update()
        {
            var vector3 = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))
                * (Speed * Time.deltaTime) 
                + transform.position;
            transform.position = vector3;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Attack attack))
            {
                OnTakeDamage?.Invoke(10f);
            }
            
            if (other.TryGetComponent(out Heal heal))
            {
                OnTreatment?.Invoke(10f);
            }
        }
    }
}