using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database.Game
{
    [CreateAssetMenu(fileName = "FabricStatsInfo", menuName = "Fabric stats info")]
    public class FabricStatsInfo : ScriptableObject
    {
        [SerializeField]
        [Min(0)]
        private int maxHealth;

        public int MaxHealth
        {
            get { return maxHealth; }
        }
    }
}
