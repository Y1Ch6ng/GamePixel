using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollect : MonoBehaviour{
    public int fruits;
    [SerializeField] public int fruitVictory;
    [SerializeField] public Text FruitsText;
    AudioManager audioManager;
    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collison) {
        if(collison.gameObject.CompareTag("Fruits")){
            audioManager.PlaySFX(audioManager.collectItem);
            Destroy(collison.gameObject);
            fruits++;
            FruitsText.text = "Fruits: " + fruits + " / " + fruitVictory;
            //Debug.Log("Fruits"+ fruits);
        }
    }
    private void CompleteLevel(){
        if(fruits >= fruitVictory){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
