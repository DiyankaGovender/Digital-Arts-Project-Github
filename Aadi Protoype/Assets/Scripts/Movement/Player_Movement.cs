using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEditor.Timeline;
using UnityEngine.Playables;

public class Player_Movement : MonoBehaviour
{
    public float playerMovement_speed;

    private float moveInput;
    private Rigidbody2D player_rigidBody;
    private bool playerFacing_right = false;

    private bool playerCanMove;


    public Animator player_Animator; 

    public PlayableDirector playableDirector;
  

    public PlayableAsset tutorialTimeline;
    public PlayableAsset redTimeline;


    private void Start()
    {
        player_rigidBody = GetComponent<Rigidbody2D>();
        //DisableMovement();
        DisableMovement();


        //player_Animator.Play("player_CutsceneToTutorial");
        //UI_Animator.Play("UI_FullscreenToFilmbar");
    }

    public void FixedUpdate()
    {
        if (playerCanMove)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            player_rigidBody.velocity = new Vector2(moveInput * playerMovement_speed, player_rigidBody.velocity.y);

            if (playerFacing_right == false && moveInput < 0)
            {
                FlipPlayer();
            }
            else if (playerFacing_right == true && moveInput > 0)
            {
                FlipPlayer();
            }
            
        }
       
    }

    void FlipPlayer()
    {
        playerFacing_right = !playerFacing_right;
        Vector3 Scacler = transform.localScale;
        Scacler.x *= -1;
        transform.localScale = Scacler;
    }

    public void EnableMovement()
    {
        playerCanMove = true;
        player_rigidBody.isKinematic = false;
        player_Animator.enabled = false;
    }

    public void DisableMovement()
    {
        playerCanMove = false;
        player_rigidBody.isKinematic = true;
        player_rigidBody.velocity = Vector2.zero;
    }


    //TRIGGER TIMELINES
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //TUTORIAL SCENE
        if (collision.gameObject.tag == "Tutorial_Trigger")
        {
            playableDirector.Play(tutorialTimeline);
        }


        //RED SCENE
        if (collision.gameObject.tag == "Red_Trigger")
        {
            playableDirector.Play(redTimeline);
        }
    }
}

