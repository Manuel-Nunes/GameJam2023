using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class AccessCardDoorController : MonoBehaviour
{
    private bool isAccessCardPickedUp = false;
    private GameObject accessCard;
    public GameObject[] LeverDoors;
    
    public AudioClip DoorOpen;

    private AudioSource source;

    void Start()
    {
        accessCard = GameObject.FindGameObjectWithTag("Access Card");

        // audio 
        source = gameObject.AddComponent<AudioSource>();

        // access card door set to closed 
        foreach (GameObject leverDoor in LeverDoors)
        {
            leverDoor.transform.Rotate(0, 0, 0);
        }
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
        //Destroy(accessCard, source.clip.length);
        accessCard.SetActive(false);

        // opening door
        foreach (GameObject leverDoor in LeverDoors)
        {
            leverDoor.transform.Rotate(0, 0, 90);
            leverDoor.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
