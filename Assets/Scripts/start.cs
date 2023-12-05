using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour{   
    public void tutorialGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void BackGame(){
        SceneManager.LoadScene(0);
    }
}
