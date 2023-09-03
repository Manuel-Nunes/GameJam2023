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
    public BoxCollider2D PlayerCollider;
    public Animator PlayerAnimator;
    public CircleCollider2D PlayerInteractionCollider;

    public PlayerMovement PlayerMovement;

    public PlayerAbility PlayerAbility;

    public MountAToB MountToPlayer;
    public ACarryingB PlayerCarrying;

    public Rigidbody2D PlayerBody2D;

    public void EnableMovement(){
        this.PlayerActionInput.Enable();
        this.IsControlable = true;
    }
    
    public void DisableMovement(){
        this.PlayerActionInput.Disable();
        this.IsControlable = false;
    }

    public void KillPlayer(){
        this.IsAlive = false;
        this.PlayerAnimator.enabled = false;
        DisableMovement();
    }
}
