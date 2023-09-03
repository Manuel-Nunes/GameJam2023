using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{

    public VideoPlayer player;
    public Canvas[] canvases;
    bool isPlayerStarted = false;
    void Start()
    {
        for (int i = 0; i <= canvases.Length - 1; i++)
        {

            canvases[i].gameObject.SetActive(false);
        }


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
            for (int i = 0; i <= canvases.Length - 1; i++)
            {

                canvases[i].gameObject.SetActive(true);
            }

        }
    }
}
