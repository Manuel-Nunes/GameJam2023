using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{

    public VideoPlayer player;
    bool isPlayerStarted = false;
    void Start()
    {
        player.Play();
    }
    void Update()
    {
        if (!isPlayerStarted && player.isPlaying)
        {
            isPlayerStarted = true;

        }
        else if (isPlayerStarted && !player.isPlaying)
        {
            this.gameObject.SetActive(false);
        }
    }
}
