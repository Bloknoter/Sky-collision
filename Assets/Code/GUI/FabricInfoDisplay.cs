using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Game;

namespace GUI
{
    public class FabricInfoDisplay : MonoBehaviour
    {
        [SerializeField]
        private Fabric fabric;

        [SerializeField]
        private Slider healthSl;

        [SerializeField]
        private Transform playerTransform;

        [SerializeField]
        private RectTransform myRectTransform;

        void Start()
        {
            healthSl.maxValue = 30;
            healthSl.value = 30;
            healthSl.gameObject.SetActive(true);
            fabric.AddListener(OnHealthChanged);
        }

        void Update()
        {
            myRectTransform.rotation = Quaternion.Euler(0, 0, playerTransform.rotation.eulerAngles.z);
        }

        private void OnHealthChanged(int newhealth)
        {
            healthSl.value = newhealth;
            if(newhealth <= 0)
            {
                healthSl.gameObject.SetActive(false);
            }
        }
    }
}
