using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    bool hasPower = false;
    public Canvas popupCanva;
    private TMP_Text popupText;
    public PlayerInput playerInput;

    void Start()
    {
        popupCanva.gameObject.SetActive(false);
        popupText = popupCanva.GetComponentInChildren<TMP_Text>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Engine":
                if (hasPower)
                {
                    ShowModal("Engine is on", 2f);
                    //To do: remove modal and show game end functionality
                }
                else
                {

                    ShowModal("The spaceship has no power!", 2f);
                }
                break;

            case "Switch":
                if (GameObject.FindGameObjectWithTag("Access Card") == null)
                {
                    hasPower = !hasPower;
                }
                else
                {
                    ShowModal("You have no access", 2f);
                }
                break;
            default:
                break;

        }
    }

    public void ShowModal(string text, float timer)
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





