using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Rigidbody2D rb;

	public bool   onFocus = false;
	public bool   win = false;

    public string playerName = "";
    public float  movePower = 0f;
    public float  jumpPower = 0f;
	private float boost = 1;

    private bool  canJump = true;


	// Use this for initialization
	private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        win = false;
    }
	


	// Update is called once per frame
	private void Update ()
    {
        // BOOST mode
        if    (Input.GetKeyDown(KeyCode.LeftShift)) { boost = 1.8f; }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) { boost = 1f;   }
    }


	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled
	private void FixedUpdate()
	{
		// When this player is on focus
		if (onFocus == true)
		{
			Move();
			Jump();
		}
	}




	private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rb.AddForce(Vector3.up * jumpPower * boost);
            canJump = false;
        }
    }

	private void Move()
    {
            rb.velocity = new Vector2(
				Input.GetAxis("Horizontal") * movePower * boost * Time.deltaTime,
				rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground" || coll.gameObject.tag == "player")
        {
            if (coll.contacts[0].normal == Vector2.up)
            {
                canJump = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "goal" && ( coll.gameObject.layer == this.gameObject.layer ) )
        {
            win = true;
            Debug.Log("win");
        }

    }

    private void OnTriggerExit2D (Collider2D coll)
	{
	    if (coll.gameObject.tag == "goal" && ( coll.gameObject.layer == this.gameObject.layer ) )
	    {
	        win = false;
	        Debug.Log("not win");
	    }

	}

	


}