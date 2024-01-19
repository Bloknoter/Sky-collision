using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


namespace WebCommunication
{
    public class WebBridge : MonoBehaviour
    {
        [System.Serializable]
        private class RequestedValueOffline
        {
            public string Key;
            public string Value;
        }

        [SerializeField]
        private bool m_offlineModeInBuild;

        [SerializeField]
        private List<RequestedValueOffline> m_requestedValuesOffline;

        [SerializeField]
        private bool m_debug;

        private static WebBridge m_instance;

        public static WebBridge Instance => m_instance;

        private void Awake()
        {
            if (m_instance != null)
            {
                DestroyImmediate(m_instance);
                return;
            }

            DontDestroyOnLoad(gameObject);
            m_instance = this;
        }

        private string GetRequstedOfflineValue(string key)
        {
            for(int i = 0; i < m_requestedValuesOffline.Count;++i)
            {
                if (m_requestedValuesOffline[i].Key == key)
                    return m_requestedValuesOffline[i].Value;
            }
            return "";
        }


        /// <summary>
        /// Requests data from web page
        /// </summary>
        /// <param name="key">The key for data</param>
        /// <returns>string as received data</returns>
        public string Request(string key)
        {
#if !UNITY_EDITOR
            if (!m_offlineModeInBuild)
            {
                var val = GetValue(key);
                Log($"[WebBridge] Requested \"{key}\" , returned \"{val}\"");
                return val;
            }
            else
            {
                var val = GetRequstedOfflineValue(key);
                Log($"[WebBridge.Offline] Requested \"{key}\" , returned \"{val}\"");
                return val;
            }

#else

            var val = GetRequstedOfflineValue(key);
            Log($"[WebBridge.Offline] Requested \"{key}\" , returned \"{val}\"");
            return val;
#endif
        }

        /// <summary>
        /// Sends data to the web page
        /// </summary>
        /// <param name="key">The key for data</param>
        /// <param name="val">Data</param>
        /// <returns></returns>
        public void Send(string key, string value)
        {
#if !UNITY_EDITOR
            if (!m_offlineModeInBuild)
            {
                SendValue(key, value);
                Log($"[WebBridge] Send data (key: \"{key}\" , value: \"{value}\"");
            }
            else
            {
                Log($"[WebBridge.Offline] Send data (key: \"{key}\" , value: \"{value}\"");
            }
#else
            Log($"[WebBridge.Offline] Send data (key: \"{key}\" , value: \"{value}\"");
#endif
        }

        /// <summary>
        /// Shows a message box on the web page
        /// </summary>
        /// <param name="info">Information to display in message box</param>
        /// <returns></returns>
        public void ShowMessage(string message)
        {
#if !UNITY_EDITOR
            if (!m_offlineModeInBuild)
                ShowMessageBox(message);
            else
                Debug.Log($"[WebBridge.Offline] Message Box: {message}");
#else
            UnityEditor.EditorUtility.DisplayDialog("[Offline] Message box", message, "Ok");
#endif
        }

        private void Log(string message)
        {
            if(m_debug)
                Debug.Log(message);
        }

        /// <summary>
        /// Requests data from web page
        /// </summary>
        /// <param name="key">The key for data</param>
        /// <returns>string as received data</returns>
        [DllImport("__Internal")]
        private static extern string GetValue(string key);

        /// <summary>
        /// Sends data to the web page
        /// </summary>
        /// <param name="key">The key for data</param>
        /// <param name="val">Data</param>
        /// <returns></returns>
        [DllImport("__Internal")]
        private static extern void SendValue(string key, string val);

        /// <summary>
        /// Shows a message box on the web page
        /// </summary>
        /// <param name="info">Information to display in message box</param>
        /// <returns></returns>
        [DllImport("__Internal")]
        private static extern void ShowMessageBox(string info);
    }
}
