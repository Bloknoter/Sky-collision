using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database.Game;

namespace Game
{
    public class Bomber : MonoBehaviour
    {
        [SerializeField]
        private AirplaneStatsInfo airplaneStatsInfo;

        [SerializeField]
        private GameModeData gameModeData;

        [SerializeField]
        private GameObject BombPrefab;

        [SerializeField]
        private TeamInfo.TeamColor team;

        private Transform mytransform;

        private int bombs;

        public int Bombs
        {
            get { return bombs; }
            set
            {
                bombs = Mathf.Clamp(value, 0, airplaneStatsInfo.MaxBombs);
            }
        }

        void Start()
        {
            mytransform = transform;
            bombs = airplaneStatsInfo.MaxBombs;
        }

        private bool wasCreating;

        void Update()
        {
            if(!wasCreating && Bombs < airplaneStatsInfo.MaxBombs)
            {
                wasCreating = true;
                StartCoroutine(CreatingBomb());
            }
        }

        private IEnumerator CreatingBomb()
        {
            yield return new WaitForSecondsRealtime(airplaneStatsInfo.CreateBombCooldown);
            Bombs++;
            wasCreating = false;
        }

        public void PutBomb()
        {
            if (gameModeData.GameMode == GameModeData.GameModeEnum.Elimination)
            {
                if (Bombs > 0)
                {
                    GameObject bomb = Instantiate(BombPrefab);
                    bomb.transform.position = mytransform.position;
                    bomb.transform.rotation = mytransform.rotation;
                    bomb.GetComponent<Bomb>().Team = team;
                    Bombs--;
                }
            }
        }
    }
}
