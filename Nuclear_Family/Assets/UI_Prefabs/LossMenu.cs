using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LossMenu : MonoBehaviour  {

        public GameObject lossMenuUI;
        public GameHandler gamehandlerscript;
        public int whereUWereLoss;
        
        public void Start(){
            gamehandlerscript = GameObject.Find("GameHandler").GetComponent<GameHandler>();
            whereUWereLoss = GameHandler.whereUWere;
        }
        
        public void RestartLossMenu(){
            Time.timeScale = 1f;
            SceneManager.LoadScene(whereUWereLoss);
        }
        
        public void MainMen() {
            SceneManager.LoadScene ("MainMenu");
        }

      public void QuitGameLossMenu() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }
  }