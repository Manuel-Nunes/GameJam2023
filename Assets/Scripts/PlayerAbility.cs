using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbility : MonoBehaviour
{
    public PlayerTeleporationTarget PlayerTeleportTarget;

    public PlayerDefinition PlayerDefinition;

    public bool IsInPast = true;

    public Vector3 TeleportOffset = new Vector3(47,0,0);

    public void OnAbilityButton( InputAction.CallbackContext cbc){
        
        PlayerDefinition.PlayerCarrying.DropB();

        if (cbc.performed) {
            Debug.Log("Ability has already been performed" );
            return;
        }

        // Debug.Log("Ability Use");
        
        if (Physics2D.IsTouchingLayers(PlayerTeleportTarget.Collider,LayerMask.GetMask("GameWalls"))) {
            return;
        }
        
        Invoke(nameof(DoTeleport),1.0f);
        PlayerDefinition.PlayerTeleportAnimator.TeleportAnimator.SetBool("PlayerIntoPortal", true );
    }

    public void DoTeleport(){
        this.transform.position = GetTeleportLocation( this.gameObject, IsInPast);
        IsInPast = !IsInPast;
        PlayerDefinition.PlayerTeleportAnimator.TeleportAnimator.SetBool("PlayerIntoPortal", false );
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
