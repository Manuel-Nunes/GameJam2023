using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireLogic : MonoBehaviour
{
  public FireRoomFutureLogic FutureFireRoom;

  public List<GameObject> ExtinguishableItems = new List<GameObject>();

  public List<GameObject> GameObjectsInRoom = new List<GameObject>();

  public void OnTriggerEnter2D(Collider2D collision)
  {
    this.GameObjectsInRoom.Add(collision.gameObject);
    UpdateFireRoomState();
  }

    public void OnTriggerExit2D(Collider2D other)
    {
      this.GameObjectsInRoom.Remove(other.gameObject);
      UpdateFireRoomState();
    }

  void UpdateFireRoomState(){
    foreach (GameObject gameObject in GameObjectsInRoom){
      if (ExtinguishableItems.Contains(gameObject)){
        FutureFireRoom.PutFireOut();
        Debug.Log("Fire is out");
        return;
      }
    }
    
    Debug.Log("Fire is On");
    FutureFireRoom.LightFire();
  }
}
