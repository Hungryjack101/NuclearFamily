using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameHandler : MonoBehaviour{

        public static int playerStat;
        private GameObject rick;
        private Player playerscript;
        public bool[] levels;
        public int numLevels = 6;
        public static int whereUWere;
        public int numDeaths;
        //public GameObject textGameObject;

        void Start () { //UpdateScore (); 
            levels = new bool[numLevels];
            for (int i=1; i<numLevels; i++) {
                levels[i] = false;
            }
            levels[0] = true;
            DontDestroyOnLoad(this);
        } 

        // void Update(){         //delete this quit functionality when a Pause Menu is added
            // try {
                // if (playerscript==null) {
                //     playerscript = GameObject.Find("Rick").GetComponent<Player>();
                // }
                // if(playerscript.nextLevel) {
                //     GoToNextLevel();
                // }
                // if(playerscript.current_health<=0 || playerscript._Blade.position.y < -20) {
                //     RickIsDead();
                // }
            // }
            // catch(NullReferenceException e) {
            //     e = null;
            // }
        // }
        
        public void RickIsDead() {
            whereUWere = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("LossScene");
            numDeaths+=1;
        }
        
        public void GoToNextLevel() {
            if(SceneManager.GetActiveScene().buildIndex<6){
                levels[SceneManager.GetActiveScene().buildIndex] = true;
            }
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
        }

        public void UpdatePlayerStat(int amount){
                playerStat += amount;
        //      UpdateScore ();
        }

        public int CheckPlayerStat(){
                return playerStat;
        }

        //void UpdateScore () {
        //        Text scoreTemp = textGameObject.GetComponent<Text>();
        //        scoreTemp.text = "Score: " + score; }

        public void StartGame(){
                SceneManager.LoadScene("MainMenu");
        }

        public void RestartGame(){
                SceneManager.LoadScene("MainMenu");
        }

        public void QuitGame(){
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
        }
}