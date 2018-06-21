using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    private float minSpeed = 2f;
    private float maxSpeed = 5f;
    private float speed = 0;

	private void Start()
	{
        speed = Random.Range(minSpeed, maxSpeed);
	}

	// Update is called once per frame
	void Update ()
    {

        // Initial speed
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Destroy if out of game
        if (transform.position.y < -1.0f)
        {
            Destroy(gameObject, 0.1f);
        }


        // On Player action
        if      (Input.GetKeyDown(KeyCode.A))
        {
            OnPlay(0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            OnPlay(1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            OnPlay(2);
        }

    }



    private void OnPlay(int playerAction)
    {
        if (tag == "tag" + playerAction)
        {
            if (transform.position.y > 0)
            {
                CubeSpawner.counter++;
                float precision = transform.position.y;
                CubeSpawner.MidPrecision += precision;
                float moyenne = CubeSpawner.MidPrecision / CubeSpawner.counter;

                string Precision =   "Precision: " + precision.ToString("F03") 
                                   + " Moyenne: "  + moyenne.ToString("F03")
                                   + " (count: "   +  CubeSpawner.counter + ")";
                Debug.Log(Precision);



                Destroy(gameObject);
            }
        }
    }
}
