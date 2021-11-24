using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour  {

        public GameObject mainMenuUI;

        public void Start2(){
                Time.timeScale = 1f;
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene ("SampleScene");
        }

      public void QuitGame2() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }
}