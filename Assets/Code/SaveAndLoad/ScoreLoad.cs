using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database.Score;
using WebCommunication;


namespace SaveLoad
{
    public class ScoreLoad : MonoBehaviour
    {
        public const string PLAYER_SCORE_DATA = "score_data";

        private static bool m_fetched = false;

        [SerializeField]
        private PlayerScoreData scoreData;

        private void Start()
        {
            if (!m_fetched)
            {
                m_fetched = true;
                FetchScore();
            }
        }

        private void FetchScore()
        {
            var dataAsString = WebBridge.Instance.Request(PLAYER_SCORE_DATA);

            if (int.TryParse(dataAsString, out int result))
                scoreData.Highscore = result;
        }
    }
}
