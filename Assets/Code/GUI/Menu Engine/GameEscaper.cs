using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuEngine
{
    public class GameEscaper : MonoBehaviour
    {
        [SerializeField]
        private string mainMenuSceneName = "MainMenu";

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(mainMenuSceneName);
            }
        }
    }
}
