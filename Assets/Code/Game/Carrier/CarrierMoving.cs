using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database.Game;

namespace Game
{
    public class CarrierMoving : MonoBehaviour
    {
        [SerializeField]
        private CarrierStatsInfo statsInfo;

        [SerializeField]
        private Transform[] path;

        private Transform mytransform;

        private int targetPointID;

        private enum StateEnum
        {
            Moving,
            Rotating,
            Waiting
        }

        private StateEnum state;

        private bool isMovingTowards = true;

        void Start()
        {
            mytransform = transform;
            targetPointID = 1;
        }

        void Update()
        {
            if(state == StateEnum.Moving)
            {
                mytransform.position = Vector2.MoveTowards(mytransform.position, path[targetPointID].position, statsInfo.MovingSpeed * Time.deltaTime);
                if(Vector2.Distance(mytransform.position, path[targetPointID].position) < 0.1f)
                {
                    state = StateEnum.Moving;
                    if (isMovingTowards)
                    {
                        if (targetPointID == path.Length - 1)
                        {
                            isMovingTowards = false;
                            targetPointID--;
                            state = StateEnum.Waiting;
                            StartCoroutine(Waiting());
                        }
                        else
                        {
                            targetPointID++;
                        }
                    }
                    else
                    {
                        if (targetPointID == 0)
                        {
                            isMovingTowards = true;
                            targetPointID++;
                            state = StateEnum.Waiting;
                            StartCoroutine(Waiting());
                        }
                        else
                        {
                            targetPointID--;
                        }
                    }
                }
            }
            if(state == StateEnum.Rotating)
            {

            }
        }

        private IEnumerator Waiting()
        {
            yield return new WaitForSecondsRealtime(statsInfo.WaitingTime);
            state = StateEnum.Moving;
        }
    }

}
