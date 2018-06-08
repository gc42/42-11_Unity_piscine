using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DFollowScript : MonoBehaviour {

	public Transform target;

	private float m_OffsetZ = -10.0f;


	// Update is called once per frame
	void Update ()
	{
		if (target != null)
			transform.position = new Vector3(target.position.x, transform.position.y, m_OffsetZ);
		else
			transform.position = new Vector3(0, 0, m_OffsetZ);
	}
}
