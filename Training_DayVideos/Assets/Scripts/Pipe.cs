using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    public static float speedPipe = 1f;
    public float power = 1;
    private Vector3 direction = Vector3.left;
    private float acceleration = 0.1f;
    private float refTime = 0.0f;
    private float deltaTime = 0.0f;
    public float delay = 5.0f;
    private int randomY;
    public static int score = 0;


	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () 
    {
        
        // Evolution of pipe speed
        deltaTime = Time.time - refTime;
        if (deltaTime > delay)
        {
            if (speedPipe < 10)
            {
                speedPipe = speedPipe + acceleration;
            }
            refTime = Time.time;
        }

        // Set velocity to the pipe
        transform.Translate(direction * speedPipe * power * Time.deltaTime);

        // Spawn pipe forwards to use it again
        randomY = Random.Range(-2, 2);
        if (transform.position.x < -5)
        {
            transform.position = new Vector3(5, 4 + randomY);
            score += 1;
        }

        // Pipe speed
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            power += 0.3f;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus) && power >= 1.3f)
        {
            power -= 0.3f;
        }

	}//EndUpdate ######################
}
