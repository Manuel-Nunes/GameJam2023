using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Rooms
{
    CryoChamber,
    BeamHall,
    CavedHall,
    Power, 
    PowerCanteenHall,
    Canteen,
    Med,
    MedCockpitHall,
    Cockpit
}

public class HelpController : MonoBehaviour
{
    private bool isInPast = false; // the game starts in future
    private Rooms currentRoom = Rooms.CryoChamber;  // the game starts in CryoChamber
    private GameObject player;

    // game objects 
    private bool isAccessCardPickedUp = false;
    private bool isPowerTurnedOn = false;
    private bool isFireExtinguisherPickedUp = false;
    private bool isOxygenMaskPickedUp = false;

    private string hint = "";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        determineHint();
    }

    private void determineHint()
    {
        if (!isInPast && currentRoom.Equals(Rooms.CryoChamber)) 
        {
            // user does not know about the time travel 
            hint = "Did you know you could time travel?";
        }

        else if (isInPast && currentRoom.Equals(Rooms.CryoChamber))
        {
            hint = "Did you know you can walk through doors?";
        }

        else if (!isInPast && currentRoom.Equals(Rooms.BeamHall))
        {
            hint = "Beware of the collapsed beam!";
        }

        else if (isInPast && currentRoom.Equals(Rooms.BeamHall))
        {
            hint = "Have you tried to leave the room?";
        }

        else if (currentRoom.Equals(Rooms.CavedHall))
        {
            hint = "Have you looked at what is on the left side?";
        }

        else if (currentRoom.Equals(Rooms.PowerCanteenHall))
        {
            if (!isPowerTurnedOn && !isAccessCardPickedUp && !isFireExtinguisherPickedUp && !isOxygenMaskPickedUp)
            {
                // user has not picked up any tasks (stuck in PowerCanteenHall)
                hint = "Have you tried to switch on the power";
            }
            else if (!isPowerTurnedOn && !isAccessCardPickedUp && !isFireExtinguisherPickedUp && isOxygenMaskPickedUp)
            {
                // user picked up oxygen mask only 
                hint = "Have you tried to go to the cockpit?";
            }
            else if (!isPowerTurnedOn && !isAccessCardPickedUp && isFireExtinguisherPickedUp && !isOxygenMaskPickedUp)
            {
                // user picked up only the fire ext
                hint = "Have you tried to use your fire extinguisher? I heard the Power Engineer was having lunch in the canteen?";
            }
            else if (!isPowerTurnedOn && isAccessCardPickedUp && !isFireExtinguisherPickedUp && !isOxygenMaskPickedUp)
            {
                // user picked up access card 
            }
        }
    }
}
