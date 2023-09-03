using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{

    public VideoPlayer player;
    public Canvas canvas;
    bool isPlayerStarted = false;
    void Start()
    {
        canvas.gameObject.SetActive(false);
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
            canvas.gameObject.SetActive(true);
        }
    }
}
