using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database.Game
{
    [CreateAssetMenu(fileName = "GameModeData", menuName = "Game mode data")]
    public class GameModeData : ScriptableObject
    {
        public const string TEAM_VS_TEAM_MODE_NAME = "Team vs Team";
        public const string ELIMINATION_MODE_NAME = "Elimination";

        public enum GameModeEnum
        {
            Team_vs_Team,
            Elimination
        }

        [SerializeField]
        private GameModeEnum gameMode;

        public GameModeEnum GameMode 
        { 
            get { return gameMode; } 
            set
            {
                gameMode = value;
            }
        }
    }
}
