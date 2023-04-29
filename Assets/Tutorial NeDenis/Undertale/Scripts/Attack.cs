using System;
using System.Collections;
using UnityEngine;

namespace Undertale
{
    public abstract class Attack : MonoBehaviour
    {
        public event Action OnExit;
        public int WaitEndAttack;
        
        public virtual void Enter()
        {
            print("Произошла атака");
            StartCoroutine(ProcessAttack());
        }
        
        public IEnumerator ProcessAttack()
        {
            yield return new WaitForSeconds(WaitEndAttack);
            OnExit?.Invoke();
        }
    }
}