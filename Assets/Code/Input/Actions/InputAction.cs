using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database.Game.InputEngine
{
    [CreateAssetMenu(fileName = "InputActionData", menuName = "Input/ActionData")]
    [System.Serializable]
    public class InputAction : ScriptableObject
    {
        [SerializeField]
        private string actionName;

        public string ActionName { get { return actionName; } }

        public enum ParamsType
        {
            None,
            Float_value,
            Vector_value
        }

        [SerializeField]
        private ParamsType paramsType;

        public ParamsType ParametersType { get { return paramsType; } }

        
    }
}
