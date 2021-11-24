using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LossMenu : MonoBehaviour  {

        public GameObject lossMenuUI;

        public void Restart2(){
                Time.timeScale = 1f;
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene ("MainMenu");
        }

      public void QuitGame2() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }
  }