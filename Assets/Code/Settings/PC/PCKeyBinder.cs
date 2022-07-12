using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Database.Settings;
using Database.Game.InputEngine;

namespace SettingsEngine
{
    public class PCKeyBinder : MonoBehaviour
    {
        [SerializeField]
        private PCBindedKeysData bindedKeysData;

        [SerializeField]
        private InputActionsList actionsList;

        [SerializeField]
        private Text[] keysT;

        private InputAction bindingKey = null;

        void Start()
        {
            for(int i = 0; i < actionsList.inputActions.Length;i++)
            {
                keysT[actionsList.GetIndexOfAction(actionsList.inputActions[i].ActionName)].text = bindedKeysData.Find(actionsList.inputActions[i].ActionName).Code.ToString();
            }
        }

        void Update()
        {
            
        }

        private void OnGUI()
        {
            if (bindingKey != null)
            {
                if (Input.anyKeyDown)
                {
                    bindedKeysData.Find(bindingKey.ActionName).Code = Event.current.keyCode;
                    keysT[actionsList.GetIndexOfAction(bindingKey.ActionName)].text = Event.current.keyCode.ToString();
                    bindingKey = null;
                }
            }
        }

        /*public void OnBindingLeft()
        {
            recordingKey = KeyType.Left;
        }

        public void OnBindingRight()
        {
            recordingKey = KeyType.Right;
        }

        public void OnBindingShoot()
        {
            recordingKey = KeyType.Shoot;
        }*/
        public void OnBindingKey(InputAction inputAction)
        {
            if(bindingKey != null)
            {
                keysT[actionsList.GetIndexOfAction(bindingKey.ActionName)].text = bindedKeysData.Find(bindingKey.ActionName).Code.ToString();
                bindingKey = inputAction;
                keysT[actionsList.GetIndexOfAction(inputAction.ActionName)].text = "<Press key>";
            }
            else
            {
                bindingKey = inputAction;
                keysT[actionsList.GetIndexOfAction(inputAction.ActionName)].text = "<Press key>";
            }
        }
    }
}
