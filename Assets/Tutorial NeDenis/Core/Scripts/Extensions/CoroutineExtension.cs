using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    //Рассширение для корутины
    public static class CoroutineExtension
    {
        private const string _runnerName = "CoroutineRunner";
        
        private static CoroutineExtensionRunner _container;
        
        public static void Restart(this IEnumerator enumerator, MonoBehaviour runner, ref Coroutine coroutine)
        {
            coroutine.Stop(runner);
            coroutine = runner.StartCoroutine(enumerator);
        }

        public static void Play(this IEnumerator enumerator, MonoBehaviour runner)
        {
            runner.StartCoroutine(enumerator);
        }

        public static void Stop(this Coroutine coroutine, MonoBehaviour runner)
        {
            if (coroutine != null && runner)
            {
                runner.StopCoroutine(coroutine);
            }
        }

        public static void PlayOnRunner(this IEnumerator enumerator, ref Coroutine coroutine)
        {
            InstantiateRunner();

            Stop(coroutine, _container);
            
            coroutine = _container.StartCoroutine(enumerator);
        }

        private static void InstantiateRunner()
        {
            if (_container == null)
            {
                _container = new GameObject(_runnerName).AddComponent<CoroutineExtensionRunner>();
            }
        }

        public static void StopOnRunner(this Coroutine coroutine)
        {
            _container.StopCoroutine(coroutine);
        }
    }

    public class CoroutineExtensionRunner : MonoBehaviour
    {
        
    }
}
