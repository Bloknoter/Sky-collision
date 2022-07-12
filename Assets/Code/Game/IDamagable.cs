using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public interface IDamagable
    {
        TeamInfo.TeamColor TeamColor { get; }

        int CurrentHealth { get; }

        int MaxHealth { get; }

        void Damage(int value);
    }
}
