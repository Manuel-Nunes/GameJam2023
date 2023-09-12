using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PopUpHint : MonoBehaviour
{
    public Canvas popupCanva;
    private TMP_Text popupText;
    public PlayerInput playerInput;

    public string popUpMessage;
    public bool hasShown = false;

    void Start()
    {
        popupCanva.gameObject.SetActive(false);
        popupText = popupCanva.GetComponentInChildren<TMP_Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasShown)
        {
            ShowModal(popUpMessage, 2);
            hasShown = true;
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
