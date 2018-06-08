using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class LoadLevelScript
{

	public static void LoadSameLevel()
	{
        // Reload same level
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
	}

    public static void LoadNextLevel()
    {
        // Si scene courante < nombre de scenes possibles, alors...
        int maxScenes = SceneManager.sceneCountInBuildSettings;
        int currentSceneID = SceneManager.GetActiveScene().buildIndex;
        int nextSceneID = currentSceneID + 1;

        if ( nextSceneID < maxScenes)
        {
            SceneManager.LoadScene(nextSceneID);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }



}
