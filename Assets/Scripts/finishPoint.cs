using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishPoint : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name =="Player"){
            audioManager.PlaySFX(audioManager.finalpoint);
            UnlockedLevel();
            Invoke("CompleteLevel",2f);    
        }
    }
    private void CompleteLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    void UnlockedLevel(){
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex")){
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex +1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel",1)+1);
            PlayerPrefs.Save();
        }
    }
    // Start is called before the first frame update
    //void Start(){
    //    finishSound = GetComponent<AudioSource>();
    //}
}
