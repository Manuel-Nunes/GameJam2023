using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class OxygenMaskController : MonoBehaviour
{
    private bool isOxygenMaskPickedUp = false;
    private GameObject oxygenMask;
    public GameObject NoO2DeadZone;

    public Canvas popupCanva;
    private TMP_Text popupText;
    public PlayerInput playerInput;

    void Start()
    {
        oxygenMask = GameObject.FindGameObjectWithTag("Oxygen Mask");
        oxygenMask.SetActive(true);

        popupCanva.gameObject.SetActive(false);
        popupText = popupCanva.GetComponentInChildren<TMP_Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isOxygenMaskPickedUp)
        {
            // pick up access card 
            oxygenMask.SetActive(false);

            isOxygenMaskPickedUp = true;
            ShowModal("Oxygen Tank picked up.", 2);

            NoO2DeadZone.SetActive(false);
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
