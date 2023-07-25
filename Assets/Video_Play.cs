using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video_Play : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;
    private void Awake()
    {
        string filepath = System.IO.Path.Combine(Application.streamingAssetsPath, "CutScene.mp4");
        player.url = filepath;

        player.Play();
    }
}
