using UI;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIDistance uiDistance;
        
        private void Start()
        {
            GameManager.Instance.SphereManager.SpherePaused += OnSpherePaused;
        }
        private void OnDestroy()
        {
            GameManager.Instance.SphereManager.SpherePaused -= OnSpherePaused;
        }
        
        private void OnSpherePaused()
        {
            uiDistance.ShowDistance();
        }

        #region UIButtonMethods

        public void OnSpawnSphereButtonClicked()
        {
            GameManager.Instance.SphereManager.SpawnSphere();
        }

        #endregion
        
    }
}
