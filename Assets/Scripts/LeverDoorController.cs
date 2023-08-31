using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class LeverDoorController : MonoBehaviour
{
    private bool isDoorOpen = false;
    private GameObject lever;
    private GameObject leverDoor;

    public AudioClip DoorOpen;
    public AudioClip DoorClose;

    public Animator DoorAnimator;

    private AudioSource source;

    void Start()
    {
        lever = GameObject.FindGameObjectWithTag("Lever");
        leverDoor = GameObject.FindGameObjectWithTag("LeverDoor");

        // set lever to close 
        lever.transform.Rotate(0, 0, -45);

        // lever door is set to closed

        // audio 
        source = gameObject.AddComponent<AudioSource>();

        // Initialize Door animation to false
        DoorAnimator.SetBool("DoorIsOpen", false);
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
        source.clip = DoorOpen;
        source.Play();
        lever.transform.Rotate(0, 0, 90);
        leverDoor.transform.Rotate(0, 0, 90);
        isDoorOpen = true;
        DoorAnimator.SetBool("DoorIsOpen", true);
        
    }

    private void CloseDoor()
    {
        source.clip = DoorClose;
        source.Play();
        lever.transform.Rotate(0, 0, -90);
        leverDoor.transform.Rotate(0, 0, -90);
        isDoorOpen = false;

        DoorAnimator.SetBool("DoorIsOpen", false);
    }
}
