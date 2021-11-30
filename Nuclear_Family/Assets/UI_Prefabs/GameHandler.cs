using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour{

        public static int playerStat;
        private GameObject rick;
        private Player playerscript;
        //public GameObject textGameObject;

        void Start () { //UpdateScore (); 
            playerscript = GameObject.Find("Rick").GetComponent<Player>();
        }

        void Update(){         //delete this quit functionality when a Pause Menu is added
            if(playerscript.current_health<=0 || playerscript._Blade.position.y < -20) {
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene ("LossScene");
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