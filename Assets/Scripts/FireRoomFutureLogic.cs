using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class FireRoomFutureLogic : MonoBehaviour
{
    public bool IsOnFire = true;
    
    public BoxCollider2D FireRoomCollider; 
    public Tilemap FoamFireLayer;

    public PlayerLifeManager PlayerLifeManager;
    public Light2D RoomLight;

    public Tilemap FutureFireLayer;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if ( !IsOnFire){
            return;
        }
            
        if (col.gameObject.tag ==  "Player"){
            PlayerLifeManager.KillPlayer();
        }
    }

    public void PutFireOut(){
        this.FireRoomCollider.enabled= false;
        this.RoomLight.enabled = false;
        this.IsOnFire = false;
        this.FutureFireLayer.enabled = false;
        this.FoamFireLayer.enabled = false;
    }

    public void LightFire(){
        this.FireRoomCollider.enabled= true;
        this.RoomLight.enabled = true;
        this.IsOnFire = true;
        this.FutureFireLayer.enabled = true;
        this.FoamFireLayer.enabled = true;
    }
}
