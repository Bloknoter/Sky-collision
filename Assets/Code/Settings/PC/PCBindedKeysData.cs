using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Database.Settings
{
    [CreateAssetMenu(fileName = "PCBindedKeysData", menuName = "PC binded keys data")]
    public class PCBindedKeysData : ScriptableObject
    {
        /*[SerializeField]
        private KeyCode leftKey;

        public KeyCode Left 
        { 
            get { return leftKey; } 
            set
            {
                leftKey = value;
            }
        }

        [SerializeField]
        private KeyCode rightKey;

        public KeyCode Right
        {
            get { return rightKey; }
            set
            {
                rightKey = value;
            }
        }

        [SerializeField]
        private KeyCode shootKey;

        public KeyCode Shoot
        {
            get { return shootKey; }
            set
            {
                shootKey = value;
            }
        }*/

        [SerializeField]
        private KeyData[] keysData;

        public KeyData Find(string keyName)
        {
            for(int i = 0; i < keysData.Length;i++)
            {
                if (keysData[i].InputAction.ActionName == keyName)
                    return keysData[i];
            }
            return null;
        }

        [System.Serializable]
        public class KeyData
        {
            /*[SerializeField]
            private string keyName = "";

            public string KeyName { get { return keyName; } }*/

            [SerializeField]
            private Database.Game.InputEngine.InputAction inputAction;

            public Database.Game.InputEngine.InputAction InputAction { get { return inputAction; } }

            [SerializeField]
            private KeyCode keyCode;

            public KeyCode Code { get { return keyCode; } set { keyCode = value; } }
        }
    }
}
