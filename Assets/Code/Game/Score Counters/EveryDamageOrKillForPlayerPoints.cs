using Game;
using GameEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryDamageOrKillForPlayerPoints : MonoBehaviour
{
    [SerializeField]
    private PlayerScoreCounter m_playerScoreCounter;

    [SerializeField]
    private AirplanesDatabase m_airplanesDatabase;

    [SerializeField]
    private GameObject m_player;

    [SerializeField]
    private int m_pointsForDamage = 5;

    [SerializeField]
    private int m_pointsForKill = 20;

    [SerializeField]
    private int m_pointsWhenDamagedByEnemy = -3;

    [SerializeField]
    private int m_pointsWhenKilledByEnemy = -10;

    [SerializeField]
    private WinningCondition m_winningCondition;

    private bool m_isFinished;

    private void Start()
    {
        m_winningCondition.AddListener(OnGameFinished);

        for (int i = 0; i < m_airplanesDatabase.AirplanesCount; ++i)
        {
            m_airplanesDatabase.AirplaneAt(i).OnDamageApplied += OnAirplaneDamaged;
            m_airplanesDatabase.AirplaneAt(i).OnAirplaneDestroyed += OnAirplaneDestroyed;
        }
    }

    private void OnAirplaneDamaged(Airplane airplane, GameObject damageDealer)
    {
        if (airplane.gameObject == m_player)
            AddPoints(m_pointsWhenDamagedByEnemy);
        else if (IsPlayerAsDamageDealer(damageDealer))
            AddPoints(m_pointsForDamage);
    }

    private void OnAirplaneDestroyed(Airplane airplane, GameObject lastDamageDealer)
    {
        if (airplane.gameObject == m_player)
            AddPoints(m_pointsWhenKilledByEnemy);
        else if(IsPlayerAsDamageDealer(lastDamageDealer))
            AddPoints(m_pointsForKill);
    }

    private bool IsPlayerAsDamageDealer(GameObject damageDealer)
    {
        if (damageDealer == null)
            return false;

        var bullet = damageDealer.GetComponent<Bullet>();
        if (bullet == null)
            return false;

        return bullet.ShootingSource.gameObject == m_player;
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
