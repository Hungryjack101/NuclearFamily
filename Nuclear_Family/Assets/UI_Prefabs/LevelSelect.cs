using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelSelect : MonoBehaviour  {
    private GameHandler gamehandlerscript;
    public GameObject buttonUI;
    public bool[] levels;
    public GameObject[] levelObjs;
    public int numLevels;
        
    public void Start(){
        gamehandlerscript = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        levels = gamehandlerscript.levels;
        numLevels = gamehandlerscript.numLevels;
        
        levelObjs = new GameObject[numLevels];
        levelObjs[0] = GameObject.Find("Level0Button");
        levelObjs[1] = GameObject.Find("Level1Button");
        levelObjs[2] = GameObject.Find("Level2Button");
        levelObjs[3] = GameObject.Find("Level3Button");
        levelObjs[4] = GameObject.Find("Level4Button");
        levelObjs[5] = GameObject.Find("Level5Button");
        
    }
    
    public void Update(){
        for (int i=0; i<numLevels; i++) {
            if (!levels[i]) {
                levelObjs[i].SetActive(false);
            }
        }
    }
    
    public void back() {
        SceneManager.LoadScene ("MainMenu");
    }
    
    public void Level0() {
        SceneManager.LoadScene ("Level0");
    }
    
    public void Level1() {
        SceneManager.LoadScene ("Level1");
    }
    
    public void Level5() {
        SceneManager.LoadScene ("Level5");
    }
        
}
