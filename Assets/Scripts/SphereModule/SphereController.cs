using System.Collections;
using SphereModule.Effects;
using UnityEngine;

namespace SphereModule
{
    public class SphereController : MonoBehaviour
    {
        [SerializeField] private SphereSettings settings;
        [SerializeField] private SphereExplosion sphereExplosion;
        
        public float TotalDistanceTravelled { get; private set; }
        public Vector3 TargetPosition { get; private set; }

        private bool _isPaused;
        private float _currentSpeed;
        
        public void Setup(Vector3 target)
        {
            TargetPosition = target;
        }

        private void Update()
        {
            if (_isPaused)
            {
                return;
            }
            
            if (_currentSpeed < settings.MaxSpeed)
            {
                _currentSpeed += settings.Acceleration * Time.deltaTime;
            }
            
            Vector3 direction = TargetPosition - transform.position;
            direction = Quaternion.Euler(0, settings.DeflectionAngle, 0) * direction;
            float distanceThisFrame = _currentSpeed * Time.deltaTime;
            
            TotalDistanceTravelled += distanceThisFrame;
            
            transform.Translate(direction.normalized * distanceThisFrame);

            if (Vector3.Distance(transform.position, TargetPosition) < settings.CentreDetectionThreshold)
            {
                _isPaused = true;
                sphereExplosion.Explode(() => Destroy(gameObject));
            }
        }
        
        public void Pause(float time)
        {
            if (_isPaused)
            {
                return;
            }
            
            _currentSpeed = 0f;
            StartCoroutine(PauseCoroutine(time));
        }

        private IEnumerator PauseCoroutine(float time)
        {
            _isPaused = true;
            yield return new WaitForSeconds(time);
            _isPaused = false;
        }
    }
}