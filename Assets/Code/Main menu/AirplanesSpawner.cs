using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database;

namespace MainMenuEffects
{
    public class AirplanesSpawner : MonoBehaviour
    {
        [SerializeField]
        private WorldSizeData worldSizeData;

        [SerializeField]
        private GameObject[] prefabs;

        [SerializeField]
        [Min(0)]
        private float spawningTime = 3f;

        void Start()
        {

        }

        private bool wasSpawning;

        void Update()
        {
            if(!wasSpawning)
            {
                wasSpawning = true;
                StartCoroutine(Spawning());
            }
        }

        private IEnumerator Spawning()
        {
            GameObject spawned = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
            float minDeltaAngle = 0f;
            float maxDeltaAngle = 0f;
            switch (Random.Range(1, 5))
            {
                case 1:  //  left side
                    spawned.transform.position = new Vector2(-worldSizeData.Size.x / 2, Random.Range(-worldSizeData.Size.y / 2, worldSizeData.Size.y / 2));
                    minDeltaAngle = Mathf.Clamp((spawned.transform.position.y / (worldSizeData.Size.y / 2) + 1) * -45, -45, 0);
                    maxDeltaAngle = Mathf.Clamp((spawned.transform.position.y / (worldSizeData.Size.y / 2) - 1) * -45, 0, 45);
                    spawned.transform.rotation = Quaternion.Euler(0, 0, -90 + Random.Range(minDeltaAngle, maxDeltaAngle));
                    break;

                case 2:  //  up side
                    spawned.transform.position = new Vector2(Random.Range(-worldSizeData.Size.x / 2, worldSizeData.Size.x / 2), worldSizeData.Size.y / 2);
                    minDeltaAngle = Mathf.Clamp((spawned.transform.position.x / (worldSizeData.Size.x / 2) + 1) * -45, -45, 0);
                    maxDeltaAngle = Mathf.Clamp((spawned.transform.position.x / (worldSizeData.Size.x / 2) - 1) * -45, 0, 45);
                    spawned.transform.rotation = Quaternion.Euler(0, 0, -180 + Random.Range(minDeltaAngle, maxDeltaAngle));
                    break;

                case 3:  //  right side
                    spawned.transform.position = new Vector2(worldSizeData.Size.x, Random.Range(-worldSizeData.Size.y / 2, worldSizeData.Size.y / 2));
                    minDeltaAngle = Mathf.Clamp((spawned.transform.position.y / (worldSizeData.Size.y / 2) + 1) * -45, -45, 0);
                    maxDeltaAngle = Mathf.Clamp((spawned.transform.position.y / (worldSizeData.Size.y / 2) - 1) * -45, 0, 45);
                    spawned.transform.rotation = Quaternion.Euler(0, 0, 90 + Random.Range(minDeltaAngle, maxDeltaAngle));
                    break;

                case 4:  //  down side
                    spawned.transform.position = new Vector2(Random.Range(-worldSizeData.Size.x / 2, worldSizeData.Size.x / 2), -worldSizeData.Size.y / 2);
                    minDeltaAngle = Mathf.Clamp((spawned.transform.position.x / (worldSizeData.Size.x / 2) + 1) * -45, -45, 0);
                    maxDeltaAngle = Mathf.Clamp((spawned.transform.position.x / (worldSizeData.Size.x / 2) - 1) * -45, 0, 45);
                    spawned.transform.rotation = Quaternion.Euler(0, 0, 0 + Random.Range(minDeltaAngle, maxDeltaAngle));
                    break;
            }
            yield return new WaitForSecondsRealtime(spawningTime);
            wasSpawning = false;
        }
    }
}
