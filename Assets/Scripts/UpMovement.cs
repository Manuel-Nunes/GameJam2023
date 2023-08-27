using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            player.transform.Translate(0, +1 * Time.deltaTime, 0);
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
