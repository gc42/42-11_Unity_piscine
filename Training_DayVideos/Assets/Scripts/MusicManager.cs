using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public static MusicManager  instance { get; private set; }

    private AudioSource         source;

    // Use this for initialization
    void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    public void Play()
    {
        source.Play();
        Debug.Log("Music is playing...");
    }    // Update is called once per frame

    public void Stop()
    {
        source.Stop();
        Debug.Log("Music is stopped.");
    }
}
