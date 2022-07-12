using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField]
        private GameObject ExplosionPrefab;

        [SerializeField]
        [Min(0)]
        private float explosionTime = 3f;

        [SerializeField]
        [Min(0)]
        private float explosionRadius = 1f;

        private Transform mytransform;

        private TeamInfo.TeamColor team;

        public TeamInfo.TeamColor Team
        {
            get { return team; }
            set
            {
                if (team == TeamInfo.TeamColor.None)
                    team = value;
            }
        }

        void Start()
        {
            mytransform = transform;
        }

        private bool wasExploding;

        void Update()
        {
            if(!wasExploding)
            {
                wasExploding = true;
                StartCoroutine(Exploding());
            }
        }

        private IEnumerator Exploding()
        {
            yield return new WaitForSecondsRealtime(explosionTime);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(mytransform.position, explosionRadius);
            for(int i = 0; i < colliders.Length;i++)
            {
                if(colliders[i].gameObject != gameObject)
                {
                    IDamagable damagable = colliders[i].gameObject.GetComponent<IDamagable>();
                    if (damagable != null)
                    {
                        if (damagable.TeamColor != team)
                        {
                            damagable.Damage(15);
                        }
                    }
                }
            }
            Instantiate(ExplosionPrefab, mytransform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Destroy(gameObject);
        }
    }
}
