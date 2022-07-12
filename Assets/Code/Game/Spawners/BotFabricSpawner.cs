using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.SpawningEngine
{
    public class BotFabricSpawner : AirplaneSpawner
    {
        [SerializeField]
        private FabricSpawner fabricSpawner;

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
            return fabricSpawner.HasAvailableFabrics(airplane.TeamColor);
        }

        public override void Spawn(Airplane airplane)
        {
            if (!CanSpawn(airplane))
                return;
            fabricSpawner.Spawn(airplane, fabricSpawner.GetRandomFabricID(airplane.TeamColor));
            airplane.SetMaxHealth();
        }

        public override void StartSpawn(Airplane airplane)
        {
            if (airplane.TeamColor == TeamInfo.TeamColor.Blue)
            {
                fabricSpawner.Spawn(airplane, spawnedBlueAirplanes);
                spawnedBlueAirplanes++;
            }
            if (airplane.TeamColor == TeamInfo.TeamColor.Red)
            {
                fabricSpawner.Spawn(airplane, spawnedRedAirplanes);
                spawnedRedAirplanes++;
            }
        }

        
    }
}
