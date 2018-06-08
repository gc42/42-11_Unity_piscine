using UnityEngine;
using System.Collections;

public class Town : MonoBehaviour
{
    public delegate             void TownEvent();
    public event TownEvent      OnTownAttacked;

	// Update is called once per frame
	void Update()
	{
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Raising event : \"A\" => On Town Attacked");
            OnTownAttacked();
        }
	}
}
