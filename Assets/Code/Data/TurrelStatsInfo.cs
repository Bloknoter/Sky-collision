using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database.Game
{
    [CreateAssetMenu(fileName = "TurrelStatsInfo", menuName = "Turrel stats info")]
    public class TurrelStatsInfo : ScriptableObject
    {
        [SerializeField]
        private float idleRotationSpeed = 5f;

        public float IdleRotationSpeed { get { return idleRotationSpeed; } }

        [SerializeField]
        [Min(0)]
        private float shootCooldown = 1f;

        public float ShootCooldown { get { return shootCooldown; } }

        [SerializeField]
        [Min(0)]
        private float range;

        public float Range { get { return range; } }
    }
}
