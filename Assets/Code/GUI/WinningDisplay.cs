using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MenuEngine;
using SaveLoad;

namespace GUI
{
    public class WinningDisplay : MonoBehaviour
    {
        [SerializeField]
        private Game.WinningCondition winningCondition;

        [SerializeField]
        private GameObject winningPanel;

        [SerializeField]
        private GameObject blueWinPanel;

        [SerializeField]
        private GameObject redWinPanel;

        [SerializeField]
        private GameObject newHighscore;

        [SerializeField]
        private ScoreSave scoreSave;

        [SerializeField]
        private SceneLoader sceneLoader;

        private void Start()
        {
            winningCondition.AddListener(OnGameEnd);
            winningPanel.SetActive(false);
            blueWinPanel.SetActive(false);
            redWinPanel.SetActive(false);
            Cursor.visible = false;

            scoreSave.OnNewHighScore += OnNewHighscore;
        }

        private void OnGameEnd(TeamInfo.TeamColor winningTeam)
        {
            Cursor.visible = true;
            winningPanel.SetActive(true);
            if(winningTeam == TeamInfo.TeamColor.Blue)
            {
                blueWinPanel.SetActive(true);
            }
            else if(winningTeam == TeamInfo.TeamColor.Red)
            {
                redWinPanel.SetActive(true);
            }
        }

        private void OnNewHighscore()
        {
            newHighscore.SetActive(true);
        }

        public void ToMenu()
        {
            sceneLoader.LoadScene("MainMenu");
        }

        public void Retry()
        {
            sceneLoader.LoadScene("Game");
        }

        private void OnDestroy()
        {
            Cursor.visible = true;
        }
    }
}
