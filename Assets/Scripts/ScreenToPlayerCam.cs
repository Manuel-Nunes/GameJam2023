using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToPlayerCam : MonoBehaviour
{
    public GameObject CameraTarget;
    
    void FixedUpdate(){
        this.transform.position = new Vector3( CameraTarget.transform.position.x, CameraTarget.transform.position.y, this.transform.position.z);
    }
}
