using System;
using System.Collections;
using UnityEngine;

namespace SphereModule.Effects
{
    public class SphereExplosion : MonoBehaviour
    {
        [SerializeField] private GameObject sphereModel;
        [SerializeField] private float shrinkTime = 1f;
        [SerializeField] private ParticleSystem explosionParticles;

        private bool _isRunning;

        public void Explode(Action onComplete)
        {
            if (_isRunning)
            {
                return;
            }

            StartCoroutine(ExplosionCoroutine(onComplete));
        }

        private IEnumerator ExplosionCoroutine(Action onComplete)
        {
            _isRunning = true;

            float timer = 0f;
            Vector3 startScale = sphereModel.transform.localScale;

            while (timer < shrinkTime)
            {
                sphereModel.transform.localScale = Vector3.Lerp(startScale, Vector3.zero, timer / shrinkTime);

                timer += Time.deltaTime;
                yield return null;
            }

            explosionParticles.Play();

            yield return new WaitWhile(() => explosionParticles.isPlaying);
            
            _isRunning = false;
            
            onComplete?.Invoke();
        }
    }
}