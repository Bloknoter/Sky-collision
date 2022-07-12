using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game;

namespace GUI
{
    public class BulletsDisplay : MonoBehaviour
    {
        [SerializeField]
        private Airplane displayedAirplaneBullets;

        [SerializeField]
        private GameObject[] bulletsIcons;

        void Start()
        {

        }

        void Update()
        {
            for(int i = 0; i < bulletsIcons.Length;i++)
            {
                bulletsIcons[i].SetActive(i < displayedAirplaneBullets.Bullets);
            }
        }
    }
}
