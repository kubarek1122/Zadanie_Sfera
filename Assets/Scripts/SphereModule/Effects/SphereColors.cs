using UnityEngine;

namespace SphereModule.Effects
{
    public class SphereColors : MonoBehaviour
    {
        [SerializeField] private SphereController sphereController;
        [SerializeField] private MeshRenderer sphereRenderer;

        private Material _material;

        private void Awake()
        {
            _material = sphereRenderer.material;
            sphereController = GetComponentInParent<SphereController>();
        }

        private void Update()
        {
            Vector3 directionVector = sphereController.transform.position - sphereController.TargetPosition;
            directionVector.Normalize();
            float value = Vector3.SignedAngle(Vector3.right, directionVector, Vector3.up);
            if (value < 0)
            {
                value += 360f;
            }
            Color color = Color.HSVToRGB(value / 360f, 1f, 1f);

            _material.color = color;
        }
    }
}