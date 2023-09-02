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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isPlayerDead && collision.gameObject.tag == "Player")
        {
            if (this.name.Equals("Dead Zone"))
            {
                GameEndedText.text = "You fell through a hole in the floor";
            }
            else if (this.name.Equals("Fire"))
            {
                GameEndedText.text = "The fire burned you...";
            }

            isPlayerDead = true;
            GameEndedPanel.SetActive(true);
        }
    }
}
