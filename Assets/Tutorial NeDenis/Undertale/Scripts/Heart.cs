using System;
using UnityEngine;

namespace Undertale
{
    public class Heart : MonoBehaviour
    {
        public event Action<float> OnTakeDamage;
        public event Action<float> OnTreatment;

        public float Speed = 3;

        [SerializeField]
        private Vector2 _rangeDownLeft = new Vector2(-1.285f, -1.285f);

        [SerializeField]
        private Vector2 _rangeUpRight = new Vector2(1.285f, 1.285f);
        
        private void Update()
        {
            var direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            if (direction.magnitude != 0)
                Move(direction);
            
            print(direction.magnitude);
        }

        public void UpdateRange(Vector2 rangeDownLeft, Vector2 rangeUpRight)
        {
            _rangeDownLeft = rangeDownLeft;
            _rangeUpRight = rangeUpRight;
        }
        
        public void Move(Vector3 direction)
        {
            var vector3 = direction.normalized
                          * (Speed * Time.deltaTime) 
                          + transform.position;
            var x = Mathf.Clamp(vector3.x, _rangeDownLeft.x, _rangeUpRight.x);
            var y = Mathf.Clamp(vector3.y, _rangeDownLeft.y, _rangeUpRight.y);
            vector3 = new Vector3(x, y);
            transform.position = vector3;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            /*if (other.TryGetComponent(out Attack attack))
            {
                OnTakeDamage?.Invoke(10f);
            }
            
            if (other.TryGetComponent(out Heal heal))
            {
                OnTreatment?.Invoke(10f);
            }*/
        }
    }
}