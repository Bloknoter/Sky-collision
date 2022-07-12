using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.InputEngine.Actions
{
    public class SimpleAction : IInputAction
    {
        private string name;
        public SimpleAction(string name)
        {
            this.name = name;
        }

        public string Name { get { return name; } }

        #region event

        public delegate void OnActionDelegate();

        private event OnActionDelegate OnAction;

        public void AddListener(OnActionDelegate newDelegate)
        {
            OnAction += newDelegate;
        }

        public void RemoveListener(OnActionDelegate newDelegate)
        {
            OnAction -= newDelegate;
        }

        public void InvokeEvent()
        {
            OnAction?.Invoke();
        }

        #endregion
    }
}
