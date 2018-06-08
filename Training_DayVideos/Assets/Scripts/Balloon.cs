using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    // Fields
    private int             counter  = 0;
    private float           addDelta = 0.6f;
    private float           subDelta = 0.02f;
    public GameObject      balloon;
    public GameObject      text;

	private void Awake()
	{
        text = GameObject.Find("Canvas/TextPerdu");
        Debug.Log("text est attribue a: " + text.name);
        text.SetActive(false);
	}

	// Use this for initialization
	void Start () 
    {
		balloon = GameObject.Find("Balloon");
        Debug.Log("baloon est attribue a: " + balloon.name);
	}
    	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.Find("Balloon") == true)
        {
            int playTime = Mathf.FloorToInt(10.0f * Time.time);
            float X = balloon.transform.localScale.x;
            float Y = balloon.transform.localScale.y;

            if (Input.GetKeyDown("space"))
            {
                counter++;
                if (counter < 10)
                    balloon.transform.localScale = new Vector3(X + addDelta, Y + addDelta, 1);
            }


            if (playTime % 5 == 0)
            {
                if (counter > 0)
                    counter--;
            }


            if (playTime % 2 == 0)
            {
                balloon.transform.localScale = new Vector3(X - subDelta, Y - subDelta, 1);
            }


            if (balloon.transform.localScale.x > 8 || balloon.transform.localScale.x < 0)
            {
                //text.SetActive(true);
                Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.realtimeSinceStartup) + "s");
                Destroy(balloon);
            }
        }

        if (GameObject.Find("Balloon") == false)
        {
            text.SetActive(true);
        }
	}
}
