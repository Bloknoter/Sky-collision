using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.ScoreCounters;

namespace Game
{
    public class EliminationWinningCondition : WinningCondition
    {
        [SerializeField]
        private FinalKillsCounter killsCounter;

        void Start()
        {
            killsCounter.AddListener(OnAllAirplanesDestroyed);
        }

        void Update()
        {

        }

        private void OnAllAirplanesDestroyed(TeamInfo.TeamColor team)
        {
            if (team == TeamInfo.TeamColor.Red)
                winningTeam = TeamInfo.TeamColor.Blue;
            if (team == TeamInfo.TeamColor.Blue)
                winningTeam = TeamInfo.TeamColor.Red;
            InvokeOnGameEndEvent();
        }
    }
}
