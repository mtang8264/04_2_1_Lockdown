using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager me;

    public AudioSource music;
    public AudioSource typewriter;

    private void Awake()
    {
        me = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        if (typewriter.isPlaying == false)
        {
            typewriter.Play();
        }
    }
    public void StopClick()
    {
        typewriter.Stop();
    }
}
