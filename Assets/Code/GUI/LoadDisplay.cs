using SaveLoad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameGUI
{
    public class LoadDisplay : MonoBehaviour
    {
        [SerializeField]
        private Player.PlayerSessionData m_session;

        [SerializeField]
        private MenuEngine.MenuController m_menuController;

        [SerializeField]
        private string m_nextPageAfterLoaded = "MainMenu";

        private void Awake()
        {
            m_session.OnConnected += OnConnected;
            if(m_session.Connected)
                OnConnected();
        }

        private void OnConnected()
        {
            m_session.OnConnected -= OnConnected;

            m_menuController.SetPage(m_nextPageAfterLoaded);
        }

        private void OnDisable()
        {
            m_session.OnConnected -= OnConnected;
        }
    }
}
