using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Game;

namespace GUI
{
    public class BombDisplay : MonoBehaviour
    {
        [SerializeField]
        private Bomber bomber;

        [SerializeField]
        private Image[] bombsImgs;

        void Start()
        {

        }

        void Update()
        {
            OnBombsAmountChanged(bomber.Bombs);
        }

        private void OnBombsAmountChanged(int newamount)
        {
            for(int i = 0; i < bombsImgs.Length;i++)
            {
                if(i + 1 <= newamount)
                {
                    Color c = bombsImgs[i].color;
                    c.a = 1f;
                    bombsImgs[i].color = c;
                }
                else
                {
                    Color c = bombsImgs[i].color;
                    c.a = 0.4f;
                    bombsImgs[i].color = c;
                }
            }
        }

    }
}
