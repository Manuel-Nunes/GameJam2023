using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionScript : MonoBehaviour
{
    
    public PlayerDefinition PlayerDef;

    public List<Collider2D> Interactables = new List<Collider2D>();

    public string InterActableTag = "Interactable";

    public void OnPlayerInteract( InputAction.CallbackContext cbc){

        if (cbc.performed) {
            Debug.Log("Has Already Been performed " );
            return;
        }

        if (PlayerDef.PlayerCarrying.HasPassenger()){

            Debug.Log("Drop Object ");
            
            PlayerDef.PlayerCarrying.DropB();
            return;
        }

        GameObject InteractableItem = null;
        
        for( int i = 0; i < Interactables.Count; i++) {
            if (Interactables[i].gameObject.tag == InterActableTag )
                InteractableItem = Interactables[i].gameObject;
        }

        if (InteractableItem == null) {
            Debug.Log("No Item Found");
            return;
        }

        Debug.Log("Item Found: "+ InteractableItem.name);
        PlayerDef.PlayerCarrying.PickUp(InteractableItem);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        Interactables.Add(col);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Interactables.Remove(other);
    }

}
