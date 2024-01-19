using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.SpawningEngine;
using GUI;

namespace Game.ScoreCounters
{
    public class FinalKillsCounter : MonoBehaviour
    {
        #region 

        public delegate void OnAllAirplanesOfTeamDestroyedDelegate(TeamInfo.TeamColor team);

        private event OnAllAirplanesOfTeamDestroyedDelegate OnAllAirplanesOfTeamDestroyed;

        public void AddListener(OnAllAirplanesOfTeamDestroyedDelegate newdelegate)
        {
            OnAllAirplanesOfTeamDestroyed += newdelegate;
        }

        public void RemoveListener(OnAllAirplanesOfTeamDestroyedDelegate newdelegate)
        {
            OnAllAirplanesOfTeamDestroyed -= newdelegate;
        }

        private void InvokeOnAllAirplanesOfTeamDestroyedEvent(TeamInfo.TeamColor team)
        {
            OnAllAirplanesOfTeamDestroyed?.Invoke(team);
        }

        #endregion

        [SerializeField]
        private FabricSpawner fabricSpawner;

        [SerializeField]
        private NumbersDisplay numbersDisplay;

        [SerializeField]
        private AirplanesDatabase m_airplanesDatabase;

        private int redAirplanesAmount;

        private int blueAirplanesAmount;

        private void Start()
        {
            fabricSpawner.AddListener(OnFabricDestroyed);
            redAirplanesAmount = m_airplanesDatabase.RedAirplanesCount;
            blueAirplanesAmount = m_airplanesDatabase.BlueAirplanesCount;
            numbersDisplay.SetNullNumberToBlue();
            numbersDisplay.SetNullNumberToRed();
            for(int i = 0; i < m_airplanesDatabase.AirplanesCount;i++)
            {
                m_airplanesDatabase.AirplaneAt(i).OnAirplaneDestroyed += OnAirplaneDestroyed;
            }
        }

        private void OnAirplaneDestroyed(Airplane airplane, GameObject lastDamageDealer)
        {
            if (airplane.TeamColor == TeamInfo.TeamColor.Blue)
            {
                if (!fabricSpawner.HasAvailableFabrics(airplane.TeamColor))
                {
                    blueAirplanesAmount--;
                    numbersDisplay.SetNumberToBlue(blueAirplanesAmount);
                    if (blueAirplanesAmount <= 0)
                        InvokeOnAllAirplanesOfTeamDestroyedEvent(TeamInfo.TeamColor.Blue);
                }
                else
                {
                    numbersDisplay.SetNullNumberToBlue();
                }
            }
            if (airplane.TeamColor == TeamInfo.TeamColor.Red)
            {
                if (!fabricSpawner.HasAvailableFabrics(airplane.TeamColor))
                {
                    redAirplanesAmount--;
                    numbersDisplay.SetNumberToRed(redAirplanesAmount);
                    if (redAirplanesAmount <= 0)
                        InvokeOnAllAirplanesOfTeamDestroyedEvent(TeamInfo.TeamColor.Red);
                }
                else
                {
                    numbersDisplay.SetNullNumberToRed();
                }
            }
        }

        private void OnFabricDestroyed()
        {
            if(fabricSpawner.HasAvailableFabrics(TeamInfo.TeamColor.Blue))
            {
                numbersDisplay.SetNullNumberToBlue();              
            }
            else
            { 
                numbersDisplay.SetNumberToBlue(blueAirplanesAmount);
            }
            if (fabricSpawner.HasAvailableFabrics(TeamInfo.TeamColor.Red))
            {
                numbersDisplay.SetNullNumberToRed();
            }
            else
            {
                numbersDisplay.SetNumberToRed(redAirplanesAmount);
            }
        }
    }
}
