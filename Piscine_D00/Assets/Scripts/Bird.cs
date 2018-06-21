using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private Vector3 direction;
    public float speed = 1;
    public bool useSpace = false;
    public bool endGame = false;
    private GameObject pipe = null;
    private string playTime = "";

    private enum BirdDirection
    {
        UP,
        DOWN
    }; private BirdDirection birdDir;


	// Use this for initialization
	void Start () {
        pipe = GameObject.Find("pipe");
        Debug.Log("Use Space to move the Bird up and down. Use +/- to accelerate tubes. Use Up/Down arrows to speed the Bird. Have fun !!");

	}
	
	// Update is called once per frame
	void Update () 
    {
		// Bird direction
        if (birdDir == BirdDirection.UP)
        {
            direction = Vector3.up;
        }
        if (birdDir == BirdDirection.DOWN)
        {
            direction = Vector3.down;
        }
        transform.Translate(direction * speed * Time.deltaTime);

        // On "SPACE"
        if (useSpace)
        {
            ChangeDirection(BirdDirection.UP);
        } else
        {
			ChangeDirection(BirdDirection.DOWN);
        }

        // Use "SPACE"
        if (Input.GetKeyDown(KeyCode.Space))
            useSpace = true;
        if (Input.GetKeyUp(KeyCode.Space))
            useSpace = false;

        // EndGame conditions
        Vector3 bp = transform.position;
        Vector3 pp = pipe.transform.position;
        if (bp.y < 0.35f)
        {
            endGame = true;
        }
        if ( bp.y < (pp.y - 1.67f) || (pp.y + 1.31f) < bp.y)
        {
            if (-3.86f < pp.x && pp.x < -2.78f)
            {
                endGame = true;
            }
        }

        // When endGame
        if (endGame == true)
        {
            Time.timeScale = 0;
            playTime = Mathf.RoundToInt(Time.time).ToString();
            Debug.Log("Perdu!! Score: " + Pipe.score + " pipes in " + playTime + "s. ---> What to play again ? (y)");
            if (Input.GetKey(KeyCode.Y))
            {
                Pipe.score = 0;
                Pipe.speedPipe = 1.0f;
                pipe.transform.position = new Vector3(5, 4, 0);
                transform.position = new Vector3(-3f, 4f, 0);
                Time.timeScale = 1;
                endGame = false;
            }
        }

        // Bird speed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += 0.1f;
        }
        if (Input.GetKey(KeyCode.DownArrow) && speed >= 1.1f)
        {
            speed -= 0.1f;
        }

    }//EndUpdate ######################

    private void ChangeDirection(BirdDirection _direction)
    {
        birdDir = _direction;
    }
}
