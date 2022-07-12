using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Explosion
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField]
        [Min(0)]
        private float destroyTime = 2f;

        void Start()
        {

        }

        void Update()
        {

        }

        private void Destroy()
        {
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(Destroying());
        }

        private IEnumerator Destroying()
        {
            yield return new WaitForSecondsRealtime(destroyTime);
            Destroy(gameObject);
        }
    }
}
