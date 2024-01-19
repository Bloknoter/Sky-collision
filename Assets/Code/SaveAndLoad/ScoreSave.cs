using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database.Score;
using GameEngine;
using Game;

namespace SaveLoad
{
    public class ScoreSave : MonoBehaviour
    {
        public delegate void ScoreSaveListener(bool succeed);
        public event ScoreSaveListener OnScoreSaved;

        public delegate void OnNewHightScoreDelegate();
        public event OnNewHightScoreDelegate OnNewHighScore;

        public const string NEW_HIGHSCORE = "new_highscore";

        [SerializeField]
        private PlayerScoreData playerScoreData;

        [SerializeField]
        private PlayerScoreCounter scoreCounter;

        [SerializeField]
        private WinningCondition m_gameEndCondition;

        private bool m_scoreSaved;

        public bool ScoreSaved => m_scoreSaved;

        private void Start()
        {
            m_gameEndCondition.AddListener(OnTimeRunOut);
        }

        private void OnTimeRunOut(TeamInfo.TeamColor winningTeam)
        {
            int totalScore = scoreCounter.CalculatePlayerScore();
            if (playerScoreData.Highscore < totalScore)
            {
                playerScoreData.Highscore = totalScore;

                SendNewHighscoreToWebPage(playerScoreData.Highscore);

                OnNewHighScore?.Invoke();
            }
            else
                SetScoreAsSaved(true);
        }

        private void SendNewHighscoreToWebPage(int score)
        {
            WebCommunication.WebBridge.Instance.Send(NEW_HIGHSCORE, score.ToString());

            SetScoreAsSaved(true);
        }

        private void SetScoreAsSaved(bool succeed)
        {
            m_scoreSaved = true;
            OnScoreSaved?.Invoke(succeed);
        }

        private void OnDisable()
        {
            m_gameEndCondition.RemoveListnere(OnTimeRunOut);
        }
    }
}
