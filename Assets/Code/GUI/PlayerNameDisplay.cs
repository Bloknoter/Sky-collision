using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace GameGUI
{
    public class PlayerNameDisplay : MonoBehaviour
    {
        [SerializeField]
        private Player.PlayerSessionData m_sessionData;

        [Header("Online")]
        [SerializeField]
        private GameObject Online;

        [SerializeField]
        private TextMeshProUGUI m_nameText;

        [Header("Offline")]
        [SerializeField]
        private GameObject Offline;

        private void Start()
        {
            m_sessionData.OnConnected += OnConnected;
            ShowName(m_sessionData.Connected);
        }

        private void ShowName(bool connected)
        {
            if (!connected)
            {
                Offline.SetActive(true);
                Online.SetActive(false);
                return;
            }

            Offline.SetActive(false);
            Online.SetActive(true);
            m_nameText.text = m_sessionData.Name;
        }

        private void OnConnected()
        {
            m_sessionData.OnConnected -= OnConnected;
            ShowName(m_sessionData.Connected);
        }

        private void OnDisable()
        {
            m_sessionData.OnConnected -= OnConnected;
        }
    }
}
