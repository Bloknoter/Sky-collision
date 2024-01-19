using Game;
using GameEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryBonusTakenForPlayerPoints : MonoBehaviour
{
    [SerializeField]
    private PlayerScoreCounter m_playerScoreCounter;

    [SerializeField]
    private Airplane m_playerAirplane;

    [SerializeField]
    private int m_pointsForBonus = 3;

    [SerializeField]
    private WinningCondition m_winningCondition;

    private bool m_isFinished;

    private void Start()
    {
        m_playerAirplane.OnBonusTaken += OnBonusTaken;
        m_winningCondition.AddListener(OnGameFinished);
    }

    private void OnBonusTaken(Airplane airplane, GameObject damageDealer)
    {
        AddPoints(m_pointsForBonus);
    }

    private void AddPoints(int points)
    {
        if (!m_isFinished)
            m_playerScoreCounter.AddPlayerPoints(points);
    }

    private void OnGameFinished(TeamInfo.TeamColor winningTeam)
    {
        m_isFinished = true;
    }
}
