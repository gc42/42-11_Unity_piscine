using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    public bool winLevel = false;

    private bool displayMessage = true;

	// Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		// Reload same level
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadLevelScript.LoadSameLevel();
        }

		// Reload next level, or back to initial level
		if (Input.GetKeyDown(KeyCode.N))
		{
			LoadLevelScript.LoadNextLevel();
		}


        // on WIN conditions
        if (winLevel == true)
        {
            if (winLevel == true && displayMessage == true)
            {
                Debug.Log("<color=red>You win!!!    Want to continue ? (y)</color>");
                Time.timeScale = 0.3f;
                displayMessage = false;
			}

			// Continue to next level
			if (Input.GetKeyDown(KeyCode.Y))
            {
                LoadLevelScript.LoadNextLevel();

                Time.timeScale = 1;
                winLevel = false;
                displayMessage = true;
            }
        }


    }
}