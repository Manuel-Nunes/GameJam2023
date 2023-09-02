using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACarryingB : ConnectObjects
{
    public override void UpdateObjectConnection()
    {
        this.Passenger.transform.position = new Vector3(
            this.Target.transform.position.x,
            this.Target.transform.position.y,
            this.Target.transform.position.z
        );
    }

    public void DropB(){
        if (this.Passenger == null){
            return;
        }
        
        EffectPlayerCarryingSpeed(Target, Passenger, false);
        this.Passenger.GetComponent<Collider2D>().enabled = true;
        this.Passenger = null;
    }

    public bool HasPassenger(){
        return this.Passenger != null;
    }

    public void PickUp(GameObject other){
        other.GetComponent<Collider2D>().enabled = false;
        this.Passenger = other;

        EffectPlayerCarryingSpeed(Target, other, true);
    }

    public void EffectPlayerCarryingSpeed(GameObject Player, GameObject Carrying, bool Negatively){
        CarryableDefinitions carryable = Carrying.GetComponent<CarryableDefinitions>();

        PlayerDefinition PlayerDef = Target.GetComponent<PlayerDefinition>();

        if ( carryable != null && PlayerDef != null ){
            PlayerDef.PlayerMovement.SpeedMultiplier = 
                PlayerDef.PlayerMovement.SpeedMultiplier + 
                (   
                    Negatively
                    ? -carryable.CarrySlowDownPenalty 
                    : carryable.CarrySlowDownPenalty
                );
        }
    }
}
