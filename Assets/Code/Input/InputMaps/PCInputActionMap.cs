using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.InputEngine.Actions;
using Database.Settings;

namespace Game.InputEngine
{
    public class PCInputActionMap : InputActionMap
    {
        [SerializeField]
        private PCBindedKeysData bindedKeysData;

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetKey(bindedKeysData.Find("rotate left").Code))
            {
                ((SimpleAction)FindAction("rotate left")).InvokeEvent();
            }
            if (Input.GetKey(bindedKeysData.Find("rotate right").Code))
            {
                ((SimpleAction)FindAction("rotate right")).InvokeEvent();
            }
            if (Input.GetKeyDown(bindedKeysData.Find("shoot").Code))
            {
                ((SimpleAction)FindAction("shoot")).InvokeEvent();
            }
            if(Input.GetKeyDown(bindedKeysData.Find("put bomb").Code))
            {
                ((SimpleAction)FindAction("put bomb")).InvokeEvent();
            }
        }
    }
}
