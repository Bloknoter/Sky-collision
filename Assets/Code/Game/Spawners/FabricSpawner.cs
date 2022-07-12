using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.SpawningEngine
{
    public class FabricSpawner : MonoBehaviour
    {
        #region Observers' code

        public delegate void OnFabricDestroyedDelegate();

        private event OnFabricDestroyedDelegate OnFabricDestroyed;

        public void AddListener(OnFabricDestroyedDelegate newdelegate)
        {
            OnFabricDestroyed += newdelegate;
        }

        public void RemoveListener(OnFabricDestroyedDelegate newdelegate)
        {
            OnFabricDestroyed -= newdelegate;
        }

        private void InvokeOnFabricDestroyedEvent()
        {
            OnFabricDestroyed?.Invoke();
        }

        #endregion

        [SerializeField]
        private Fabric[] blueFabrics;

        [SerializeField]
        private Fabric[] redFabrics;

        void Start()
        {
            for(int i = 0; i < blueFabrics.Length;i++)
            {
                blueFabrics[i].AddListener(OnFabricHealthChanged);
            }
            for (int i = 0; i < redFabrics.Length; i++)
            {
                redFabrics[i].AddListener(OnFabricHealthChanged);
            }
        }

        void Update()
        {

        }

        private void OnFabricHealthChanged(int newvalue)
        {
            if (newvalue == 0)
                InvokeOnFabricDestroyedEvent();
        }

        public bool HasAvailableFabrics(TeamInfo.TeamColor team)
        {
            if (team == TeamInfo.TeamColor.Red)
            {
                for (int i = 0; i < redFabrics.Length; i++)
                {
                    if (redFabrics[i].available)
                    {
                        return true;
                    }
                }
            }
            if (team == TeamInfo.TeamColor.Blue)
            {
                for (int i = 0; i < blueFabrics.Length; i++)
                {
                    if (blueFabrics[i].available)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int GetRandomFabricID(TeamInfo.TeamColor team)
        {
            List<int> availableFabricsIDs = new List<int>();
            if(team == TeamInfo.TeamColor.Red)
            {
                for(int i = 0; i < redFabrics.Length;i++)
                {
                    if(redFabrics[i].available)
                    {
                        availableFabricsIDs.Add(i);
                    }
                }
                return availableFabricsIDs[Random.Range(0, availableFabricsIDs.Count)];
            }
            if (team == TeamInfo.TeamColor.Blue)
            {
                for (int i = 0; i < blueFabrics.Length; i++)
                {
                    if (blueFabrics[i].available)
                    {
                        availableFabricsIDs.Add(i);
                    }
                }
                return availableFabricsIDs[Random.Range(0, availableFabricsIDs.Count)];
            }
            return -1;
        }

        public void Spawn(Airplane airplane, int spawnID)
        {
            if(airplane.TeamColor == TeamInfo.TeamColor.Blue)
            {
                blueFabrics[spawnID].Spawn(airplane.transform);
            }
            if (airplane.TeamColor == TeamInfo.TeamColor.Red)
            {
                redFabrics[spawnID].Spawn(airplane.transform);
            }
        }
    }
}
