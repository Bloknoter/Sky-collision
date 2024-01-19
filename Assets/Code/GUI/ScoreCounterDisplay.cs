using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using GameEngine;

namespace GameGUI.GameEngine
{
    public class ScoreCounterDisplay : MonoBehaviour
    {
        [SerializeField]
        private PlayerScoreCounter scoreCounter;

        [SerializeField]
        private TextMeshProUGUI PlayerScoreT;

        private void Start()
        {
            scoreCounter.OnPlayerPointsChanged += OnPlayerScoreChanged;
            PlayerScoreT.text = scoreCounter.CalculatePlayerScore().ToString();
        }

        private void OnPlayerScoreChanged(int newscore)
        {
            PlayerScoreT.text = newscore.ToString();
        }

        private void OnDisable()
        {
            scoreCounter.OnPlayerPointsChanged -= OnPlayerScoreChanged;
        }
    }
}
