using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class FireRoomFutureLogic : MonoBehaviour
{
    public bool IsOnFire = true;

    public List<GameObject> FireRoomDoors = new List<GameObject>();
    public TilemapRenderer FoamFireLayer;

    public PlayerLifeManager PlayerLifeManager;
    public Light2D RoomLight;

    public TilemapRenderer FutureFireLayer;

    public GameEndController GameEndController;

    public GameEndController.NonPlayerCallback nonPlayerCallback = (GameObject Target)=> {
        if (Target.tag != "Extinguisher"){
            
            Debug.Log("Not extinguisher found");
            return;
        }
    };

    public void PutFireOut(){

        if (!this.IsOnFire){
            return;
        }

        this.RoomLight.enabled = false;
        this.IsOnFire = false;
        this.FutureFireLayer.enabled = false;
        this.FoamFireLayer.enabled = true;
        this.GameEndController.DisbleDeathZone();
        foreach (GameObject FireRoomDoors in FireRoomDoors){
            FireRoomDoors.SetActive(false) ;
        }
    }

    public void LightFire(){
        try
        {
            if (this.IsOnFire){
                return;
            }

            this.IsOnFire = true;
            this.FutureFireLayer.enabled = true;
            this.FoamFireLayer.enabled = false;
            this.RoomLight.enabled = true;
            this.GameEndController.EnableDeathZone();
            foreach (GameObject FireRoomDoors in FireRoomDoors){
                FireRoomDoors.SetActive(true) ;
            }
        }
        catch (System.Exception)
        {
            Debug.Log("issue with restart probably");
        }
    }
}
