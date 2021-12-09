using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LossMenu : MonoBehaviour  {

        public GameObject lossMenuUI;
        public GameHandler gamehandlerscript;
        public int whereUWere;
        
        public void Restart2(){
                Time.timeScale = 1f;
                gamehandlerscript = GameObject.Find("GameHandler").GetComponent<GameHandler>();
                GameHandler.whereUWere = whereUWere;
                SceneManager.LoadScene (whereUWere);
        }
        
        public void MainMen() {
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