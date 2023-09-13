using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public bool hasPower = false;
    public Canvas popupCanva;
    private TMP_Text popupText;
    public PlayerInput playerInput;

    public TilemapRenderer PowerOnTileMap;

    void Start()
    {
        Debug.Log(this.gameObject.name);
        popupCanva.gameObject.SetActive(false);
        popupText = popupCanva.GetComponentInChildren<TMP_Text>();

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        InteractionHandler(collision.gameObject.tag);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        InteractionHandler(collision.gameObject.tag);
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

    private void InteractionHandler(string tag)
    {
        switch (tag)
        {
            case "Engine":
                if (hasPower)
                {
                    ShowModal("Engine is on", 2);
                    //To do: remove modal and show game end functionality
                }
                else
                {

                    ShowModal("The spaceship has no power!", 2);
                }
                break;

            case "PowerSwitch":
                if (GameObject.FindGameObjectWithTag("Access Card") == null)
                {
                    if (!hasPower)
                    {
                        hasPower = true;
                        Debug.Log("Power on");
                        ShowModal("Emergency Power is on", 2);

                        // change sprite 
                        PowerOnTileMap.enabled = true;
                    }
                }
                else
                {
                    ShowModal("You have no access", 2);
                }
                break;
            default:
                break;

        }
    }

}





