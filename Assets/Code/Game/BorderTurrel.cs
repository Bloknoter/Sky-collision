using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class BorderTurrel : MonoBehaviour
    {
        [SerializeField]
        private Transform gunTransform;

        [SerializeField]
        private Transform laserTransform;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private AudioClip targetingSound;

        [SerializeField]
        private AudioClip shootingSound;

        [SerializeField]
        [Min(0)]
        private float shootingTime = 1f;

        [SerializeField]
        [Min(0)]
        private float damagingTime = 0.3f;

        [SerializeField]
        [Min(0)]
        private float relaunchTime = 0.5f;

        private List<Transform> targets = new List<Transform>();

        void Start()
        {
            laserTransform.gameObject.SetActive(false);
        }

        private bool wasShooting;

        void Update()
        {
            if(targets.Count > 0)
            {
                if (targets[0] != null)
                {
                    if (!wasShooting)
                    {
                        wasShooting = true;
                        StartCoroutine(Shooting());
                    }
                    Vector2 delta = targets[0].position - gunTransform.position;
                    float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg - 270;
                    Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle));
                    gunTransform.rotation = rot;
                    laserTransform.rotation = rot;
                    laserTransform.position = (targets[0].position + gunTransform.position) / 2f;
                    laserTransform.localScale = new Vector2(laserTransform.localScale.x, delta.magnitude);
                }
                else
                {
                    targets.RemoveAt(0);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                targets.Add(collision.gameObject.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            targets.Remove(collision.gameObject.transform);
        }

        private IEnumerator Shooting()
        {
            laserTransform.gameObject.SetActive(true);
            PlaySound(targetingSound);
            yield return new WaitForSecondsRealtime(shootingTime);
            PlaySound(shootingSound);
            laserTransform.localScale = new Vector2(laserTransform.localScale.x * 2f, laserTransform.localScale.y);
            yield return new WaitForSecondsRealtime(damagingTime);
            if(targets.Count > 0)
            {
                targets[0].gameObject.GetComponent<IDamagable>().Damage(9999, gameObject);
                targets.RemoveAt(0);
            }
            laserTransform.gameObject.SetActive(false);
            laserTransform.localScale = new Vector2(laserTransform.localScale.x / 2f, laserTransform.localScale.y);
            yield return new WaitForSecondsRealtime(relaunchTime);
            wasShooting = false;
        }

        private void PlaySound(AudioClip clip)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
