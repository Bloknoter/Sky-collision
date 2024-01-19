using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameEngine
{
    public class PlayerScoreCounter : MonoBehaviour
    {
        public delegate void OnScoreChangedDelegate(int newscore);
        public event OnScoreChangedDelegate OnPlayerPointsChanged;

        private int m_playerScorePoints;

        public void AddPlayerPoints(int points)
        {
            m_playerScorePoints += points;
            OnPlayerPointsChanged?.Invoke(CalculatePlayerScore()); ;
        }

        public int CalculatePlayerScore()
        {
            return Mathf.Max(0, m_playerScorePoints);
        }

    }
}
