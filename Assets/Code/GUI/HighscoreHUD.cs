using Database.Score;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace GameGUI
{
    public class HighscoreHUD : MonoBehaviour
    {
        [SerializeField]
        private PlayerScoreData m_scoreData;

        [SerializeField]
        private TextMeshProUGUI m_scoreText;

        private void OnEnable()
        {
            m_scoreData.OnHighscoreDataChanged += OnScoreChanged;
            m_scoreText.text = m_scoreData.Highscore.ToString();
        }

        private void OnScoreChanged()
        {
            m_scoreText.text = m_scoreData.Highscore.ToString();
        }

        private void OnDisable()
        {
            m_scoreData.OnHighscoreDataChanged -= OnScoreChanged;
        }
    }
}
