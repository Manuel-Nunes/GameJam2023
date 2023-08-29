using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScreenToPlayerCam : MonoBehaviour
{
    public GameObject CameraTarget;
    // public Light2D CameraLight;
    
    void FixedUpdate(){
        this.transform.position = new Vector3( CameraTarget.transform.position.x, CameraTarget.transform.position.y, this.transform.position.z);
        // CameraLight.transform.position = new Vector3( CameraTarget.transform.position.x, CameraTarget.transform.position.y, CameraLight.transform.position.z);
    }
}
