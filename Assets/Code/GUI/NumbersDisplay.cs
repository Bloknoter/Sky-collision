using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GUI
{
    public class NumbersDisplay : MonoBehaviour
    {
        [SerializeField]
        private Image[] redScoreImgs;

        [SerializeField]
        private Image[] blueScoreImgs;

        [SerializeField]
        private Sprite[] numbers = new Sprite[10];

        [SerializeField]
        private GameObject BlueNullNumber;

        [SerializeField]
        private GameObject RedNullNumber;

        void Start()
        {
            /*SetNumberToRed(0);
            SetNumberToBlue(0);*/
        }

        void Update()
        {

        }

        public void SetNumberToRed(int number)
        {
            //Debug.Log($"Set red to {number}");
            if (RedNullNumber != null)
                RedNullNumber.SetActive(false);
            int n = number / 10;
            if(n == 0)
            {
                redScoreImgs[0].gameObject.SetActive(false);
                redScoreImgs[1].gameObject.SetActive(true);
                redScoreImgs[1].sprite = numbers[number];
                return;
            }
            redScoreImgs[1].sprite = numbers[n];
            n = number % 10;
            redScoreImgs[0].gameObject.SetActive(true);
            redScoreImgs[0].sprite = numbers[n];
        }

        public void SetNumberToBlue(int number)
        {
            //Debug.Log($"Set blue to {number}");
            if (BlueNullNumber != null)
                BlueNullNumber.SetActive(false);
            int n = number / 10;
            blueScoreImgs[1].gameObject.SetActive(number >= 10);
            blueScoreImgs[0].gameObject.SetActive(true);
            blueScoreImgs[1].sprite = numbers[n];
            n = number % 10;
            blueScoreImgs[0].sprite = numbers[n];
        }

        public void SetNullNumberToRed()
        {
            RedNullNumber.SetActive(true);
            for(int i = 0; i < redScoreImgs.Length;i++)
            {
                redScoreImgs[i].gameObject.SetActive(false);
            }
        }

        public void SetNullNumberToBlue()
        {
            BlueNullNumber.SetActive(true);
            for (int i = 0; i < blueScoreImgs.Length; i++)
            {
                blueScoreImgs[i].gameObject.SetActive(false);
            }
        }
    }
}
