using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D myrigidbody;

        [SerializeField]
        private Transform mytransform;

        [SerializeField]
        private float speed;

        private Transform parentAirplane;

        public Transform ParentAirplane
        {
            get { return parentAirplane; }
            set
            {
                if (parentAirplane == null)
                    parentAirplane = value;
            }
        }

        private TeamInfo.TeamColor team = TeamInfo.TeamColor.None;

        public TeamInfo.TeamColor Team
        {
            get { return team; }
            set
            {
                if(team == TeamInfo.TeamColor.None)
                {
                    team = value;
                }
            }
        }

        void Start()
        {

        }

        void Update()
        {
            /*if(mytransform.position.x > 75f || mytransform.position.x < -75f || mytransform.position.y > 75f || mytransform.position.y < -75f)
            {
                Destroy(gameObject);
            }*/
        }

        private void FixedUpdate()
        {
            float radAngle = (mytransform.rotation.eulerAngles.z - 90) * Mathf.Deg2Rad;
            myrigidbody.MovePosition((Vector2)mytransform.position + new Vector2(Mathf.Cos(radAngle),
                Mathf.Sin(radAngle)) * speed * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.transform != parentAirplane)
            {
                IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
                if (damagable != null)
                {
                    if (damagable.TeamColor != team)
                    {
                        damagable.Damage(1);
                        Destroy(gameObject);
                    }
                }
                
            }
        }
    }
}
