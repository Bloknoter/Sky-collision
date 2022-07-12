using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database.Game
{
    [CreateAssetMenu(menuName = "Airplane stats info", fileName = "AirplaneStatsInfo")]
    public class AirplaneStatsInfo : ScriptableObject
    {
        [SerializeField]
        [Min(0)]
        private int startHealth;

        public int StartHealth { get { return startHealth; } }

        [SerializeField]
        private float flySpeed = 1f;

        public float FlySpeed { get { return flySpeed; } }

        [SerializeField]
        private float rotateSpeed = 1f;

        public float RotateSpeed { get { return rotateSpeed; } }

        [SerializeField]
        [Min(0)]
        private int maxBullets = 5;

        public int MaxBullets { get { return maxBullets; } }

        [SerializeField]
        [Min(0)]
        private float createBulletCooldown = 2f;

        public float CreateBulletCooldown { get { return createBulletCooldown; } }

        #region Elimination mode 

        [SerializeField]
        [Min(0)]
        private int maxBombs = 2;

        public int MaxBombs { get { return maxBombs; } }

        [SerializeField]
        [Min(0)]
        private float createBombCooldown = 5f;

        public float CreateBombCooldown { get { return createBombCooldown; } }

        #endregion
    }
}
