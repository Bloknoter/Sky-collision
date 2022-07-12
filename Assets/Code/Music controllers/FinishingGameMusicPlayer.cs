using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class FinishingGameMusicPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private AudioClip winningSound;

        [SerializeField]
        private AudioClip losingSound;

        [SerializeField]
        private WinningCondition winningCondition;

        void Start()
        {
            winningCondition.AddListener(OnGameFinished);
        }

        void Update()
        {

        }

        private void OnGameFinished(TeamInfo.TeamColor team)
        {
            audioSource.Stop();
            if (team == TeamInfo.TeamColor.Red)
            {
                audioSource.clip = losingSound;
            }
            else if (team == TeamInfo.TeamColor.Blue)
            {
                audioSource.clip = winningSound;
            }
            audioSource.loop = false;
            audioSource.Play();
        }
    }
}
