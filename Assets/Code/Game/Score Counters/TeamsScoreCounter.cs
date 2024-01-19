using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database.Game;
using Game;

namespace Game.ScoreCounters
{
    public class TeamsScoreCounter : MonoBehaviour
    {
        [SerializeField]
        private TeamsScoreData scoreData;

        [SerializeField]
        private AirplanesDatabase airplanesDatabase;

        private void Start()
        {
            scoreData.BlueScore = 0;
            scoreData.RedScore = 0;
            for(int i = 0; i < airplanesDatabase.AirplanesCount;i++)
            {
                airplanesDatabase.AirplaneAt(i).OnAirplaneDestroyed += OnAirplaneDestroyed;
            }
        }

        private void OnAirplaneDestroyed(Airplane airplane, GameObject lastDamageDealer)
        {
            if (airplane.TeamColor == TeamInfo.TeamColor.Blue)
            {
                scoreData.RedScore++;
            }
            if (airplane.TeamColor == TeamInfo.TeamColor.Red)
            {
                scoreData.BlueScore++;
            }
        }
    }
}
