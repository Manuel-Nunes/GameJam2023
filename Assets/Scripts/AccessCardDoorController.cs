using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCardDoorController : MonoBehaviour
{
    private bool isAccessCardPickedUp = false;
    private GameObject accessCard;
    public Animator[] AccessCardDoorAnimators;
    
    public AudioClip DoorOpen;

    private AudioSource source;

    void Start()
    {
        accessCard = GameObject.FindGameObjectWithTag("Access Card");

        // audio 
        source = gameObject.AddComponent<AudioSource>();

        // access card door set to closed 
        foreach (Animator accessCardDoorAnimator in AccessCardDoorAnimators)
            accessCardDoorAnimator.SetBool("DoorIsOpen", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isAccessCardPickedUp)
            OpenDoor();
    }

    private void OpenDoor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        // play door open music
        source.clip = DoorOpen;
        source.Play();

        // set access card picked up to true
        isAccessCardPickedUp = true;

        // remove access card from map 
        Destroy(accessCard, source.clip.length);

        // opening door
        foreach (Animator DoorAnimator in AccessCardDoorAnimators)
            DoorAnimator.SetBool("DoorIsOpen", true);
    }
}
