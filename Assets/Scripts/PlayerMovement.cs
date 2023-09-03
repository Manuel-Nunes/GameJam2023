using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{

    public float SpeedMultiplier = 10;
    
    public PlayerDefinition PlayerDef;

    public void OnMoveButton( InputAction.CallbackContext cbc){
        Vector2 input = cbc.ReadValue<Vector2>();
        PlayerDef.PlayerBody2D.velocity = SpeedMultiplier * input;

        if (input.x != 0 || input.y != 0){
            PlayerDef.PlayerAnimator.SetFloat("X",input.x );
            PlayerDef.PlayerAnimator.SetFloat("Y",input.y );

            PlayerDef.PlayerAnimator.SetBool("IsWalking",true);
        }
        else{
            PlayerDef.PlayerAnimator.SetBool("IsWalking",false);
        }
    }
}
