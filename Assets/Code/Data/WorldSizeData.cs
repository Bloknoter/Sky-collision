using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database
{
    //[CreateAssetMenu(fileName = "WorldSizeData", menuName = "World size data")]
    public class WorldSizeData : ScriptableObject
    {
        [SerializeField]
        private Vector2 size;

        public Vector2 Size { get { return size; } }
    }
}
