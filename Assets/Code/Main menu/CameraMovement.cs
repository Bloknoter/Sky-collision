using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MainMenuEffects
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private Transform mytransform;

        [SerializeField]
        private Vector2 leftDownBordersCorner;

        [SerializeField]
        private Vector2 rightUpCornersBorder;

        [SerializeField]
        [Min(0)]
        private float speed = 0.4f;

        private Vector2 targetPoint;

        void Start()
        {
            mytransform.position = new Vector3(0, 0, mytransform.position.z);
            SetRandomTargetPoint();
        }

        void Update()
        {
            Vector2 delta = targetPoint - (Vector2)mytransform.position;
            Vector2 vectorSpeed = delta / (delta.magnitude / speed);
            mytransform.position += new Vector3(vectorSpeed.x, vectorSpeed.y, 0) * Time.deltaTime;
            if(Vector2.Distance((Vector2)mytransform.position, targetPoint) < 0.2f)
            {
                SetRandomTargetPoint();
            }
        }

        private void SetRandomTargetPoint()
        {
            targetPoint = new Vector2(Random.Range(leftDownBordersCorner.x, rightUpCornersBorder.x),
                Random.Range(leftDownBordersCorner.y, rightUpCornersBorder.y));
        }
    }
}
