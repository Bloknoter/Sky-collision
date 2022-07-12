using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database.Game;

namespace Game.InputEngine
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField]
        private Airplane airplane;

        /*[SerializeField]
        private Player.AirplaneInputTranslator inputTranslator;*/

        [SerializeField]
        private InputActionMap actionMap;

        [SerializeField]
        private GameModeData modeData;

        void Start()
        {
            actionMap.AddListener("rotate right", OnRotateRight);
            actionMap.AddListener("rotate left", OnRotateLeft);
            actionMap.AddListener("shoot", OnShoot);
        }

        void Update()
        {

        }

        private void OnRotateRight()
        {
            airplane.RotateRight();
        }

        private void OnRotateLeft()
        {
            airplane.RotateLeft();
        }

        private void OnShoot()
        {
            airplane.Shoot();
        }
    }
}
