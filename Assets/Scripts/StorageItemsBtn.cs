using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StorageItemsBtn : MonoBehaviour, IPointerDownHandler
{
    private bool isVisible = false;
    private GameObject storageItems;

    void Start()
    {
        storageItems = GameObject.FindGameObjectWithTag("Storage Place");
        storageItems.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isVisible)
        {
            // hide storage items 
            storageItems.SetActive(false);
        }
        else
        {
            // show storage items 
            storageItems.SetActive(true);
        }

        isVisible = !isVisible;
    }
}
