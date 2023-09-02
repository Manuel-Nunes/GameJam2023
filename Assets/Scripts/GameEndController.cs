using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{
    private bool isPlayerDead = false;
    public GameObject gameEndedPanel;
    public Text gameEndedText;

    void Start()
    {
        if (this.name.Equals("Dead Zone"))
        {
            gameEndedText.text = "You fell through a hole in the floor";
        }
        else if (this.name.Equals("Fire"))
        {
            gameEndedText.text = "The fire burned you...";
        }

        gameEndedPanel?.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isPlayerDead && collision.gameObject.tag == "Player")
        {
            isPlayerDead = true;
            gameEndedPanel.SetActive(true);
        }
    }
}
