using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConnectObjects: MonoBehaviour
{
    public GameObject Target;
    public GameObject Passenger;

    public abstract void UpdateObjectConnection();

    public void FixedUpdate(){
      if (Target != null && Passenger != null)
        UpdateObjectConnection();
    }
}
