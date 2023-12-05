using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    private Rigidbody2D rb;
    private Animator anim;
    private bool canDoubleJump;
    private bool facingRight =true;
    private float move;
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float jumpForce = 14;
    [Header("Collision info")]
    [SerializeField] private float groundCheckDis;
    [SerializeField] private LayerMask whatGround;
    private bool IsGrounded;
    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start(){
        rb =  GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update(){
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space)){
            JumpButton();
        }
        if(IsGrounded){
            canDoubleJump = true;
        }
        collisionCheck();
        FlipController();
        AnimController();
    }
    private void AnimController(){
        bool isMove = rb.velocity.x !=0;

        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isGrounded",IsGrounded);
        anim.SetBool("isMove",isMove);
    }
    private void JumpButton(){
        if(IsGrounded){
            Jump();
            audioManager.PlaySFX(audioManager.jump);
        }else if(canDoubleJump){
            canDoubleJump = false;
            Jump();
            audioManager.PlaySFX(audioManager.jump);
        }
    }
    private void Jump(){
            rb.velocity = new Vector2(rb.velocity.y, jumpForce);
    }
    private void FlipController(){
       if(rb.velocity.x > 0 && !facingRight){
            Flip();
        }else if(rb.velocity.x < 0 && facingRight){
            Flip();
        }
    }
    private void Flip(){
        facingRight = !facingRight;
        transform.Rotate(0,180,0);
    }
    private void collisionCheck(){
        IsGrounded = Physics2D.Raycast(transform.position,Vector2.down,
         groundCheckDis, whatGround);
    }
    private void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x,
         transform.position.y - groundCheckDis));
    }
}
 