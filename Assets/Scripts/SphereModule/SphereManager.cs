using System;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SphereModule
{
    public class SphereManager : MonoBehaviour
    {
        public event Action SpherePaused;
        
        [SerializeField] private SphereController spherePrefab;
        [SerializeField] private float spawnRadius = 10f;
        [SerializeField] private float pauseTime;

        public float PauseTime => pauseTime;

        private SphereController _currentSphere;
        
        private void Awake()
        {
            InputManager.Instance.PauseButtonPressed += OnPauseButtonPressed;
        }

        private void OnDestroy()
        {
            InputManager.Instance.PauseButtonPressed -= OnPauseButtonPressed;
        }
        
        public void SpawnSphere()
        {
            if (_currentSphere)
            {
                return;
            }
            
            Vector3 centre = transform.position;
            float theta = Random.value * 2f * Mathf.PI;
            float x = centre.x + spawnRadius * Mathf.Cos(theta);
            float z = centre.z + spawnRadius * Mathf.Sin(theta);
            var spawnPosition = new Vector3(x, 0f, z);
            
            SphereController sphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);
            sphere.Setup(centre);
            _currentSphere = sphere;
        }

        public float GetSphereTravelledDistance()
        {
            return _currentSphere ? _currentSphere.TotalDistanceTravelled : 0f;
        }
        
        private void OnPauseButtonPressed()
        {
            if (!_currentSphere)
            {
                return;
            }
            _currentSphere.Pause(pauseTime);
            SpherePaused?.Invoke();
        }
    
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }
}
