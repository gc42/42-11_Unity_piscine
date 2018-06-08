using UnityEngine;
using System.Collections;

public class AllHero : MonoBehaviour
{
    public Town     town;
    public bool     isAlerted = false;

	void OnEnable()
	{
        // Abonnement a l'Event
        town.OnTownAttacked += AttackListener;
	}

	private void OnDisable()
	{
        // Desabonnement a l'Event
        town.OnTownAttacked -= AttackListener;
	}

    void AttackListener()
    {
        // Si l'Event est recu
        Debug.Log("Received event: On Town Attacked");
        isAlerted = true;
    }
	

	// Update is called once per frame
	void Update()
	{
        if (isAlerted)
            transform.Translate(new Vector3(0, 0.2f, 0));
	}
}
