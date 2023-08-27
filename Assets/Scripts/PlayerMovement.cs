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
    
    public Boolean isInPast = true;
    public static float futureTPOffset = 70;

    private Rigidbody2D playerBody ;

    public GameObject PlayerLocationMarker;

    public float TeleportSafeZone = 1.0f;

    void Start()
    {
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    public void OnMoveButton( InputAction.CallbackContext cbc){
        playerBody.velocity = SpeedMultiplier * cbc.ReadValue<Vector2>();
    }

    public void OnAbilityButton( InputAction.CallbackContext cbc){
        Debug.Log("Ability Use");

        Debug.Log(
            Physics2D.IsTouchingLayers(PlayerTP.Collider,LayerMask.GetMask("GameWalls"))
        );

        if (Physics2D.IsTouchingLayers(PlayerTP.Collider,LayerMask.GetMask("GameWalls"))) {
            return;
        }
            
        this.transform.position = getTPLocation( this.gameObject, isInPast);
        isInPast = !isInPast;
    }

    private static Vector3 getTPLocation( GameObject player, Boolean isInPast){
        return new Vector3(
            player.gameObject.transform.position.x + 
                (isInPast ? PlayerMovement.futureTPOffset : - PlayerMovement.futureTPOffset) ,

            player.gameObject.transform.position.y,
            player.gameObject.transform.position.z
        );
        
    }

    private void FixedUpdate(){
        PlayerLocationMarker.transform.position = getTPLocation( this.gameObject, isInPast);
    }
}
