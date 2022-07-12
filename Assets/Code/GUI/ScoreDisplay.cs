using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Database.Game;

namespace GUI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField]
        private TeamsScoreData scoreData;

        [SerializeField]
        private Game.WinningCondition winningCondition;

        [SerializeField]
        private NumbersDisplay numbersDisplay;

        void Start()
        {
            scoreData.AddOnRedScoreChangedListener(OnRedScoreChanged);
            scoreData.AddOnBlueScoreChangedListener(OnBlueScoreChanged);
            OnRedScoreChanged(0);
            OnBlueScoreChanged(0);
            winningCondition.AddListener(OnGameFinished);
        }

        void Update()
        {

        }

        private void OnRedScoreChanged(int newscore)
        {
            numbersDisplay.SetNumberToRed(newscore);
        }

        private void OnBlueScoreChanged(int newscore)
        {
            numbersDisplay.SetNumberToBlue(newscore);
        }

        private void OnGameFinished(TeamInfo.TeamColor winningTeam)
        {
            scoreData.RemoveOnRedScoreChangedListener(OnRedScoreChanged);
            scoreData.RemoveOnBlueScoreChangedListener(OnBlueScoreChanged);
        }

        private void OnDestroy()
        {
            scoreData.RemoveOnRedScoreChangedListener(OnRedScoreChanged);
            scoreData.RemoveOnBlueScoreChangedListener(OnBlueScoreChanged);
        }
    }
}
