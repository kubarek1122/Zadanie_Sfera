using UnityEngine;

namespace SphereModule
{
    [CreateAssetMenu(fileName = "SphereSettings", menuName = "Settings/SphereSettings", order = 0)]
    public class SphereSettings : ScriptableObject
    {
        [SerializeField] private float maxSpeed = 10f;
        [SerializeField] private float acceleration = 2f;
        [Tooltip("How much to deflect velocity towards centre.\n" +
                 "<90 - going towards centre\n" +
                 "=90 - staying in orbit\n" +
                 ">90 - going away from centre")]
        [SerializeField] private float deflectionAngle = 80f;
        [Tooltip("May need to be adjusted if maxSpeed is too big for deflectionAngle")]
        [SerializeField] private float centreDetectionThreshold = 0.2f;

        public float MaxSpeed => maxSpeed;
        public float Acceleration => acceleration;
        public float DeflectionAngle => deflectionAngle;
        public float CentreDetectionThreshold => centreDetectionThreshold;
    }
}