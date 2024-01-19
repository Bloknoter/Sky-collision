using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameEngine;
using Database.Score;

namespace GameGUI.GameEngine
{
    public class FinalResultsDisplay : MonoBehaviour
    {
        [SerializeField]
        private SaveLoad.ScoreSave scoreSave;

        [SerializeField]
        private GameObject HighScore;

        private void OnEnable()
        {
            HighScore.SetActive(false);
            scoreSave.OnNewHighScore += OnNewHighScore;
        }

        private void OnNewHighScore()
        {
            HighScore.SetActive(true);
        }

        private void OnDisable()
        {
            scoreSave.OnNewHighScore -= OnNewHighScore;
        }
    }
}
