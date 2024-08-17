using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SceneIntro : MonoBehaviour
{
    private VideoPlayer vid;


    void Start() { 
        vid = GetComponent<VideoPlayer>();
        vid.loopPointReached += CheckOver; }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }

}