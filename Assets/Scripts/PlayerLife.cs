using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour{
    private Animator anim;
    private Rigidbody2D rb;
    AudioManager audioManager;
    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Traps")){
            Die();
        }
    }
    private void Die(){
        audioManager.PlaySFX(audioManager.death);
        anim.SetBool("isGrounded",true);
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<PlayerMovement>().enabled = false;
    }
    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
