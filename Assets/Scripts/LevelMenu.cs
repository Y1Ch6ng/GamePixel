using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    int unlockLevelNumber;

    private void Start() {
        if(!PlayerPrefs.HasKey("levelIsUnlocked")){
            PlayerPrefs.SetInt("levelIsUnlocked", 1);
        }    

        unlockLevelNumber = PlayerPrefs.GetInt("levelIsUnlocked");

        for (int i=0; i< buttons.Length; i++){
            buttons[i].interactable = false;
        }
    }

    // Update is called once per frame
    private void Update(){
        unlockLevelNumber = PlayerPrefs.GetInt("levelIsUnlocked");
        for (int i=0; i< unlockLevelNumber; i++){
            buttons[i].interactable = true;
        }
    }
}
