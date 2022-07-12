using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class HealthBonus : MonoBehaviour
    {
        [SerializeField]
        private AudioSource takingSoundSource;

        [SerializeField]
        private SpriteRenderer myrenderer;

        private bool isUsed;

        public bool IsUsed { get { return isUsed; } }

        void Start()
        {

        }

        void Update()
        {

        }

        public void Take()
        {
            isUsed = true;
            StartCoroutine(Taking());
        }

        private IEnumerator Taking()
        {
            myrenderer.color = Color.clear;
            takingSoundSource.Play();
            yield return new WaitForSecondsRealtime(1f);
            Destroy(gameObject);
        }
    }
}
