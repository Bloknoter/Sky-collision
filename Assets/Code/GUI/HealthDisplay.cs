using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Game;

namespace GUI
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField]
        private Airplane airplane;

        [SerializeField]
        private Image[] heartsImgs;

        void Start()
        {

        }

        void Update()
        {
            for (int i = 0; i < heartsImgs.Length;i++)
            {
                Color newcolor = heartsImgs[i].color;
                if (airplane.Health > i)
                {
                    newcolor.a = 1f;
                }
                else
                {
                    newcolor.a = 0.4f;
                }
                heartsImgs[i].color = newcolor;
            }
        }
    }
}
