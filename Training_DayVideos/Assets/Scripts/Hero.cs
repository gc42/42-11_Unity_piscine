using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{
    public float        minSpeed;
    public float        maxSpeed;
    private float       speed;

    // ENUM pour lister des comportements
    public enum HeroDirection
    {
        UP,
        DOWN,
        STAY
    };

    public HeroDirection direction;


    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }


    void Update()
    {
        if (direction == HeroDirection.UP)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(0, speed*Time.deltaTime, 0);
        }
        else if (direction == HeroDirection.DOWN)
        {
            transform.localScale = new Vector3(1, -1, 1);
            transform.Translate(0, -speed*Time.deltaTime, 0);
        }
    }

    public void ChangeDirection(HeroDirection _direction)
    {
        speed = Random.Range(minSpeed, maxSpeed);
        direction = _direction;
    }
}