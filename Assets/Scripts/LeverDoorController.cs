using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoorController : MonoBehaviour
{
    private bool isDoorOpen = false;
    private GameObject lever;

    void Start()
    {
        lever = GameObject.FindGameObjectWithTag("Lever");

        // set door to close 
        lever.transform.Rotate(0, 0, -45);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AnimateDoor();
        }
    }

    private void AnimateDoor()
    {
        Debug.Log(isDoorOpen);
        if (isDoorOpen) {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        lever.transform.Rotate(0, 0, 90);
        isDoorOpen = true;
    }

    private void CloseDoor()
    {
        lever.transform.Rotate(0, 0, -90);
        isDoorOpen = false;
    }
}
