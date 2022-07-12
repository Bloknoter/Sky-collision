using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database.Game
{
    [CreateAssetMenu(fileName = "CarrierStatsInfo", menuName = "Carrier stats info")]
    public class CarrierStatsInfo : ScriptableObject
    {
        [SerializeField]
        private float movingSpeed;

        public float MovingSpeed { get { return movingSpeed; }  }

        [SerializeField]
        private float rotationSpeed;

        public float RotationSpeed { get { return rotationSpeed; } }

        [SerializeField]
        [Min(0)]
        private float waitingTime;

        public float WaitingTime { get { return waitingTime; } }
    }
}
