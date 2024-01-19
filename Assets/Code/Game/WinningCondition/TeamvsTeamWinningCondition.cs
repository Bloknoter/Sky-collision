using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class TeamvsTeamWinningCondition : WinningCondition
    {
        [SerializeField]
        private Database.Game.TeamsScoreData scoreData;

        private void OnEnable()
        {
            scoreData.RedScore = 0;
            scoreData.BlueScore = 0;
            scoreData.AddOnRedScoreChangedListener(OnRedScoreChanged);
            scoreData.AddOnBlueScoreChangedListener(OnBlueScoreChanged);
        }

        private void OnRedScoreChanged(int newscore)
        {
            if (winningTeam == TeamInfo.TeamColor.None)
            {
                if (newscore >= scoreData.WinningScore)
                {

                    winningTeam = TeamInfo.TeamColor.Red;
                    scoreData.RemoveOnRedScoreChangedListener(OnRedScoreChanged);
                    scoreData.RemoveOnBlueScoreChangedListener(OnBlueScoreChanged);
                    InvokeOnGameEndEvent();
                }
            }
        }

        private void OnBlueScoreChanged(int newscore)
        {
            if (winningTeam == TeamInfo.TeamColor.None)
            {
                if (newscore >= scoreData.WinningScore)
                {
                    winningTeam = TeamInfo.TeamColor.Blue;
                    scoreData.RemoveOnRedScoreChangedListener(OnRedScoreChanged);
                    scoreData.RemoveOnBlueScoreChangedListener(OnBlueScoreChanged);
                    InvokeOnGameEndEvent();
                }
            }
        }
    }
}
