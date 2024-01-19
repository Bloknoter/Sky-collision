using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database.Game;
using Game.SpawningEngine;

namespace Game
{
    public class Airplane : MonoBehaviour, IDamagable
    {
        public delegate void AirplaneWithObjectEventListener(Airplane airplane, GameObject lastDamageDealer);
        public event AirplaneWithObjectEventListener OnDamageApplied;
        public event AirplaneWithObjectEventListener OnAirplaneDestroyed;
        public event AirplaneWithObjectEventListener OnBonusTaken;

        [SerializeField]
        private TeamInfo.TeamColor team;

        [SerializeField]
        private Transform mytransform;

        [SerializeField]
        private ParticleSystem smokeParticleSystem;

        [SerializeField]
        private AirplaneStatsInfo statsInfo;

        [SerializeField]
        private Transform shootPoint;

        [SerializeField]
        private GameObject BulletPrefab;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private AudioClip shootSound;

        [SerializeField]
        private GameObject ExplosionPrefab;

        [SerializeField]
        private AirplaneSpawner spawner;

        private int health;
        private GameObject m_lastDamageDealer;

        public int Health
        {
            get { return health; }
            private set
            {
                health = Mathf.Clamp(value, 0, statsInfo.StartHealth);
                if(health < statsInfo.StartHealth)
                {
                    if (!smokeParticleSystem.isPlaying)
                    {
                        smokeParticleSystem.gameObject.SetActive(true);
                        smokeParticleSystem.Play();
                    }
                }
                else
                {
                    smokeParticleSystem.Stop();
                    smokeParticleSystem.gameObject.SetActive(false);
                }


                if (health == 0)
                {
                    OnAirplaneDestroyed?.Invoke(this, m_lastDamageDealer);
                    smokeParticleSystem.gameObject.SetActive(false);
                    smokeParticleSystem.Stop();
                    Instantiate(ExplosionPrefab, mytransform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                    mytransform.position = new Vector2(200, 200);
                    spawner.Spawn(this);
                }
            }
                
        }

        private int bullets;

        public int Bullets
        {
            get { return bullets; }
            private set
            {
                bullets = Mathf.Clamp(value, 0, statsInfo.MaxBullets);
            }
        }

        void Start()
        {
            health = statsInfo.StartHealth;
            smokeParticleSystem.gameObject.SetActive(false);
            bullets = statsInfo.MaxBullets;
            spawner.StartSpawn(this);
            //mytransform.position = RespawnPoint.position;
        }

        private bool wasCreatingBullets;

        void Update()
        {
            if (Health > 0)
            {
                if (!wasCreatingBullets && bullets < statsInfo.MaxBullets)
                {
                    wasCreatingBullets = true;
                    StartCoroutine(CreateBulletCooldown());
                }
                Move();
            }
        }

        public void SetMaxHealth()
        {
            health = statsInfo.StartHealth;
        }

        private IEnumerator CreateBulletCooldown()
        {
            yield return new WaitForSecondsRealtime(statsInfo.CreateBulletCooldown);
            Bullets++;
            wasCreatingBullets = false;
        }

        public void RotateRight()
        {
            if (Health == 0) return;
            mytransform.Rotate(0, 0, -statsInfo.RotateSpeed * Time.deltaTime);
        }

        public void RotateLeft()
        {
            if (Health == 0) return;
            mytransform.Rotate(0, 0, statsInfo.RotateSpeed * Time.deltaTime);
        }

        private void Move()
        {
            mytransform.Translate(new Vector2(0, 1) * statsInfo.FlySpeed * Time.deltaTime);
        }

        public void Shoot()
        {
            if (Health == 0) return;
            if (bullets > 0)
            {
                Bullets--;
                GameObject bullet = Instantiate(BulletPrefab);
                bullet.transform.position = shootPoint.position;
                bullet.transform.rotation = shootPoint.rotation;
                Bullet script = bullet.GetComponent<Bullet>();
                script.Team = team;
                script.ShootingSource = mytransform;
                audioSource.Stop();
                audioSource.clip = shootSound;
                audioSource.Play();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Health == 0) 
                return;

            HealthBonus healthBonus = collision.gameObject.GetComponent<HealthBonus>();
            if(healthBonus != null && !healthBonus.IsUsed && Health < statsInfo.StartHealth)
            {
                OnBonusTaken?.Invoke(this, healthBonus.gameObject);
                Health++;
                healthBonus.Take();
            }
        }

        public TeamInfo.TeamColor TeamColor { get { return team; } }

        public int CurrentHealth
        {
            get { return health; }
        }

        public int MaxHealth
        {
            get { return statsInfo.StartHealth; }
        }

        public void Damage(int value, GameObject damageDealer)
        {
            m_lastDamageDealer = damageDealer;
            OnDamageApplied?.Invoke(this, damageDealer);
            Health -= value;
        }

    }
}
