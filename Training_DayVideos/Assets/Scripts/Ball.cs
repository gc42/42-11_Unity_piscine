using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public static float speed    = 0f;
	public static bool  move     = false;
    public float        decrease = 0.1f;
	public static bool  inHole   = false;
    private Vector3     initPosition_Ball;
    private Vector3     direction;

    // ENUM pour lister des comportements
    public enum BallDirection
    {
        UP,
        DOWN
    };
    private BallDirection ballDir;

	// Use this for initialization
	void Start () 
    {
        initPosition_Ball = new Vector3(0, -17.69f, 0);
        ballDir = BallDirection.UP;
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Manage speed decrease 
        if (speed >= 0.1f)
        {
            speed -= decrease;
            move = true;
        }
        else
        {
            move = false;
			speed = 0;
        }

        // The Ball movement
        if (ballDir == BallDirection.UP)
        {
            direction = Vector3.up;
            //transform.Translate(direction * speed * Time.deltaTime);
        }
        if (ballDir == BallDirection.DOWN)
        {
            direction = Vector3.down;
            //transform.Translate(direction * speed * Time.deltaTime);
        }
        transform.Translate(direction * speed * Time.deltaTime);


        // When the Ball is in movement
        if (move == true)
        {
            Vector3 p = transform.position;

            // If hit Walls, reverse velocity
            if (p.x <= -2)
                ChangeDirection(BallDirection.UP);
			if (p.x >= 2)
                ChangeDirection(BallDirection.DOWN);
            if (p.y <= -20)
                ChangeDirection(BallDirection.UP);
			if (p.y >= 4)
                ChangeDirection(BallDirection.DOWN);


            // If the Ball is on the Hole
            float hd = 0.3f; // hd = holeDimension
            if (speed < Club.maxSpeed && -hd <= p.y && p.y <= hd && hd >= p.x && p.x >= -hd)
                inHole = true;
        }

        if (move == false && inHole == false)
        {
            Vector3 p = transform.position;
            ChangeDirection(BallDirection.UP);
            if (Club.score != -20)      // Input.GetKey(KeyCode.Space) && 
                Debug.Log("Score: " + Club.score);


            if (p.y < 0)
                ChangeDirection(BallDirection.UP);
            if (p.y >= 0)
                ChangeDirection(BallDirection.DOWN);
        }

        if (inHole)
        {
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
            speed = 0;
            Time.timeScale = 0;

            if (Club.score < 0)
                Debug.Log("You winn !! Score: " + Club.score.ToString("F0") + "--- Want to play again ? (y)");
            else
                Debug.Log("The ball is in the hole !! " + "Score: " + Club.score.ToString("F0") + "--- Want to play again ? (y)");
        }

        if (inHole && Input.GetKeyDown(KeyCode.Y))
        {
            transform.position = initPosition_Ball;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            inHole = false;
            Time.timeScale = 1;
            Club.score = -20;
            Debug.Log("");
        }


	}// End Update

    public void ChangeDirection(BallDirection _direction)
    {
        ballDir = _direction;
    }
}
