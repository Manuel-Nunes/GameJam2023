using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    bool hasPower = false;
    public TMP_Text infoText;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Engine":
                if (hasPower)
                {
                    infoText.text = "Engine is on";
                    Debug.Log("Engine is on");
                }
                else
                {
                    infoText.text = "The spaceship has no power!";
                    Debug.Log("Loadshedding");
                }
                break;

            case "Switch":

                hasPower = !hasPower;
                break;
            default:
                break;

        }
    }

}

/*    public void PowerEngine()
    {
        if (!hasPower)
        {

        }
    }

    public void SwitchPower()
    {
        hasPower = !hasPower;
    }*/




