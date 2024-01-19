using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;


namespace WebCommunication
{
    public class GameSocket : MonoBehaviour
    {
        public delegate void NumberReceiverListener(int number);
        public delegate void TextReceiverListener(string text);
        public delegate void JsonReceiverListener(string json);
        public delegate void TextWithKeyReceiverListener(TextWithKey data);

        public UnityEvent<int> OnNumberReceived;
        public UnityEvent<string> OnTextReceived;
        public UnityEvent<string> OnJsonReceived;
        public UnityEvent<TextWithKey> OnTextWithKeyReceived;

        public void PostNumber(int number)
        {
            OnNumberReceived?.Invoke(number);
        }

        public void PostText(string text)
        {
            OnTextReceived?.Invoke(text);
        }

        public void PostJson(string json) 
        {
            OnJsonReceived?.Invoke(json);
        }

        public void PostTextWithKey(string json)
        {
            var data = JsonUtility.FromJson<TextWithKey>(json);
            OnJsonReceived?.Invoke(json);
        }
    }

    [System.Serializable]
    public class TextWithKey
    {
        public string key;
        public string text;
    }
}
