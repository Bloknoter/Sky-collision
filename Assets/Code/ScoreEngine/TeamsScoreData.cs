using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database.Game
{
    [CreateAssetMenu(fileName = "TeamsScoreData", menuName = "Teams score data")]
    public class TeamsScoreData : ScriptableObject
    {
        [SerializeField]
        [Min(1)]
        private int winningScore = 15;

        public int WinningScore { get { return winningScore; } }

        public delegate void OnScoreChanged(int newscore);

        private event OnScoreChanged OnRedScoreChanged;

        public void AddOnRedScoreChangedListener(OnScoreChanged newdelegate)
        {
            OnRedScoreChanged += newdelegate;
        }

        public void RemoveOnRedScoreChangedListener(OnScoreChanged newdelegate)
        {
            OnRedScoreChanged -= newdelegate;
        }

        private int redScore = 0;

        public int RedScore
        {
            get { return redScore; }
            set
            {
                redScore = Mathf.Clamp(value, 0, winningScore);
                OnRedScoreChanged?.Invoke(redScore);
            }
        }


        private event OnScoreChanged OnBlueScoreChanged;

        public void AddOnBlueScoreChangedListener(OnScoreChanged newdelegate)
        {
            OnBlueScoreChanged += newdelegate;
        }

        public void RemoveOnBlueScoreChangedListener(OnScoreChanged newdelegate)
        {
            OnBlueScoreChanged -= newdelegate;
        }

        private int blueScore = 0;

        public int BlueScore
        {
            get { return blueScore; }
            set
            {
                blueScore = Mathf.Clamp(value, 0, winningScore);
                OnBlueScoreChanged?.Invoke(blueScore);
            }
        }

    }
}
