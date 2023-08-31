using UnityEngine;

public class MountAToB : MonoBehaviour
{
    public GameObject Target;
    public GameObject Passenger;

    public bool MountX = true;
    public bool MountY = true;
    public bool MountZ = true;

    public Vector3 MountOffset = new Vector3(0,0,0);

    public void FixedUpdate(){
        this.Passenger.transform.position = new Vector3(
            ( MountX ? this.Target.transform.position.x : this.Passenger.transform.position.x ) + MountOffset.x,
            ( MountY ? this.Target.transform.position.y : this.Passenger.transform.position.y ) + MountOffset.y,
            ( MountZ ? this.Target.transform.position.z : this.Passenger.transform.position.z ) + MountOffset.z
        );
    }
}
