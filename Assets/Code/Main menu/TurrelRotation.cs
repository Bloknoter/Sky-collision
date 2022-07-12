using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MainMenuEffects
{
    public class TurrelRotation : MonoBehaviour
    {
        [SerializeField]
        private RectTransform rectTransform;

        [SerializeField]
        private float rotatingSpeed;

        void Start()
        {

        }

        void Update()
        {
            rectTransform.Rotate(0, 0, -rotatingSpeed * Time.deltaTime);
        }
    }
}
