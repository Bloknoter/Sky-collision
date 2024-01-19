using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database.Score
{
    [CreateAssetMenu(fileName = "ScoreData", menuName = "Score data", order = 1)]
    public class PlayerScoreData : ScriptableObject
    {
        public delegate void HighscoreDataListener();
        public event HighscoreDataListener OnHighscoreDataChanged;

        [SerializeField]
        private int m_highscore;

        public int Highscore
        {
            get => m_highscore;
            set
            {
                var prev = m_highscore;
                m_highscore = value;
                if (prev != m_highscore)
                    OnHighscoreDataChanged?.Invoke();
            }
        }

        public void CallScoreDataChangedEvent()
        {
            OnHighscoreDataChanged?.Invoke();
        }
    }
}
