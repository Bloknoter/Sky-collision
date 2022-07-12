using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public abstract class WinningCondition : MonoBehaviour
    {

        #region On game end listeners

        public delegate void OnGameEndDelegate(TeamInfo.TeamColor winningTeam);

        private event OnGameEndDelegate OnGameEnd;

        public void AddListener(OnGameEndDelegate newdelegate)
        {
            OnGameEnd += newdelegate;
        }

        public void RemoveListnere(OnGameEndDelegate newdelegate)
        {
            OnGameEnd -= newdelegate;
        }

        protected void InvokeOnGameEndEvent()
        {
            Time.timeScale = 0f;
            OnGameEnd?.Invoke(winningTeam);
        }

        #endregion 

        protected TeamInfo.TeamColor winningTeam = TeamInfo.TeamColor.None;


        void Update()
        {

        }

        private void OnDestroy()
        {
            Time.timeScale = 1f;    
        }
    }
}
