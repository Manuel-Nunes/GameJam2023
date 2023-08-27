using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    public PlayerTPLocationDefinition PlayerTP;
    public static float SpeedMultiplier = 10;
    
    public bool isInPast = true;
    private Rigidbody2D playerBody ;

    public GameObject PlayerLocationMarker;

    public float TeleportSafeZone = 1.0f;

    public static Vector3 TeleportOffset = new Vector3(47,0,0);

    void Start()
    {
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void OnMoveButton( InputAction.CallbackContext cbc){
        playerBody.velocity = SpeedMultiplier * cbc.ReadValue<Vector2>();
    }

    public void OnAbilityButton( InputAction.CallbackContext cbc){
        Debug.Log("Ability Use");
        
        if (Physics2D.IsTouchingLayers(PlayerTP.Collider,LayerMask.GetMask("GameWalls"))) {
            return;
        }
            
        this.transform.position = getTPLocation( this.gameObject, isInPast);
        isInPast = !isInPast;
    }

    private static Vector3 getTPLocation( GameObject player, bool isInPast){
        return 
            player.transform.position 
            + ( isInPast? TeleportOffset : -TeleportOffset);
    }

    private void FixedUpdate(){
        PlayerLocationMarker.transform.position = getTPLocation( this.gameObject, isInPast);
    }
}
