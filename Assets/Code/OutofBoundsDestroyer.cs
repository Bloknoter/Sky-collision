using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database;

public class OutofBoundsDestroyer : MonoBehaviour
{
    [SerializeField]
    private Transform mytransform;

    [SerializeField]
    private WorldSizeData worldSizeData;

    [SerializeField]
    private float boundsOffset = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        if(mytransform.position.x > worldSizeData.Size.x / 2 + boundsOffset ||
            mytransform.position.x < -worldSizeData.Size.x / 2 - boundsOffset ||
            mytransform.position.y > worldSizeData.Size.y / 2 + boundsOffset ||
            mytransform.position.y < -worldSizeData.Size.y / 2 - boundsOffset)
        {
            Destroy(gameObject);
        }
    }
}
