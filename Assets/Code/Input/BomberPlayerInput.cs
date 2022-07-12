using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game;

namespace Game.InputEngine
{
    public class BomberPlayerInput : MonoBehaviour
    {
        [SerializeField]
        private InputActionMap inputActionMap;

        [SerializeField]
        private Bomber bomber;

        void Start()
        {
            inputActionMap.AddListener("put bomb", OnPutBomb);
        }

        void Update()
        {

        }

        private void OnPutBomb()
        {
            bomber.PutBomb();
        }
    }
}
