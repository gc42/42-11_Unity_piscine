using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{

    private float            gauge = 0;
    public float             power = 7;
    public static int        score = -20;
    //private readonly Vector3 initPosition_Club = new Vector3(-0.86f, -17.44f, 0);
    private readonly Vector3 decalPosition_Club = new Vector3(0, 0, 0);
    private Vector3          tempPosition_Club;
    private bool             UseSpace = false;
    private GameObject       ball;
    public static float      maxSpeed;
    public float             MaxSpeed = 7.0f;
    private Vector3          direction;

    // ENUM pour lister des comportements
    public enum ClubDirection
    {
        UP,
        DOWN
    };
    private ClubDirection clubDir;

	// Use this for initialization
	void Start()
    {
		ball = GameObject.Find("ball");
        transform.position = ball.transform.position + decalPosition_Club;
        clubDir = ClubDirection.UP;
    }

    // Update is called once per frame
    void Update()
    {
        maxSpeed = MaxSpeed;

        // The Club direction
        if (clubDir == ClubDirection.UP)
        {
            direction = Vector3.down;
			transform.localScale = new Vector3(3, 3, 1);
        }
        if (clubDir == ClubDirection.DOWN)
        {
            direction = Vector3.up;
            transform.localScale = new Vector3(3, -3, 1);
        }


        // When using SPACE key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseSpace = true;
            tempPosition_Club = transform.position;
        }

        if (UseSpace == true)
        {
            if (gauge < 5)
            {
                gauge = gauge + 0.1f;
                int i = 0;
                while (i < 20)
                {
                    transform.Translate(direction * Time.deltaTime * 0.1f);
                    i++;
                }
            }
        }

        if (UseSpace == false)
        {
            if (Ball.move == false && Ball.inHole == false)
            {
                transform.position = ball.transform.position + decalPosition_Club;

                // Change Club Direction
                Vector3 p = ball.transform.position;
                if (p.y < 0)
                    ChangeDirection(ClubDirection.UP);
                if (p.y >= 0)
                    ChangeDirection(ClubDirection.DOWN);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Ball.speed = gauge * power;
            gauge = 0;
            UseSpace = false;
            transform.position = tempPosition_Club;
            score += 5;
        }


    }

    public void ChangeDirection(ClubDirection _direction)
    {
        clubDir = _direction;
    }
}
