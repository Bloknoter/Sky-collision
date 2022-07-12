using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.SpawningEngine
{
    public abstract class AirplaneSpawner : MonoBehaviour
    {
        public abstract bool CanSpawn(Airplane airplane);

        public abstract void StartSpawn(Airplane airplane);

        public abstract void Spawn(Airplane airplane);

        protected void Put(Transform airplane, Transform point)
        {
            airplane.position = point.position;
            airplane.rotation = point.rotation;
        }
    }
}
