using SphereModule;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Setup

        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion
        
        [SerializeField] private SphereManager sphereManager;

        public SphereManager SphereManager => sphereManager;
    }
}
