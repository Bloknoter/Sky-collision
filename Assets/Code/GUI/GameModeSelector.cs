using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database.Game;

namespace GUI
{
    public class GameModeSelector : MonoBehaviour
    {
        [SerializeField]
        private GameModeData gameModeData;

        [SerializeField]
        private MenuEngine.SceneLoader sceneLoader;

        void Start()
        {

        }

        void Update()
        {

        }

        public void OnGameModeSelect(string newMode)
        {
            switch(newMode)
            {
                case GameModeData.TEAM_VS_TEAM_MODE_NAME:
                    sceneLoader.LoadScene(GameModeData.TEAM_VS_TEAM_MODE_NAME);
                    break;

                case GameModeData.ELIMINATION_MODE_NAME:
                    sceneLoader.LoadScene(GameModeData.ELIMINATION_MODE_NAME);
                    break;
            }
        }
    }
}
