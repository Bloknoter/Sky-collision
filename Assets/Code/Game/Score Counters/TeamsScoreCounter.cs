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
        private Airplane[] allAirplanes;

        void Start()
        {
            scoreData.BlueScore = 0;
            scoreData.RedScore = 0;
            for(int i = 0; i < allAirplanes.Length;i++)
            {
                allAirplanes[i].AddListener(OnAirplaneDestroyed);
            }
        }

        void Update()
        {

        }
        private void OnAirplaneDestroyed(Airplane airplane)
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
