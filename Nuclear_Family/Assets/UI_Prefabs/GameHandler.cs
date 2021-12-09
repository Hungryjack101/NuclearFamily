using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour{

        public static int playerStat;
        private GameObject rick;
        private Player playerscript;
        public bool[] levels;
        public int numLevels = 10;
        public static int whereUWere;
        //public GameObject textGameObject;

        void Start () { //UpdateScore (); 
            levels = new bool[numLevels];
            for (int i=1; i<numLevels; i++) {
                levels[i] = false;
            }
            levels[0] = true;
            playerscript = GameObject.Find("Rick").GetComponent<Player>();
        }

        void Update(){         //delete this quit functionality when a Pause Menu is added
            if(playerscript.current_health<=0 || playerscript._Blade.position.y < -20) {
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
                whereUWere = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene ("LossScene");
                playerscript.current_health=100;
            }
            if(playerscript.nextLevel) {
                levels[SceneManager.GetActiveScene().buildIndex+1] = true;
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
            }
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