using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManagerScript : MonoBehaviour
{
    public Camera2DFollowScript  mainCamera = null;
    private PlayerScript[]  players;
	private PlayerScript    player = null;
	private int nbPlayers = 0;


    public GameObject           Claire;
    public GameObject           John;
    public GameObject           Thomas;
	private LevelManagerScript  LMS;


    // Use this for initialization
    void Start()
    {
        // Create the players with different capacities (prefab, name, move-power, jump-power)
        gameObject.CreateNewPlayer(Claire, "Claire", 40f, 170f);
        gameObject.CreateNewPlayer(John, "John", 70f, 250f);
        gameObject.CreateNewPlayer(Thomas, "Thomas", 50f, 180f);

        // Fill the table of players
        players = FindObjectsOfType<PlayerScript>();
        nbPlayers = players.Length;
        foreach (PlayerScript p in players)
            Debug.Log("bienvenue <color=blue>" + p.playerName + "</color>");

		// Default values
		mainCamera = FindObjectOfType<Camera2DFollowScript>();
		LMS = GameObject.Find("LevelManager").GetComponent<LevelManagerScript>();
		

        // Set default player
        player = players[0];
        player.onFocus = true;
        mainCamera.target = player.transform;
        Debug.Log("current player: " + player.gameObject.name);

    }



    // Update is called once per frame
    void Update()
    {
        int i;
        // Select player
        if (Input.anyKeyDown)
        {
            for (i = 0; i < players.Length; i++)
            {
                if (Input.GetKeyDown((i + 1).ToString()))
                {
                    SetPlayer(i);
					Debug.Log("Player changed. Current player is now <color=red>" + player.gameObject.name + "</color>");
                }
            }
        }

        for (i = 0; i < nbPlayers; i++)
        {
            if (players[i].win == false)
                return;
        }
        LMS.winLevel = true;
    } 



    private void SetPlayer(int x)
    {
        player.onFocus = false;
        player = players[x];
		player.onFocus = true;

        mainCamera.target = player.transform;
    }


}
