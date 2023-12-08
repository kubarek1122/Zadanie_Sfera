using System.Collections;
using Managers;
using SphereModule;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIDistance : MonoBehaviour
    {
        [SerializeField] private GameObject textObject;
        [SerializeField] private TextMeshProUGUI distanceText;

        private bool _isShown;

        private void Awake()
        {
            textObject.SetActive(false);
        }

        public void ShowDistance()
        {
            if (_isShown)
            {
                StopAllCoroutines();
            }
            SphereManager sphereManager = GameManager.Instance.SphereManager;
            float distance = sphereManager.GetSphereTravelledDistance();
            distanceText.text = $"{distance:N2}";
            StartCoroutine(Show(sphereManager.PauseTime));
        }

        private IEnumerator Show(float time)
        {
            textObject.SetActive(true);
            _isShown = true;
            yield return new WaitForSeconds(time);
            textObject.SetActive(false);
            _isShown = false;
        }
    }
}