using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoragePlaceController : MonoBehaviour
{
    private bool isAccessCardPickedUp = false;
    private bool isOxygenMaskPickedUp = false;

    private GameObject storagePlaceAccessCard;
    private GameObject storagePlaceOxygenMask;

    void Start()
    {
        storagePlaceAccessCard = GameObject.FindGameObjectWithTag("Storage Place Access Card");
        storagePlaceOxygenMask = GameObject.FindGameObjectWithTag("Storage Place Oxygen Mask");

        storagePlaceAccessCard.SetActive(false);
        storagePlaceOxygenMask.SetActive(false);
    }

    void FixedUpdate()
    {
        checkIfStorageItemsPicked();
    }

    private void checkIfStorageItemsPicked()
    {
        if (!isAccessCardPickedUp && GameObject.FindGameObjectWithTag("Access Card") == null)
        {
            // add access card to storage items
            storagePlaceAccessCard.SetActive(true);

            isAccessCardPickedUp = true;
        }

        if (!isOxygenMaskPickedUp && GameObject.FindGameObjectWithTag("Oxygen Mask") == null)
        {
            // add oxygen mask to storage items 
            storagePlaceOxygenMask.SetActive(true);

            isOxygenMaskPickedUp = true;
        }
    }
}
