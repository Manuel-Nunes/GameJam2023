using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToPlayerCam : MonoBehaviour
{
    public GameObject cameraTarget;
    
    void FixedUpdate(){
        this.transform.position = new Vector3( cameraTarget.transform.position.x, cameraTarget.transform.position.y, this.transform.position.z);
    }
}
