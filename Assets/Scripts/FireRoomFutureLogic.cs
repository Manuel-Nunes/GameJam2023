using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class FireRoomFutureLogic : MonoBehaviour
{
    public bool IsOnFire = true;
    
    public List<GameObject> FireRoomDoors = new List<GameObject>();
    public BoxCollider2D FireRoomCollider; 
    public TilemapRenderer FoamFireLayer;

    public PlayerLifeManager PlayerLifeManager;
    public Light2D RoomLight;

    public TilemapRenderer FutureFireLayer;

    public GameEndController GameEndController;

    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Player is In FireRooms");
        if ( !IsOnFire){
            return;
        }
            
        if (col.gameObject.tag ==  "Player"){
            PlayerLifeManager.KillPlayer();
            GameEndController.DisplayMessage(false,"The fire burned you...");
        }
    }

    public void PutFireOut(){
        this.FireRoomCollider.enabled= false;
        this.RoomLight.enabled = false;
        this.IsOnFire = false;
        this.FutureFireLayer.enabled = false;
        this.FoamFireLayer.enabled = true;
        foreach (GameObject FireRoomDoors in FireRoomDoors){
            FireRoomDoors.SetActive(false) ;
        }
    }

    public void LightFire(){
        this.FireRoomCollider.enabled= true;
        this.RoomLight.enabled = true;
        this.IsOnFire = true;
        this.FutureFireLayer.enabled = true;
        this.FoamFireLayer.enabled = false;
        foreach (GameObject FireRoomDoors in FireRoomDoors){
            FireRoomDoors.SetActive(true) ;
        }
    }
}
