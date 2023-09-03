using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{
    private bool isPlayerDead = false;
    public GameObject GameEndedPanel;
    public Text GameEndedText;

    void Start()
    {
        GameEndedPanel?.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isPlayerDead && collision.gameObject.tag == "Player")
        {
            if (this.name.Equals("Dead Zone"))
            {
                GameEndedPanel.GetComponent<Image>().color = new Color32(255, 0, 0, 100);  // red
                GameEndedText.text = "You fell through a hole in the floor";
            }
            else if (this.name.Equals("Fire") || this.name.Equals("FutureFireRoom"))
            {
                GameEndedPanel.GetComponent<Image>().color = new Color32(255, 0, 0, 100);  // red
                GameEndedText.text = "The fire burned you...";
            }
            else if (this.name.Equals("Won"))
            {
                GameEndedPanel.GetComponent<Image>().color = new Color32(25, 164, 64, 100);  // green
                GameEndedText.text = "Game Won!";
            }

            isPlayerDead = true;
            GameEndedPanel.SetActive(true);
        }
    }

    public void DisplayMessage(bool Good, string Message){

        if (Good){
            GameEndedPanel.GetComponent<Image>().color = new Color32(25, 164, 64, 100);  // green
        } else {
            GameEndedPanel.GetComponent<Image>().color = new Color32(255, 0, 0, 100);  // red
        }

        GameEndedText.text = Message;

        isPlayerDead = true;
        GameEndedPanel.SetActive(true);
    }
}
