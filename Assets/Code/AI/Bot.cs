using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database;
using Database.Game.AIEngine;

namespace Game.AIEngine
{
    public class Bot : MonoBehaviour
    {
        private Transform mytransform;

        [SerializeField]
        private Airplane airplane;

        [SerializeField]
        private Database.Game.AirplaneStatsInfo airplaneStatsInfo;

        [SerializeField]
        private WorldSizeData world;

        [SerializeField]
        private BotData botData;

        [SerializeField]
        private Transform visionPoint;

        [SerializeField]
        private Transform[] MyHealthSpawners;

        private enum StateEnum
        {
            Idle,
            Escaping_the_border,
            Flying_from_the_turrels,
            Healthing
        }

        private StateEnum state = StateEnum.Idle;

        private Vector2 target;

        private bool isOutOfBorders;

        private bool isRotatingRight;

        void Start()
        {
            mytransform = transform;
        }

        private bool wasShooting;

        void Update()
        {
            if(mytransform.position.y < -world.Size.y / 2 + 10f)
            {
                isOutOfBorders = true;
                if(mytransform.rotation.eulerAngles.z > 90 && mytransform.rotation.eulerAngles.z < 180)
                {
                    isRotatingRight = true;
                }
                else if (mytransform.rotation.eulerAngles.z >= 180 && mytransform.rotation.eulerAngles.z <= 270)
                {
                    isRotatingRight = false;
                }
            }
            else if(mytransform.position.y > world.Size.y / 2 - 10f)
            {
                isOutOfBorders = true;
                if (mytransform.rotation.eulerAngles.z >= 0 && mytransform.rotation.eulerAngles.z <= 90)
                {
                    isRotatingRight = false;
                }
                else if (mytransform.rotation.eulerAngles.z >= 270 && mytransform.rotation.eulerAngles.z <= 360)
                {
                    isRotatingRight = true;
                }
            }
            else if (mytransform.position.x < -world.Size.x / 2 + 10f)
            {
                isOutOfBorders = true;
                if (mytransform.rotation.eulerAngles.z >= 0 && mytransform.rotation.eulerAngles.z <= 90)
                {
                    isRotatingRight = true;
                }
                else if (mytransform.rotation.eulerAngles.z >= 90 && mytransform.rotation.eulerAngles.z <= 180)
                {
                    isRotatingRight = false;
                }
            }
            else if (mytransform.position.x > world.Size.x / 2 - 10f)
            {
                isOutOfBorders = true;
                if (mytransform.rotation.eulerAngles.z >= 180 && mytransform.rotation.eulerAngles.z <= 270)
                {
                    isRotatingRight = true;
                }
                else if (mytransform.rotation.eulerAngles.z >= 270 && mytransform.rotation.eulerAngles.z <= 360)
                {
                    isRotatingRight = false;
                }
            }
            else
            {
                isOutOfBorders = false;
            }

            Turrel enemyTurrel = null;
            RaycastHit2D[] hits = Physics2D.RaycastAll(visionPoint.position, visionPoint.up, botData.VisionDistance);
            for (int i = 0; i < hits.Length; i++)
            {
                IDamagable sometarget = hits[i].collider.gameObject.GetComponent<IDamagable>();
                if (sometarget != null)
                {
                    if (sometarget.CurrentHealth > 0)
                    {
                        if (sometarget.TeamColor != airplane.TeamColor)
                        {
                            if (!wasShooting)
                            {
                                wasShooting = true;
                                if (sometarget.CurrentHealth == sometarget.MaxHealth)
                                {
                                    StartCoroutine(Shooting(sometarget.MaxHealth));
                                }
                                else
                                {
                                    StartCoroutine(Shooting(sometarget.MaxHealth - 1));
                                }
                            }
                            break;
                        }
                    }
                }
                else
                {
                    Turrel turrel = hits[i].collider.gameObject.GetComponent<Turrel>();
                    if(turrel != null)
                    {
                        if(turrel.Team != airplane.TeamColor)
                        {
                            if (state != StateEnum.Healthing && state != StateEnum.Escaping_the_border)
                            {
                                state = StateEnum.Flying_from_the_turrels;
                                enemyTurrel = turrel;
                            }
                        }
                    }
                }
            }

            if (state != StateEnum.Healthing)
            {

                if (isOutOfBorders)
                {
                    state = StateEnum.Escaping_the_border;
                    if (isRotatingRight)
                        airplane.RotateRight();
                    else
                        airplane.RotateLeft();
                }
                else
                {
                    if (state == StateEnum.Escaping_the_border)
                        state = StateEnum.Idle;
                    if(state == StateEnum.Flying_from_the_turrels)
                    {
                        if (enemyTurrel != null)
                        {
                            Vector2 delta = (Vector2)enemyTurrel.transform.position - (Vector2)mytransform.position;
                            float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg - 90;
                            if (angle < 0)
                                airplane.RotateLeft();
                            else
                                airplane.RotateRight();
                        }
                        else
                            state = StateEnum.Idle;
                        
                    }
                }
                if(airplane.Health == 1)
                {
                    state = StateEnum.Healthing;
                    float dist = 0f;
                    float currdist = 0;
                    for(int i = 0; i < MyHealthSpawners.Length;i++)
                    {
                        currdist = Vector2.Distance(mytransform.position, MyHealthSpawners[i].position);
                        if (dist == 0 || currdist < dist)
                        {
                            dist = currdist;
                            target = MyHealthSpawners[i].position;
                        }
                    }
                }
            }
            else
            {
                Vector2 delta = target - (Vector2)mytransform.position;
                float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg - 90;
                //Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle));
                //mytransform.rotation = rot;
                
                if (angle < 0)
                    angle = 360 + angle;
                float upperBorder = angle + 2;
                if (upperBorder > 360)
                    upperBorder -= 360;
                float lowerBorder = angle - 2;
                if (lowerBorder < 0)
                    lowerBorder = 360 + lowerBorder;
                if (mytransform.rotation.eulerAngles.z - angle >= 180)
                {
                    airplane.RotateLeft();
                }
                else if(mytransform.rotation.eulerAngles.z - angle >= 0)
                {
                    airplane.RotateRight();
                }
                else if (mytransform.rotation.eulerAngles.z - angle >= -180)
                {
                    airplane.RotateLeft();
                }
                else
                {
                    airplane.RotateRight();
                }
                if (airplane.Health > 1)
                {
                    state = StateEnum.Idle;
                }
            }

            
        }

        private IEnumerator Shooting(int buletsCount)
        {
            for(int i = 0; i < buletsCount;i++)
            {
                if (airplane.Bullets == 0)
                    break;
                airplane.Shoot();
                yield return new WaitForSecondsRealtime(botData.ShootingDeltaTime);
            }
            yield return new WaitForSecondsRealtime(1f);
            wasShooting = false;
        }
    }
}
