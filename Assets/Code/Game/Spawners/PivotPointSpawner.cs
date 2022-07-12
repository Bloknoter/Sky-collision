using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.SpawningEngine
{
    public class PivotPointSpawner : AirplaneSpawner
    {
        [SerializeField]
        private Transform[] redTeamSpawnPoints;

        [SerializeField]
        private Transform[] blueTeamSpawnPoints;

        private int spawnedRedAirplanes = 0;

        private int spawnedBlueAirplanes = 0;


        void Start()
        {

        }

        void Update()
        {

        }


        public override bool CanSpawn(Airplane airplane)
        {
            return true;
        }

        public override void Spawn(Airplane airplane)
        {
            if(airplane.TeamColor == TeamInfo.TeamColor.Blue)
            {
                int rand = Random.Range(0, blueTeamSpawnPoints.Length);
                Put(airplane.transform, blueTeamSpawnPoints[rand]);
            }
            else if(airplane.TeamColor == TeamInfo.TeamColor.Red)
            {
                int rand = Random.Range(0, redTeamSpawnPoints.Length);
                Put(airplane.transform, redTeamSpawnPoints[rand]);
            }
            airplane.SetMaxHealth();
        }

        public override void StartSpawn(Airplane airplane)
        {
            if(airplane.TeamColor == TeamInfo.TeamColor.Blue)
            {
                Put(airplane.transform, blueTeamSpawnPoints[spawnedBlueAirplanes]);
                spawnedBlueAirplanes++;
            }
            else if(airplane.TeamColor == TeamInfo.TeamColor.Red)
            {
                Put(airplane.transform, redTeamSpawnPoints[spawnedRedAirplanes]);
                spawnedRedAirplanes++;
            }
        }
    }
}
