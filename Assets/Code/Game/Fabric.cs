using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database.Game;

namespace Game
{
    public class Fabric : MonoBehaviour, IDamagable
    {
        #region Observers' code

        public delegate void OnFabricHealthChangedDelegate(int newhealth);

        private event OnFabricHealthChangedDelegate OnFabricHealthChanged;

        public void AddListener(OnFabricHealthChangedDelegate newdelegate)
        {
            OnFabricHealthChanged += newdelegate;
        }

        public void RemoveListener(OnFabricHealthChangedDelegate newdelegate)
        {
            OnFabricHealthChanged -= newdelegate;
        }

        private void InvokeOnHealthChangedEvent()
        {
            OnFabricHealthChanged?.Invoke(health);
        }

        #endregion

        [SerializeField]
        private TeamInfo.TeamColor team;

        [SerializeField]
        private FabricStatsInfo statsInfo;

        [SerializeField]
        private GameObject ExplosionPrefab;

        [SerializeField]
        private SpriteRenderer myrenderer;

        [SerializeField]
        private Sprite destroyedSprite;

        [SerializeField]
        private Transform mytransform;

        private int health = 30;

        public int Health
        {
            get { return health; }
            set
            {
                int prevHealth = health;
                health = Mathf.Clamp(value, 0, statsInfo.MaxHealth);
                InvokeOnHealthChangedEvent();
                if(health <= 0 && prevHealth > 0)
                {
                    Instantiate(ExplosionPrefab, mytransform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                    myrenderer.sprite = destroyedSprite;
                }
            }
        }

        void Start()
        {
            health = statsInfo.MaxHealth;
        }

        void Update()
        {

        }

        public bool available
        {
            get { return health > 0; }
        }

        public void Spawn(Transform airplane)
        {
            airplane.position = mytransform.position;
            airplane.rotation = Quaternion.Euler(0, 0, mytransform.rotation.eulerAngles.z + 90f);
            StartCoroutine(Spawning(airplane));
        }

        private IEnumerator Spawning(Transform airplane)
        {
            SpriteRenderer airplaneRenderer = airplane.GetComponent<SpriteRenderer>();
            int lastSortingOrder = airplaneRenderer.sortingOrder;
            airplaneRenderer.sortingOrder = -35;
            yield return new WaitForSecondsRealtime(0.8f);
            airplaneRenderer.sortingOrder = lastSortingOrder;
        }

        public TeamInfo.TeamColor TeamColor
        {
            get { return team; }
        }

        public int CurrentHealth
        {
            get { return health; }
        }

        public int MaxHealth
        {
            get { return statsInfo.MaxHealth; }
        }

        public void Damage(int value)
        {
            Health -= value;
        }
    }
}
