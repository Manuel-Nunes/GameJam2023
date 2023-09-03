using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDefinition : MonoBehaviour
{
    public bool IsAlive = true;
    public bool IsControlable = true;
    public SpriteRenderer PlayerRender;
    public InputAction PlayerActionInput;
    public PlayerInput PlayerInput;
    public BoxCollider2D PlayerCollider;
    public Animator PlayerAnimator;
    public CircleCollider2D PlayerInteractionCollider;

    public PlayerMovement PlayerMovement;

    public PlayerAbility PlayerAbility;

    public MountAToB MountToPlayer;
    public ACarryingB PlayerCarrying;

    public Rigidbody2D PlayerBody2D;

    public PlayerTeleportAnimatorDefinition PlayerTeleportAnimator;

    public void EnableMovement(){
        this.PlayerInput.ActivateInput();
        this.IsControlable = true;
    }
    
    public void DisableMovement(){
        this.PlayerInput.DeactivateInput();
        this.IsControlable = false;
        Debug.Log("Player can move: "+this.PlayerActionInput.enabled);
    }

    public void KillPlayer(){
        this.IsAlive = false;
        this.PlayerAnimator.enabled = false;
        DisableMovement();
    }
}
