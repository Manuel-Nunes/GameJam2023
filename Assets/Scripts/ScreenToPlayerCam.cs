using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToPlayerCam : MonoBehaviour
{
    public GameObject cameraTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate(){
        this.transform.position = new Vector3( cameraTarget.transform.position.x, cameraTarget.transform.position.y, this.transform.position.z);
    }
}
