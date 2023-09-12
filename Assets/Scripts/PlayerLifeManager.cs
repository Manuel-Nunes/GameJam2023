using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    public PlayerDefinition PlayerDef;

    public Sprite PlayerDeath;

    public void KillPlayer(){
        PlayerDef.KillPlayer();
        PlayerDef.PlayerRender.sprite = PlayerDeath;
    }

    public void EndPlayer()
    {
        PlayerDef.KillPlayer();
    }
}
