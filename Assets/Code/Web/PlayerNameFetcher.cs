using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WebCommunication
{
    public class PlayerNameFetcher : MonoBehaviour
    {
        public const string PLAYERNAME_KEY = "playername";

        [SerializeField]
        private PlayerSessionData m_sessionData;

        [SerializeField]
        private bool m_debug;

        private void Start()
        {
            GetPlayerName();
        }

        private void GetPlayerName()
        {
            m_sessionData.Name = WebBridge.Instance.Request(PLAYERNAME_KEY);
            m_sessionData.SetAsConnected();
            if (m_debug)
                WebBridge.Instance.ShowMessage("If you see this, that means plugin is working!");
        }
    }
}
