using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField]
        private float rotationSpeed;

        private Transform mytransform;

        void Start()
        {
            mytransform = transform;
        }

        void Update()
        {
            mytransform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }
}
