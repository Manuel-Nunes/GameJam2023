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

    public Canvas popupCanva;
    private TMP_Text popupText;
    public PlayerInput playerInput;

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

        popupCanva.gameObject.SetActive(false);
        popupText = popupCanva.GetComponentInChildren<TMP_Text>();
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

        ShowModal("Access Card opens the Power door", (int)source.clip.length);

        // set access card picked up to true
        isAccessCardPickedUp = true;

        // remove access card from map 
        Destroy(accessCard, source.clip.length);

        // opening door
        foreach (GameObject leverDoor in LeverDoors)
        {
            leverDoor.transform.Rotate(0, 0, 90);
            leverDoor.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void ShowModal(string text, int timer)
    {
        popupCanva.gameObject.SetActive(true);
        popupText.text = text;
        playerInput.DeactivateInput();
        Invoke("ClosePopup", timer);
    }

    private void ClosePopup()
    {
        // Deactivate the popup canvas
        popupCanva.gameObject.SetActive(false);
        playerInput.ActivateInput();
    }
}
