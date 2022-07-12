using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database.Game;


namespace Game
{
    public class Turrel : MonoBehaviour
    {
        [SerializeField]
        private TeamInfo.TeamColor team;

        [SerializeField]
        private Transform gunTransform;

        [SerializeField]
        private TurrelStatsInfo statsInfo;

        [SerializeField]
        private GameObject BulletPrefab;

        [SerializeField]
        private Transform shootPoint;

        [SerializeField]
        private CircleCollider2D circleCollider;

        [SerializeField]
        private AudioSource shootSoundSource;

        public TeamInfo.TeamColor Team
        {
            get { return team; }
        }

        private enum StateType
        {
            Idle,
            Attack
        }

        private StateType state = StateType.Idle;

        private List<Transform> attackTargets = new List<Transform>();

        private bool canShoot = true;

        void Start()
        {
            circleCollider.radius = statsInfo.Range;
        }

        void Update()
        {
            if(state == StateType.Idle)
            {
                gunTransform.Rotate(0, 0, statsInfo.IdleRotationSpeed * Time.deltaTime);
                if(attackTargets.Count > 0)
                {
                    state = StateType.Attack
;                }
            }
            if(state == StateType.Attack)
            {
                if(attackTargets.Count > 0)
                {
                    if (attackTargets[0] != null)
                    {
                        Vector2 delta = attackTargets[0].position - gunTransform.position;
                        float angle = Mathf.LerpAngle(gunTransform.rotation.eulerAngles.z, Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg - 270, 0.02f);
                        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle));
                        gunTransform.rotation = rot;
                        if (canShoot)
                        {
                            Shoot();
                            canShoot = false;
                            StartCoroutine(Cooldown());
                        }
                    }
                    else
                    {
                        attackTargets.RemoveAt(0);
                    }
                }
                else
                {
                    state = StateType.Idle;
                }
            }
        }

        private void Shoot()
        {
            GameObject bullet = Instantiate(BulletPrefab);
            bullet.transform.rotation = gunTransform.rotation;
            bullet.transform.position = shootPoint.position;
            bullet.GetComponent<Bullet>().Team = team;
            shootSoundSource.Play();
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSecondsRealtime(statsInfo.ShootCooldown);
            canShoot = true;
        }

        /*public void DetectTarget(Transform newtarget)
        {
            attackTargets.Add(newtarget);
        }

        public void DeletyeTarget(Transform target)
        {
            attackTargets.Remove(target);
        }*/

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log("trigger enter");
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            if(damagable != null)
            {
                if(damagable.TeamColor != team)
                {
                    attackTargets.Add(collision.gameObject.transform);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            attackTargets.Remove(collision.gameObject.transform);
        }
    }
}
