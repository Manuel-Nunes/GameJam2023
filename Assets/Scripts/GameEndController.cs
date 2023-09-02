using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndController : MonoBehaviour
{
    private bool isPlayerDead = false;
    private GameObject gameEndedPanel;

    void Start()
    {
        gameEndedPanel = GameObject.FindGameObjectWithTag("Game End Panel");
        gameEndedPanel.SetActive(false);
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
