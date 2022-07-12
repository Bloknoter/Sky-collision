using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database.Game.AIEngine
{
    [CreateAssetMenu(fileName = "BotData", menuName = "Bot data")]
    public class BotData : ScriptableObject
    {
        [SerializeField]
        [Min(0)]
        private float visionDistance;

        public float VisionDistance { get { return visionDistance; } }

        [SerializeField]
        [Min(0)]
        private float shootingDeltaTime = 0.5f;

        public float ShootingDeltaTime { get { return shootingDeltaTime; } }
    }
}
