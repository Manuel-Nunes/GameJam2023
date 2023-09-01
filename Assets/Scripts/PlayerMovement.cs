using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    public PlayerTeleporationTarget PlayerTeleportTarget;

    public Animator Animator;
    public float SpeedMultiplier = 10;
    
    public bool IsInPast = true;
    private Rigidbody2D PlayerBody ;

    public float TeleportSafeZone = 1.0f;

    public Vector3 TeleportOffset = new Vector3(47,0,0);

    void Start()
    {
        PlayerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void OnMoveButton( InputAction.CallbackContext cbc){
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

    public void OnAbilityButton( InputAction.CallbackContext cbc){

        if (cbc.performed) {
            Debug.Log("Ability has already been performed" );
            return;
        }

        Debug.Log("Ability Use");
        
        if (Physics2D.IsTouchingLayers(PlayerTeleportTarget.Collider,LayerMask.GetMask("GameWalls"))) {
            return;
        }
            
        this.transform.position = GetTeleportLocation( this.gameObject, IsInPast);
        IsInPast = !IsInPast;
    }

    private Vector3 GetTeleportLocation( GameObject Player, bool IsInPast){
        return 
            Player.transform.position 
            + ( IsInPast? TeleportOffset : -TeleportOffset);
    }

    private void FixedUpdate(){
        PlayerTeleportTarget.transform.position = GetTeleportLocation(this.gameObject, IsInPast);
    }
}
