using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Database.Game.InputEngine;
using Game.InputEngine.Actions;

namespace Game.InputEngine
{
    public abstract class InputActionMap : MonoBehaviour
    {
        [SerializeField]
        private InputActionsList inputActionsList;

        protected Dictionary<string, IInputAction> inputActionsDictionary = new Dictionary<string, IInputAction>();

        //public Dictionary<string, IInputAction> InputActions { get { return inputActionsDictionary; } }

        private void OnEnable()
        {
            for(int i = 0; i < inputActionsList.inputActions.Length;i++)
            {
                inputActionsDictionary.Add(inputActionsList.inputActions[i].ActionName, CreateInputActionObject(inputActionsList.inputActions[i]));
            }
        }

        void Start()
        {

        }

        void Update()
        {

        }

        private IInputAction CreateInputActionObject(InputAction pattern)
        {
            switch(pattern.ParametersType)
            {
                case InputAction.ParamsType.None:
                    return new SimpleAction(pattern.ActionName);
                    break;
                case InputAction.ParamsType.Float_value:
                    return null;
                    break;
                case InputAction.ParamsType.Vector_value:
                    return null;
                    break;
            }
            return null;
        }

        public void AddListener(string actionName, SimpleAction.OnActionDelegate actionDelegate)
        {
            IInputAction action = FindAction(actionName);
            if(action == null)
            {
                throw new System.Exception($"Cannot add listener because action map wasn't created or '{actionName}' does not exist");
            }
            else
            {
                if(action is SimpleAction)
                {
                    ((SimpleAction)action).AddListener(actionDelegate);
                }
                else
                {
                    throw new System.Exception($"Cannot add listener because action named '{actionName}' can't invoke delegate '{actionDelegate}'");
                }
            }
        }

        protected IInputAction FindAction(string actionName)
        {
            if (inputActionsDictionary.Count > 0)
            {
                if (inputActionsDictionary.ContainsKey(actionName))
                {
                    return inputActionsDictionary[actionName];
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
