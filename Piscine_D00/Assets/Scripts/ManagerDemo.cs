using UnityEngine;
using System.Collections;

public class ManagerDemo : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            MusicManager.instance.Play();
        
        else if (Input.GetKeyDown(KeyCode.S))
            MusicManager.instance.Stop();
    }
}
