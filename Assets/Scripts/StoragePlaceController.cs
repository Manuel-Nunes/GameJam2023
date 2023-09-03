using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoragePlaceController : MonoBehaviour
{
    private bool isAccessCardPickedUp = false;
    private bool isOxygenMaskPickedUp = false;

    private GameObject noItemsStorage;
    private GameObject storagePlaceAccessCard;
    private GameObject storagePlaceOxygenMask;

    void Start()
    {
        noItemsStorage = GameObject.FindGameObjectWithTag("Storage Place No Items");
        storagePlaceAccessCard = GameObject.FindGameObjectWithTag("Storage Place Access Card");
        storagePlaceOxygenMask = GameObject.FindGameObjectWithTag("Storage Place Oxygen Mask");

        noItemsStorage.SetActive(true);
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
            noItemsStorage.SetActive(false);
            storagePlaceAccessCard.SetActive(true);

            isAccessCardPickedUp = true;
        }

        else if (!isOxygenMaskPickedUp && GameObject.FindGameObjectWithTag("Oxygen Mask") == null)
        {
            // add oxygen mask to storage items 
            noItemsStorage.SetActive(false);
            storagePlaceOxygenMask.SetActive(true);

            isOxygenMaskPickedUp = true;
        }

        else if (!isAccessCardPickedUp && !isOxygenMaskPickedUp)
        {
            noItemsStorage.SetActive(true);
        }
    }
}
