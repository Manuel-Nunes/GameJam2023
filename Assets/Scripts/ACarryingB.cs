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
        this.Passenger.GetComponent<Collider2D>().enabled = true;
        this.Passenger = null;
    }

    public bool HasPassenger(){
        return this.Passenger != null;
    }

    public void PickUp(GameObject other){
        other.GetComponent<Collider2D>().enabled = false;
        this.Passenger = other;
    }
}
