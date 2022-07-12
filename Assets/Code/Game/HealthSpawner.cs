using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class HealthSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject HealthPrefab;

        [SerializeField]
        [Min(0)]
        private float spawningTime = 5f;

        private Transform mytransform;

        private Transform health;

        void Start()
        {
            mytransform = transform;
        }

        private bool wasSpawning;
        void Update()
        {
            if(health == null)
            {
                if(!wasSpawning)
                {
                    wasSpawning = true;
                    StartCoroutine(Spawning());
                }
            }
        }

        private IEnumerator Spawning()
        {
            yield return new WaitForSecondsRealtime(spawningTime);
            health = Instantiate(HealthPrefab).transform;
            health.position = mytransform.position;
            wasSpawning = false;
        }
    }
}
