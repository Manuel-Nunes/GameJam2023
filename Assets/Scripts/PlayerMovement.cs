using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{

    public float SpeedMultiplier = 10;

    public Boolean isInPast = true;
    public float futureTPOffset = 70;
    private Rigidbody2D playerBody ;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue inputValue)
    {
        playerBody.velocity = SpeedMultiplier * inputValue.Get<Vector2>();
        Debug.Log("LOL");
    }

    public void OnMoveButton( InputAction.CallbackContext cbc){
        Debug.Log(" Should do move thing");
        playerBody.velocity = SpeedMultiplier * cbc.ReadValue<Vector2>();
    }

    public void OnAbilityButton( InputAction.CallbackContext cbc){
        Debug.Log("Do Ability Here");
        if ( isInPast ) {
            this.gameObject.transform.position = new Vector3(
                this.gameObject.transform.position.x + this.futureTPOffset,
                this.gameObject.transform.position.y ,
                this.gameObject.transform.position.z
            );
        }
        else {
            this.gameObject.transform.position = new Vector3(
                this.gameObject.transform.position.x - this.futureTPOffset,
                this.gameObject.transform.position.y ,
                this.gameObject.transform.position.z
            );
        }
        isInPast = !isInPast;
    }

    void Update() {

    }
}
