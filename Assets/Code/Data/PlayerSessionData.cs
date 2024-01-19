using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Player
{
    [CreateAssetMenu(fileName = "PlayerSessionData", menuName = "Player session data")]
    public class PlayerSessionData : ScriptableObject
    {
        public delegate void ConnectionListener();
        public event ConnectionListener OnConnected;

        private bool m_connected = false;

        public bool Connected => m_connected;
        public string Name;

        public void SetAsConnected()
        {
            m_connected = true;
            OnConnected?.Invoke();
        }
    }
}
