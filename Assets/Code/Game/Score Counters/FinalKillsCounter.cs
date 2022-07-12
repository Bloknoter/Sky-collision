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
        private Airplane[] blueAirplanes;

        [SerializeField]
        private Airplane[] redAirplanes;

        private int redAirplanesAmount;

        private int blueAirplanesAmount;

        void Start()
        {
            fabricSpawner.AddListener(OnFabricDestroyed);
            redAirplanesAmount = redAirplanes.Length;
            blueAirplanesAmount = blueAirplanes.Length;
            numbersDisplay.SetNullNumberToBlue();
            numbersDisplay.SetNullNumberToRed();
            for(int i = 0; i < blueAirplanes.Length;i++)
            {
                blueAirplanes[i].AddListener(OnAirplaneDestroyed);
            }
            for (int i = 0; i < redAirplanes.Length; i++)
            {
                redAirplanes[i].AddListener(OnAirplaneDestroyed);
            }
        }

        void Update()
        {

        }

        private void OnAirplaneDestroyed(Airplane airplane)
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
