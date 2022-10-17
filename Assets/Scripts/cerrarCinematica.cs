using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class cerrarCinematica : MonoBehaviour
{
    public VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer> ();
        video.Play();
        video.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckOver (VideoPlayer vp)
    {
        //poner que desean hacer
        gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
