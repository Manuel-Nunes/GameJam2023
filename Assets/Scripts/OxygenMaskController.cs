using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenMaskController : MonoBehaviour
{
    private bool isOxygenMaskPickedUp = false;
    private GameObject oxygenMask;
    public GameObject NoO2DeadZone;

    void Start()
    {
        oxygenMask = GameObject.FindGameObjectWithTag("Oxygen Mask");
        oxygenMask.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isOxygenMaskPickedUp)
        {
            // pick up access card 
            oxygenMask.SetActive(false);

            isOxygenMaskPickedUp = true;

            NoO2DeadZone.SetActive(false);
        }
    }
}
