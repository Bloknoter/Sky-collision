using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.InputEngine;

namespace Database.Game.InputEngine
{
    [CreateAssetMenu(fileName = "InputActionsList", menuName = "Input/Actions list")]
    public class InputActionsList : ScriptableObject
    {
        [SerializeField]
        private InputAction[] list;

        public InputAction[] inputActions { get { return list; } }

        public int GetIndexOfAction(string actionName)
        {
            for(int i = 0; i < inputActions.Length;i++)
            {
                if(inputActions[i].ActionName == actionName)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
