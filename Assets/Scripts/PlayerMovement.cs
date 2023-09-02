using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{

    public Animator Animator;
    public float SpeedMultiplier = 10;
    
    private Rigidbody2D PlayerBody;

    public PlayerDefinition PlayerDef;

    void Start()
    {
        PlayerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void OnMoveButton( InputAction.CallbackContext cbc){
        if (!PlayerDef.IsAlive){
            return;
        }
        
        Vector2 input = cbc.ReadValue<Vector2>();
        PlayerBody.velocity = SpeedMultiplier * input;

        if (input.x != 0 || input.y != 0){
            Animator.SetFloat("X",input.x );
            Animator.SetFloat("Y",input.y );

            Animator.SetBool("IsWalking",true);
        }
        else{
            Animator.SetBool("IsWalking",false);
        }
    }
}
