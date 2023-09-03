using UnityEngine;

public class LeverDoorController : MonoBehaviour
{
    private bool isDoorOpen = false;
    private GameObject lever;
    public GameObject[] LeverDoors;

    public AudioClip DoorOpen;
    public AudioClip DoorClose;

    private AudioSource source;

    void Start()
    {
        lever = GameObject.FindGameObjectWithTag("Lever");

        // set lever to close 
        lever.transform.Rotate(0, 0, -45);

        // audio 
        source = gameObject.AddComponent<AudioSource>();

        // lever door is set to closed
        foreach (GameObject leverDoor in LeverDoors)
        {
            leverDoor.transform.Rotate(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            AnimateDoor();
    }

    private void AnimateDoor()
    {
        if (isDoorOpen) 
            CloseDoor();
        else
            OpenDoor();
    }

    private void OpenDoor()
    {
        source.clip = DoorOpen;
        source.Play();
        lever.transform.Rotate(0, 0, 90);
        isDoorOpen = true;

        foreach (GameObject leverDoor in LeverDoors)
        {
            leverDoor.transform.Rotate(0, 0, 90);
            leverDoor.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void CloseDoor()
    {
        source.clip = DoorClose;
        source.Play();
        lever.transform.Rotate(0, 0, -90);
        isDoorOpen = false;

        foreach (GameObject leverDoor in LeverDoors)
        {
            leverDoor.transform.Rotate(0, 0, -90);
            leverDoor.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
