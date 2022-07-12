using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MainMenuEffects
{
    public class MoveUp : MonoBehaviour
    {
        [SerializeField]
        private Transform mytransform;

        [SerializeField]
        private float speed = 6;

        void Start()
        {

        }

        void Update()
        {
            mytransform.Translate(new Vector2(0, 1) * Time.deltaTime * speed);
        }
    }
}
